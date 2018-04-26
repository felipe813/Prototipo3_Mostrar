using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavegabilidadCanvasInicio : MonoBehaviour {
	public Canvas canvasMenu;
	public Canvas canvasRegistro;
	public Canvas canvasLogin;

	public void mostrarMenu(){
		canvasMenu.gameObject.SetActive(true);
		canvasRegistro.gameObject.SetActive(false);
		canvasLogin.gameObject.SetActive(false);
	}
	public void mostrarRegistro(){
		canvasMenu.gameObject.SetActive(false);
		canvasRegistro.gameObject.SetActive(true);
		canvasLogin.gameObject.SetActive(false);
	}
	public void mostrarLogin(){
		canvasMenu.gameObject.SetActive(false);
		canvasRegistro.gameObject.SetActive(false);
		canvasLogin.gameObject.SetActive(true);
	}
}
