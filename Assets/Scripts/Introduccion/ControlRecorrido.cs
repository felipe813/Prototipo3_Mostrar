using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class ControlRecorrido : MonoBehaviour
{

    private void Start()
    {
        llenarDatosObras();
    }

    public void iniciarRecorrido()
    {
        SceneLoader.LoadScene("Escena_Museo");
    }
    private int obtenerIDRecorrido()
    {
        return 20;
    }

    private List<int> obtenerIDObrasNoVistas()
    {
        List<int> retorno = new List<int>();
        int idRecorrido = obtenerIDRecorrido();
        string respuesta = ServicioREST.EjecutarOperacion("http://api-usuarios-museal.herokuapp.com/api/obravista/obrasnovistasrecorrido/" + idRecorrido, "GET");
        JSONNode informacion = JSONNode.Parse(respuesta)["data"];
        for (int i = 0; i < informacion.Count; i++)
        {
            retorno.Add(informacion[i]["idobravistarecorrido"]);
        }
        return retorno;
    }

    private void llenarDatosObras()
    {
        List<int> idsObrasNoVistas = obtenerIDObrasNoVistas();
        DatosUsuario.Instance.obras = new List<Obra>();

        string respuesta;
        JSONNode informacion;
        for (int i = 0; i < idsObrasNoVistas.Count; i++)
        {
            respuesta = ServicioREST.EjecutarOperacion("http://api-usuarios-museal.herokuapp.com/api/obravista/" + idsObrasNoVistas[i], "GET");
            informacion = JSONNode.Parse(respuesta)["data"];
            DatosUsuario.Instance.obras.Add(obtenerObra(informacion["idobra"], informacion["idobravistarecorrido"]));
        }
        //DatosUsuario.Instance.ImprimirDatosObras();
    }

    private Obra obtenerObra(string idObra, int obraVistaRecorrido)
    {
        Obra retorno;
        string respuesta = ServicioREST.EjecutarOperacion("http://www.omdbapi.com/?i=" + idObra + "&plot=full&apikey=ff49da19", "GET");
        JSONNode informacion = JSONNode.Parse(respuesta);
        retorno = new Obra(informacion["Title"], idObra);
        retorno.url = informacion["Poster"];
        retorno.tipo = "pintura";
        int index = 0;
        foreach (string key in informacion.Keys)
        {
            retorno.informacion.informacion.Add(new DetalleInformacion());
            retorno.informacion.informacion[index].encabezado = key;
            if (informacion[key].AsArray != null)
            {
                for (int i = 0; i < informacion[key].AsArray.Count; i++)
                {
                    retorno.informacion.informacion[index].datos.Add(informacion[key].AsArray[i][0] + " : " + informacion[key].AsArray[i][1]);
                }
            }else{
                retorno.informacion.informacion[index].datos.Add(informacion[key]);
            }
            index++;
        }
        retorno.idObraRecorrido = obraVistaRecorrido;
        return retorno;
    }


}
