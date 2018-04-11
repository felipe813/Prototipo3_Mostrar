using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlVisualizacionObra : MonoBehaviour
{
    public void iniciarVisualizacion()
    {
        Obra obraActual = DatosUsuario.Instance.buscarObra(ObraActual.Instance.idObraActual);
        GameObject.Find("UI").GetComponent<ControlVisibilidadCanvasObra>().activarCanvas();
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
        GameObject cronometro = GameObject.Find("Cronometro");
        cronometro.GetComponent<ControlTiempo>().tiempo = obraActual.tiempoSegundos;
        if (obraActual.calificacion != 0)
        {
            Debug.Log("Entroo "+obraActual.calificacion);
            GameObject estrella = GameObject.Find("estrella" + obraActual.calificacion);
            estrella.GetComponent<Button>().onClick.Invoke();
        }else{
            GameObject.Find("Calificacion").GetComponent<ControlCalificacion>().calificacion0();
        }
        txt_titulo.GetComponent<Text>().text = obraActual.nombre;
        //Cambio de camara
        GameObject controlCamara = GameObject.Find("ControlCamara");
      
        
        controlCamara.GetComponent<ControlCamaras>().activarCamaraObra(obraActual.posicion, obraActual.anguloRotacion,esPintura);
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
