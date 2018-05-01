using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AbrirObra : MonoBehaviour
{
    private string _id;
    public void abrirObra()
	{
		GameObject.Find ("Avatar").SetActive(false);
        GameObject.Find("CanvasIntroduccion").GetComponent<ControlVisibilidadCanvas>().activarCanvas();
        GameObject.Find ("ControlCamara").GetComponent<ControlCamaraSeguimiento>().seguirPersonaje=false;
        ObraActual.Instance.idObraActual = id;
    }
    public string id
    {
        get { return _id; }
        set { _id = value; }
    }
}
