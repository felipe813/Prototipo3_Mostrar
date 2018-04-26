using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Login : MonoBehaviour
{
    private string direccionServicioREST = "http://api-usuarios-museal.herokuapp.com/api/logueo";
    private string datosLogueo;
    private void Start()
    {
        datosLogueo = null;
        StartCoroutine(consumirRest());

    }
    private IEnumerator consumirRest()
    {
        // Pasamos parámetro por GET
        WWW www = new WWW(direccionServicioREST);

        while (!www.isDone)
        {
            yield return null;
        }
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Error servicio REST logueo : " + www.error);
            yield return null;
        }
        datosLogueo = www.text;
        //Debug.Log(datosLogueo);
        
    }

    private int WebserviceResponse(string usuario, string password, int tipo)
    {
        JSONNode informacion = JSON.Parse(datosLogueo)["data"];
        int cantidadDatos=informacion.Count;
        for (int i = 0; i < cantidadDatos; i++)
        {
            if(informacion[i]["idtipologueologueo"].Equals(tipo)&&informacion[i]["usuariologueo"].Equals(usuario)&&informacion[i]["contrasena"].Equals(password)){
                return informacion[i]["idlogueo"];
            }
        }
        return -1;
    }

    public int autenticarDatos(string usuario, string password, int tipo){
        int retorno=WebserviceResponse(usuario,password,tipo);
        Debug.Log(retorno);
        return retorno; 
    }
}
