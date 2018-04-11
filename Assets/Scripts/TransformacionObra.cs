using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TransformacionObra : MonoBehaviour
{
    private GameObject obra;
    private GameObject modelo3D;
    private Quaternion rotacionInicial;
    private Vector3 escalaInicial;
    private Vector3 posicionInicial;
    public void ActualizarObra(int idObra)
    {
        modelo3D = GameObject.Find("Modelo"+idObra);
        obra = modelo3D.transform.GetChild(0).gameObject;
        rotacionInicial = obra.transform.rotation;
        escalaInicial = obra.transform.localScale;
        posicionInicial = obra.transform.position;
    }
    public void AumentarDimension()
    {
        obra.transform.localScale = obra.transform.localScale + new Vector3(0.01f, 0.01f, 0.01f);
    }
    public void DisminuirDimension()
    {
        obra.transform.localScale = obra.transform.localScale - new Vector3(0.01f, 0.01f, 0.01f);
    }
    public void RotarDerecha()
    {
        obra.transform.Rotate(new Vector3(0f, -1f, 0f));
    }
    public void RotarIzquierda()
    {
        obra.transform.Rotate(new Vector3(0f, 1f, 0f));
    }
    public void RotarAbajo()
    {
        obra.transform.Rotate(new Vector3(1f, 0f, 0f));
    }
    public void RotarArriba()
    {
        obra.transform.Rotate(new Vector3(-1f, 0f, 0f));
    }
    public void MoverArriba()
    {
        modelo3D.transform.Translate(new Vector3(0f, 0.01f, 0f));
    }
    public void MoverAbajo()
    {
        modelo3D.transform.Translate(new Vector3(0f, -0.01f, 0f));
    }
    public void Reset()
    {
        obra.transform.SetPositionAndRotation(posicionInicial, rotacionInicial);
        obra.transform.localScale = escalaInicial;
    }
}
