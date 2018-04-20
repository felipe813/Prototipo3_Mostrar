using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InicializarElementoMultimedia : MonoBehaviour {

	private string nombreMultimedia;
	private string urlMultimedia;
	public Text textoTitulo;
	public Button boton; 
	public void inicializarElemento(string nombre,string url){
		this.nombreMultimedia=nombre;
		this.urlMultimedia=url;
		textoTitulo.text=nombreMultimedia;
	}
	public void abrirMultimedia(){
		Debug.Log("Se abrirá el enlace "+urlMultimedia);
	}
}
