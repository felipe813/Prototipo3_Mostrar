using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;

public class ControlRegistro : MonoBehaviour
{
    public Text txt_usuario;
    public InputField txt_password;
    public Text txt_nobmre;
    public Text txt_apellido;
    public Text txt_telefono;
    public Text txt_direccion;
    public Text txt_fecha;

    public void ejecturarRegistro()
    {
        int idUsuario = existePerfil(txt_usuario.text);
        if (idUsuario == -1)
        {
            string jsonPOST = "{" +
                "\"idtipologueologueo\":" + TiposLogueo.getIdTipoLogueo("Normal") + "," +
                "\"usuariologueo\": \"" + txt_usuario.text + "\"," +
                "\"contrasena\": \"" + txt_password.text + "\"" +
                "}";
            string respuesta = ServicioREST.EjecutarOperacion("http://api-usuarios-museal.herokuapp.com/api/logueo", "POST", jsonPOST);
            JSONNode informacion = JSON.Parse(respuesta)["data"];
            int idLogueo = informacion["idlogueo"];
            string jsonPOST2 = "{" +
            "\"idlogueousuario\":" + idLogueo + "," +
            "\"nombreusuario\":\"" + txt_nobmre.text + "\"," +
            "\"apellidousuario\":\"" + txt_apellido.text + "\"," +
            "\"direccionusuario\":\"" + txt_direccion.text + "\"," +
            "\"telefono\":\"" + txt_telefono.text + "\"," +
            "\"fechadenacimiento\":\"" + txt_fecha.text + "\"" +
            "}";
            respuesta = ServicioREST.EjecutarOperacion("http://api-usuarios-museal.herokuapp.com/api/usuarios", "POST", jsonPOST2);
            informacion = JSON.Parse(respuesta)["data"];
            idUsuario = informacion["idusuario"];
            DatosUsuario.Instance.idUsuario = "" + idUsuario;
            DatosUsuario.Instance.nombreUsuario = txt_usuario.text;
            //SceneLoader.LoadScene("Escena_Introduccion");
            Loader loader =GameObject.Find("LoaderR").GetComponent<Loader>();
		    loader.LoadLevel("Escena_Introduccion");
        }
        else
        {
            Debug.Log("El usuario ya existe y su id es " + idUsuario);
        }
    }
    private int existePerfil(string usuario)
    {
        int tipoLogueo = TiposLogueo.getIdTipoLogueo("Normal");
        string respuesta = ServicioREST.EjecutarOperacion("http://api-usuarios-museal.herokuapp.com/api/usuariologueo/" + usuario, "GET");
        JSONNode informacion = JSON.Parse(respuesta);
        if (!informacion["data"][0]["idusuario"])
        {
            return -1;
        }
        else
        {
            int tipoLog = informacion["data"][0]["idtipologueo"];
            if (tipoLog == tipoLogueo)
            {
                Debug.Log("El usuario ya existe en la base de datos");
                return informacion["data"][0]["idusuario"];
            }
            else
            {
                return -1;
            }
        }
    }

}
