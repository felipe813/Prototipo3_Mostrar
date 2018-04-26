using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshDinamico : MonoBehaviour
{

    public NavMeshSurface museo;
    public void construirNav()
    {
        museo.BuildNavMesh();
        GameObject.Find("RamplaIzquierdaSuperior").SetActive(false);
        GameObject.Find("RamplaIzquierdaInferior").SetActive(false);
        GameObject.Find("RamplaDerechaSuperior").SetActive(false);
        GameObject.Find("RamplaDerechaInferior").SetActive(false);
         GameObject espacioObra=GameObject.Find("EspacioObra");
        while(espacioObra!=null){
            espacioObra.SetActive(false);
            espacioObra=GameObject.Find("EspacioObra");
        } 
    }
}
