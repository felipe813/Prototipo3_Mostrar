using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class TiposLogueo : MonoBehaviour
{

    private static JSONNode _datosTipoLogueo;
    public Dropdown seleccion;


    private void Start()
    {

        StartCoroutine(llenarDatosSeleccion());

    }

    private IEnumerator llenarDatosSeleccion()
    {
        string tipos = ServicioREST.EjecutarOperacion("http://api-usuarios-museal.herokuapp.com/api/tipologueo", "GET");
        _datosTipoLogueo = JSON.Parse(tipos)["data"];
        while (_datosTipoLogueo == null)
        {
            yield return null;
        }
        seleccion.AddOptions(getListaTiposLogueo());
    }

    public static int getIdTipoLogueo(string tipoLogueo)
    {
        for (int i = 0; i < _datosTipoLogueo.Count; i++)
        {
            if (tipoLogueo.EndsWith(_datosTipoLogueo[i]["tipologueo"]))
            {
                return _datosTipoLogueo[i]["idtipologueo"];
            }
        }
        return -1;
    }

    private static List<string> getListaTiposLogueo()
    {
        List<string> retorno = new List<string>();
        for (int i = 0; i < _datosTipoLogueo.Count; i++)
        {
            retorno.Add(_datosTipoLogueo[i]["tipologueo"]);
        }
        return retorno;
    }
}
