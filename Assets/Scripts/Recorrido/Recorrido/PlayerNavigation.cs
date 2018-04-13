using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerNavigation : MonoBehaviour {
	public Camera cam;
	public NavMeshAgent navMeshAgent;
	void Start () {
	}	void Update () {
		navMeshAgent.GetComponent<Animator>().SetFloat("velocidad",navMeshAgent.velocity.magnitude);
		if(Input.GetKeyDown(KeyCode.Mouse0) && cam.isActiveAndEnabled){
			Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit)){
				navMeshAgent.SetDestination(hit.point);	
			}
		}
	} 
}
