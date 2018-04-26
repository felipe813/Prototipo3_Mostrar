using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;


public class ControlLogin : MonoBehaviour {

	public Text txt_usuario;
	public InputField txt_password;
	public void ejecutarRegistro(){
		int idUsuario=existePerfil(txt_usuario.text,txt_password.text);
		if(idUsuario==-1){
			Debug.Log("Datos Incorrectos");
		}else{
			DatosUsuario.Instance.idUsuario=""+idUsuario;
			DatosUsuario.Instance.nombreUsuario=txt_usuario.text;
			SceneLoader.LoadScene("Escena_Introduccion");
		}
	}
	private int existePerfil(string usuario,string password){
		string  respuesta=ServicioREST.EjecutarOperacion("http://api-usuarios-museal.herokuapp.com/api/usuariologueo/"+usuario , "GET");
		JSONNode informacion=JSON.Parse (respuesta);
		if(!informacion["data"][0]["idusuario"]){
			Debug.Log("No existe el usuario");
			return -1;
		}
		string pass=informacion["data"][0]["contrasena"];
		if(pass==password){
			return informacion["data"][0]["idusuario"];
		}else{
			Debug.Log("La contrasenia no coincide");
			return -1;
		}
	}

	
}
