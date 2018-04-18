using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlColisionAvatar : MonoBehaviour
{

    private bool esPrimeraVez;
    void Start()
    {
        esPrimeraVez = false;
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name != "Museo")
        {
            if (esPrimeraVez)
            {
                esPrimeraVez = false;
            }
            else
            {

                if (collider.gameObject.GetComponent<AbrirObra>() != null)
                {
                    collider.gameObject.GetComponent<AbrirObra>().abrirObra();
                    esPrimeraVez = true;
                }


            }
        }

    }
}
