using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargarInicio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Loader a =GameObject.Find("Loader").GetComponent<Loader>();
		a.LoadLevel("Escena_Inicio");
		//SceneLoader.LoadScene("Escena_Inicio");
	}
	
	
	
}
