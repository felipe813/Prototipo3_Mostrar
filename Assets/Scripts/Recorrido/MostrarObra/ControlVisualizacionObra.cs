using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlVisualizacionObra : MonoBehaviour
{
    public void iniciarVisualizacion()
    {
        //Canvas Visualizacion
        Obra obraActual = DatosUsuario.Instance.buscarObra(ObraActual.Instance.idObraActual);
        GameObject.Find("UI").GetComponents<ControlVisibilidadCanvas>()[2].activarCanvas();
        GameObject.Find("UI").GetComponent<ControlVisibilidadCanvasObra>().activarCanvas();
        GameObject.Find("UI").GetComponents<ControlVisibilidadCanvas>()[1].activarCanvas();
        bool esPintura;
        if (obraActual.tipo.Equals("escultura"))
        {
            esPintura = false;
            GameObject.Find("UI").GetComponent<ControlVisibilidadCanvasObra>().activarPanelTransformacion();
        }
        else
        {
            esPintura = true;
            GameObject.Find("UI").GetComponent<ControlVisibilidadCanvasObra>().desactivarPanelTransformacion();

        }
        GameObject txt_titulo = GameObject.Find("txt_titulo");
        //GameObject cronometro = GameObject.Find("Cronometro");
        //cronometro.GetComponent<ControlTiempo>().tiempo = obraActual.tiempoSegundos;
        if (obraActual.calificacion != 0)
        {
            Debug.Log("Entroo " + obraActual.calificacion);
            GameObject estrella = GameObject.Find("estrella" + obraActual.calificacion);
            estrella.GetComponent<Button>().onClick.Invoke();
        }
        else
        {
            GameObject.Find("Calificacion").GetComponent<ControlCalificacion>().calificacion0();
        }
        txt_titulo.GetComponent<Text>().text = obraActual.nombre;
        //Cambio de camara
        GameObject controlCamara = GameObject.Find("ControlCamara");


        controlCamara.GetComponent<ControlCamaras>().activarCamaraObra(obraActual.posicion, obraActual.anguloRotacion, esPintura);


        //Canvas multimedia

        int childs = GameObject.Find("CanvasMultimedia/Scroll View/Viewport/Content").transform.childCount;
        for (int i = 0; i < childs; i++)
        {
            GameObject.DestroyImmediate(GameObject.Find("CanvasMultimedia/Scroll View/Viewport/Content").transform.GetChild(0).gameObject);
        }

        int tamañoContentScroll = 55 * (obraActual.audios.Count + obraActual.videos.Count) + 10;
        int primerElementoY = tamañoContentScroll / 2 - 30;

        if (obraActual.audios.Count == 0 && obraActual.videos.Count == 0)
        {
            GameObject texto = (GameObject)Resources.Load("Prefabs/txt_no_multimedia") as GameObject;
            GameObject texto_nulo = Instantiate(texto, transform);
            GameObject canvas_contenedor = GameObject.Find("CanvasMultimedia/Scroll View/Viewport/Content");
            GameObject.Find("CanvasMultimedia/Scroll View/Viewport/Content").GetComponent<RectTransform>().sizeDelta = new Vector2(0, 200);
            texto_nulo.transform.SetParent(canvas_contenedor.transform, false);
        }
        else
        {
            GameObject.Find("CanvasMultimedia/Scroll View/Viewport/Content").GetComponent<RectTransform>().sizeDelta = new Vector2(0, tamañoContentScroll);

        }

        for (int i = 0; i < obraActual.audios.Count; i++)
        {
            GameObject panel = (GameObject)Resources.Load("Prefabs/PanelAudio") as GameObject;
            GameObject panel_audio = Instantiate(panel, transform);
            panel_audio.GetComponent<InicializarElementoMultimedia>().inicializarElemento(obraActual.audios[i].nombreMultimedia, obraActual.audios[i].urlMultimedia);
            GameObject canvas_contenedor = GameObject.Find("CanvasMultimedia/Scroll View/Viewport/Content");
            panel_audio.transform.position = new Vector3(0, (primerElementoY - i * 55), 0);
            panel_audio.transform.SetParent(canvas_contenedor.transform, false);
        }
        for (int i = 0; i < obraActual.videos.Count; i++)
        {
            GameObject panel = (GameObject)Resources.Load("Prefabs/PanelVideo") as GameObject;
            GameObject panel_video = Instantiate(panel, transform);
            panel_video.GetComponent<InicializarElementoMultimedia>().inicializarElemento(obraActual.videos[i].nombreMultimedia, obraActual.videos[i].urlMultimedia);
            GameObject canvas_contenedor = GameObject.Find("CanvasMultimedia/Scroll View/Viewport/Content");
            panel_video.transform.position = new Vector3(0, (primerElementoY - (i + obraActual.audios.Count) * 55), 0);
            panel_video.transform.SetParent(canvas_contenedor.transform, false);
        }
        GameObject.Find("UI").GetComponents<ControlVisibilidadCanvas>()[2].desactivarCanvas();
    }

    public void pausarVisualizacion()
    {
        Obra obraActual = DatosUsuario.Instance.buscarObra(ObraActual.Instance.idObraActual);
        GameObject calificacion = GameObject.Find("Calificacion");
        GameObject cronometro = GameObject.Find("Cronometro");
        obraActual.calificada = true;
        obraActual.calificacion = calificacion.GetComponent<ControlCalificacion>().nota;
        obraActual.tiempoSegundos = cronometro.GetComponent<ControlTiempo>().tiempo;
        ObraActual.Instance.idObraActual = -1;
        DatosUsuario.Instance.ImprimirDatosObras();

        //Cambio de camara
        GameObject controlCamara = GameObject.Find("ControlCamara");
        controlCamara.GetComponent<ControlCamaras>().activarCamaraPrincipal();

    }
    public void terminarVisualizacion()
    {
        pausarVisualizacion();
        //Guardar en base de datos
        //Desabilitar vista obra
    }


}
