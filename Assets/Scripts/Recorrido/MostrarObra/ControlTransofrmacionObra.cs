using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTransofrmacionObra : MonoBehaviour
{

    private Transform transformacionInicialObra;
    private Transform transformacionVisualizacionObra;
    private bool esPintura;
    private void Start()
    {
    }
    public void transformarModoVisualizacion()
    {

        GameObject obra = ObraEnVisualizacion.Instance.obraSeleccionada;
        GameObject modeloObra = obra.transform.GetChild(0).gameObject;
        if (modeloObra.transform.childCount != 0)
        {
            esPintura = false;
            Debug.Log("Es escultura");
            modeloObra = modeloObra.transform.GetChild(0).gameObject;
        }
        else
        {
            esPintura = true;
            Debug.Log("Es pintura");
        }


        GameObject auxObra = new GameObject();
        auxObra.transform.localPosition = modeloObra.transform.localPosition;
        auxObra.transform.eulerAngles = modeloObra.transform.eulerAngles;
        auxObra.transform.localScale = modeloObra.transform.localScale;
        transformacionInicialObra = auxObra.transform;

        /* Vector3 aux=new Vector3();
		aux=auxObra.transform.localScale;
		transformacionInicialObra.localScale=new Vector3(aux.x,aux.y,aux.z);
		aux=auxObra.transform.localEulerAngles;
		transformacionInicialObra.localEulerAngles=new Vector3(aux.x,aux.y,aux.z);
		aux=auxObra.transform.localScale;
		transformacionInicialObra.localScale=new Vector3(aux.x,aux.y,aux.z);
 */

        if (esPintura)
        {
            modeloObra.transform.eulerAngles = new Vector3(90, 180, 0);
            modeloObra.transform.localScale = modeloObra.transform.localScale*4;
            modeloObra.transform.position = new Vector3(0, 0, -50);
        }
        else
        {
            //modeloObra.transform.eulerAngles = new Vector3(0, 0, 0);
            modeloObra.transform.localScale = modeloObra.transform.localScale*3;
            modeloObra.transform.position = new Vector3(0, 0, 0);
        }

    }

    public void transofmrarModoNormal()
    {

        GameObject obra = ObraEnVisualizacion.Instance.obraSeleccionada;
        GameObject modeloObra = obra.transform.GetChild(0).gameObject;
        if (modeloObra.transform.childCount != 0)
        {
            Debug.Log("Es escultura");
            modeloObra = modeloObra.transform.GetChild(0).gameObject;
        }
        else
        {
            Debug.Log("Es pintura");
        }
        modeloObra.transform.localPosition = transformacionInicialObra.localPosition;
        modeloObra.transform.eulerAngles = transformacionInicialObra.eulerAngles;
        modeloObra.transform.localScale = transformacionInicialObra.localScale;
    }
}
