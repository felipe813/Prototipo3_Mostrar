using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlColisionAvatar : MonoBehaviour
{

    private bool esPrimeraVez;
    private bool estaEnColision;
    void Start()
    {
        esPrimeraVez = false;
        estaEnColision = false;
    }
    void Update()
    {

    }
    void OnTriggerStay(Collider collider)
    {
        //Debug.Log("Está en colision con " + collider.name);
        
        PlayerNavigation script = GameObject.Find("ControlMovimiento").GetComponent<PlayerNavigation>();
       /*  Debug.Log("VARIABLES");
        Debug.Log("Esta en movimiento "+script.estaEnMovimiento());
        Debug.Log("Se movio "+script.seMovio);
        Debug.Log("En colision "+estaEnColision);
        Debug.Log("Es primera vez "+esPrimeraVez); */
        if (!script.estaEnMovimiento()&&script.seMovio)
        {
            //Debug.Log("Entró en una colision valida");
            if (!estaEnColision)
            {
                if (collider.gameObject.tag != "Museo")
                {
                    
                    if (esPrimeraVez)
                    {
                        esPrimeraVez = false;
                        //Debug.Log("Es primera vez");
                    }
                    else
                    {
                        //Debug.Log("No es primera vez");
                        if (collider.gameObject.GetComponent<AbrirObra>() != null)
                        {
                            Debug.Log("Entro a abrir obra ..........................................");
                            estaEnColision = true;
                            //Debug.Log("Es a un objeto Abrir Obra");
                            collider.gameObject.GetComponent<AbrirObra>().abrirObra();

                            esPrimeraVez = true;

                            //Esconder Escenario y obras
                            GameObject.Find("Escenario").SetActive(false);
                            GameObject obras = GameObject.Find("Obras");
                            for (int i = 0; i < obras.transform.childCount; i++)
                            {
                                GameObject obra = obras.transform.GetChild(i).gameObject;
                                if (obra.name != "UI"){                             
                                    if (obra.transform.GetChild(0).transform.position != collider.gameObject.transform.position)
                                    //if (obra.transform.GetChild(0).GetInstanceID()!=(collider.gameObject).GetInstanceID())
                                    {
                                        if (obra.transform.GetChild(0).childCount != 0)
                                        {
                                            if (obra.transform.GetChild(0).transform.GetChild(0).transform.position != collider.gameObject.transform.position)
                                            //if (obra.transform.GetChild(0).transform.GetChild(0).GetInstanceID()!=(collider.gameObject).GetInstanceID())
                                            {
                                                obra.SetActive(false);
                                            }
                                            else{
                                                ObraEnVisualizacion.Instance.obraSeleccionada=obra;
                                                Debug.Log("Encontró obra con nombre "+obra.name);
                                                script.seMovio=false;
                                                estaEnColision=false;
                                            }
                                        }
                                        else
                                        {
                                            obra.SetActive(false);
                                        }
                                    }else{
                                        ObraEnVisualizacion.Instance.obraSeleccionada=obra;
                                        script.seMovio=false;
                                        estaEnColision=false;
                                        Debug.Log("Encontró obra con nombre "+obra.name);
                                    }
                                }
                            }
                            
                        }
                    }
                }

            }
        }
    }
    /* void OnTriggerEnter(Collider collider)
    {
        PlayerNavigation script = GameObject.Find("ControlMovimiento").GetComponent<PlayerNavigation>();
        if (!script.estaEnMovimiento())
        {
            Debug.Log("Estrello con " + collider.name);
            if (collider.gameObject.tag != "Museo")
            {

                if (esPrimeraVez)
                {
                    esPrimeraVez = false;
                    Debug.Log("Es primera vez");
                }
                else
                {
                    Debug.Log("No es primera vez");
                    if (collider.gameObject.GetComponent<AbrirObra>() != null)
                    {
                        Debug.Log("Es a un objeto Abrir Obra");
                        collider.gameObject.GetComponent<AbrirObra>().abrirObra();

                        esPrimeraVez = true;

                        //Esconder Escenario y obras
                        GameObject.Find("Escenario").SetActive(false);
                        GameObject obras = GameObject.Find("Obras");
                        for (int i = 0; i < obras.transform.childCount; i++)
                        {
                            GameObject obra = obras.transform.GetChild(i).gameObject;
                            if (obra.name != "UI")
                            {
                                if (obra.transform.GetChild(0).transform.position != collider.gameObject.transform.position)
                                //if (obra.transform.GetChild(0).GetInstanceID()!=(collider.gameObject).GetInstanceID())
                                {
                                    if (obra.transform.GetChild(0).childCount != 0)
                                    {
                                        if (obra.transform.GetChild(0).transform.GetChild(0).transform.position != collider.gameObject.transform.position)
                                        //if (obra.transform.GetChild(0).transform.GetChild(0).GetInstanceID()!=(collider.gameObject).GetInstanceID())
                                        {
                                            obra.SetActive(false);
                                        }
                                    }
                                    else
                                    {
                                        obra.SetActive(false);
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
    } */
}
