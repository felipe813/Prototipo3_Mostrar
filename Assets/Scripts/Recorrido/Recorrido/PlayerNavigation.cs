using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerNavigation : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent navMeshAgent;
    public bool seMovio;
    private bool seClickeo;

    private Vector3 posicionAnterior;
    void Start()
    {
        seMovio = false;
        seClickeo=false;
        posicionAnterior = navMeshAgent.transform.localPosition;
    }
    void Update()
    {
        navMeshAgent.GetComponent<Animator>().SetFloat("velocidad", navMeshAgent.velocity.magnitude);
        if (Input.GetKeyDown(KeyCode.Mouse0) && cam.isActiveAndEnabled)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                navMeshAgent.SetDestination(hit.point);
                seClickeo=true;

            }
        }
//		Debug.Log("Posiciones: "+navMeshAgent.transform.localPosition+" -- "+posicionAnterior);
        if (navMeshAgent.transform.localPosition != posicionAnterior&& seClickeo)
        {
       //     Debug.Log("Se cambio se movio");
            seMovio = true;
            seClickeo=false;
            Debug.Log("SE MOVIO PASO A TRUE");
        }
		posicionAnterior=navMeshAgent.transform.localPosition;

    }

    public bool estaEnMovimiento()
    {
        //Debug.Log("VELOCIDAD : " + navMeshAgent.velocity);
        if (navMeshAgent.velocity.x + navMeshAgent.velocity.y + navMeshAgent.velocity.z == 0)
        {
            //Debug.Log("Retorno no está  en movimiento");
            return false;
        }
        return true;
    }


}
