using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavegabilidadCanvas : MonoBehaviour {

	public Canvas canvasVisualizacion;
	public Canvas elementosComunes;
	public Canvas canvasInformacion;
	public Canvas canvasMultimedia;
	public Canvas canvasComentar;

	public void activarCanvasVisualizacion(){
		elementosComunes.gameObject.SetActive(false);
		canvasVisualizacion.gameObject.SetActive(true);
		canvasInformacion.gameObject.SetActive(false);
		canvasMultimedia.gameObject.SetActive(false);
		canvasComentar.gameObject.SetActive(false);
		elementosComunes.gameObject.SetActive(true);
	}
	
	public void activarCanvasComentar(){
		elementosComunes.gameObject.SetActive(false);
		canvasVisualizacion.gameObject.SetActive(false);
		canvasInformacion.gameObject.SetActive(false);
		canvasMultimedia.gameObject.SetActive(false);
		canvasComentar.gameObject.SetActive(true);
		elementosComunes.gameObject.SetActive(true);
	}

	public void activarCanvasInformacion(){
		elementosComunes.gameObject.SetActive(false);
		canvasVisualizacion.gameObject.SetActive(false);
		canvasInformacion.gameObject.SetActive(true);
		canvasMultimedia.gameObject.SetActive(false);
		canvasComentar.gameObject.SetActive(false);
		elementosComunes.gameObject.SetActive(true);
	}

	public void activarCanvasMultimedia(){
		elementosComunes.gameObject.SetActive(false);
		canvasVisualizacion.gameObject.SetActive(false);
		canvasInformacion.gameObject.SetActive(false);
		canvasMultimedia.gameObject.SetActive(true);
		canvasComentar.gameObject.SetActive(false);
		elementosComunes.gameObject.SetActive(true);
	}

}
