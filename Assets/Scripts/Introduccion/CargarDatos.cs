using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargarDatos : MonoBehaviour {

	public Text textoPrueba;
	void Start () {
		textoPrueba.text="Se logueo el usuario "+DatosUsuario.Instance.nombreUsuario+" con ID: "+DatosUsuario.Instance.idUsuario;
	}
}
