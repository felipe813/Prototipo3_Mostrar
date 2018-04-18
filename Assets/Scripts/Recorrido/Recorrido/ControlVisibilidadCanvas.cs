using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVisibilidadCanvas : MonoBehaviour {

	// Use this for initialization
	public Canvas canvas;
	
	void Start () {
		desactivarCanvas();
	}

	public void activarCanvas(){
		this.canvas.gameObject.SetActive(true);
	}

	public void desactivarCanvas(){
		this.canvas.gameObject.SetActive(false);
		
	}

}
