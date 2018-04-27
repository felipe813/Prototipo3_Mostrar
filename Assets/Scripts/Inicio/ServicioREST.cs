using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;

public class ServicioREST
{
    public static string EjecutarOperacion(string direccionAPI,string operacion,string json)
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(direccionAPI);
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = operacion;

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            streamWriter.Write(json);
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var responseText = streamReader.ReadToEnd();
            return responseText;
        }
    }

	public static string EjecutarOperacion(string direccionAPI,string operacion)
    {
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(direccionAPI);
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = operacion;
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var responseText = streamReader.ReadToEnd();
            return responseText;
        }
    }
}
