using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarObra : MonoBehaviour {

	public void cerrarObra(){
        //GameObject.Find ("Avatar").SetActive(true);
		GameObject.Find("UI").GetComponent<ControlVisibilidadCanvasObra>().desactivarCanvas();
        GameObject.Find("UI").GetComponents<ControlVisibilidadCanvas>()[1].desactivarCanvas();
        GameObject.Find("CanvasIntroduccion").GetComponent<ControlVisibilidadCanvas>().desactivarCanvas();
		GameObject.Find ("ControlCamara").GetComponent<ControlCamaraSeguimiento>().seguirPersonaje=true;
        ObraActual.Instance.idObraActual = "";
		
    }
}
