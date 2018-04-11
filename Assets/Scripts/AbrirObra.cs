using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AbrirObra : MonoBehaviour
{
    private int _id;
    private void OnMouseUpAsButton()
    {
        GameObject.Find("CanvasIntroduccion").GetComponent<ControlVisibilidadCanvas>().activarCanvas();
        ObraActual.Instance.idObraActual = id;
    }
    public int id
    {
        get { return _id; }
        set { _id = value; }
    }
}
