using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AbrirObra : MonoBehaviour
{
    private int _id;
    public void abrirObra()
	{
		GameObject.Find ("Avatar").SetActive(false);
        GameObject.Find("CanvasIntroduccion").GetComponent<ControlVisibilidadCanvas>().activarCanvas();
        ObraActual.Instance.idObraActual = id;
    }
    public int id
    {
        get { return _id; }
        set { _id = value; }
    }
}
