using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparacionEscenario : MonoBehaviour {
	void Start () {
		GameObject acomodarObras = GameObject.Find("AcomodarObras");
        AcomodarObras script = acomodarObras.GetComponent<AcomodarObras>();
        StartCoroutine(script.acomodarObras());
	}
}
