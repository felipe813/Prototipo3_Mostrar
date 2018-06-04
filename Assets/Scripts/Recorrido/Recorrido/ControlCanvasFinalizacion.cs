using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
public class ControlCanvasFinalizacion : MonoBehaviour {

	 public GameObject canvas;

    public void activarCanvas()
    {
        canvas.SetActive(true);
    }

    public void desactivarCanvas()
    {
        canvas.SetActive(false);
    }

	public void salirAplicacion(){
		   Application.Quit();
		   //EditorApplication.isPlaying = false;
	}
}
