using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaREST : MonoBehaviour
{
    private void Start()
    {

        string jsonPUT = "{" +
                "\"usuariologueo\": \"Camilo\"," +
                "\"contrasena\": \"password\"" +
                "}";
        string jsonPOST = "{" +
                "\"idlogueo\": 6," +
                "\"idtipologueologueo\":1," +
                "\"usuariologueo\": \"Pedro\"," +
                "\"contrasena\": \"987654321\"" +
                "}";
        Debug.Log(ServicioREST.EjecutarOperacion("http://api-usuarios-museal.herokuapp.com/api/tipologueo", "GET"));
        Debug.Log(ServicioREST.EjecutarOperacion("http://api-usuarios-museal.herokuapp.com/api/logueo/1", "PUT", jsonPUT));
        Debug.Log(ServicioREST.EjecutarOperacion("http://api-usuarios-museal.herokuapp.com/api/logueo", "POST", jsonPOST));
    }
}
