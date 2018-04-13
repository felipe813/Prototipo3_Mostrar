using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcomodarObras : MonoBehaviour {
	public GameObject planoInferior;
	public GameObject planoSuperior;
	private Vector3[] verticesPlanoInferior;
	private Vector3[] verticesPlanoSuperior;
	private int cantidadPinturas;
	private int cantidadEsculturas;
	private int altopinturas;
	// Use this for initialization
	//3.....1
	//
	//4.....2
	void Start () {
		Vector3 posicionPlanoInferior=planoInferior.transform.position;
		Vector3 escalaPlanoInferior=planoInferior.transform.localScale*10;
		verticesPlanoInferior=new Vector3[4];
		verticesPlanoInferior[0]=new Vector3(posicionPlanoInferior.x+escalaPlanoInferior.x/2,posicionPlanoInferior.y,posicionPlanoInferior.z+escalaPlanoInferior.z/2);
		verticesPlanoInferior[1]=new Vector3(posicionPlanoInferior.x+escalaPlanoInferior.x/2,posicionPlanoInferior.y,posicionPlanoInferior.z-escalaPlanoInferior.z/2);
		verticesPlanoInferior[2]=new Vector3(posicionPlanoInferior.x-escalaPlanoInferior.x/2,posicionPlanoInferior.y,posicionPlanoInferior.z+escalaPlanoInferior.z/2);
		verticesPlanoInferior[3]=new Vector3(posicionPlanoInferior.x-escalaPlanoInferior.x/2,posicionPlanoInferior.y,posicionPlanoInferior.z-escalaPlanoInferior.z/2);

		Vector3 posicionPlanoSuperior=planoSuperior.transform.position;
		Vector3 escalaPlanoSuperior=planoSuperior.transform.localScale*10;
		verticesPlanoSuperior=new Vector3[4];
		verticesPlanoSuperior[0]=new Vector3(posicionPlanoSuperior.x+escalaPlanoSuperior.x/2,posicionPlanoSuperior.y,posicionPlanoSuperior.z+escalaPlanoSuperior.z/2);
		verticesPlanoSuperior[1]=new Vector3(posicionPlanoSuperior.x+escalaPlanoSuperior.x/2,posicionPlanoSuperior.y,posicionPlanoSuperior.z-escalaPlanoSuperior.z/2);
		verticesPlanoSuperior[2]=new Vector3(posicionPlanoSuperior.x-escalaPlanoSuperior.x/2,posicionPlanoSuperior.y,posicionPlanoSuperior.z+escalaPlanoSuperior.z/2);
		verticesPlanoSuperior[3]=new Vector3(posicionPlanoSuperior.x-escalaPlanoSuperior.x/2,posicionPlanoSuperior.y,posicionPlanoSuperior.z-escalaPlanoSuperior.z/2);
	}

	public void acomodarObras(){
		cantidadPinturas = DatosUsuario.Instance.cantidadPinturas ();
		cantidadEsculturas = DatosUsuario.Instance.cantidadEsculturas ();
		altopinturas = 10;
		if(cantidadPinturas==1){
			DatosUsuario.Instance.addPosicionObra (new Vector3(,altopinturas,),0f,0,"pintura");
		}
		Debug.Log (cantidadPinturas);
		Debug.Log (cantidadEsculturas);
	}

	private vector3 puntoMedioX{

	}

	private vector5 puntoMedioZ{
		
	}
		
}
