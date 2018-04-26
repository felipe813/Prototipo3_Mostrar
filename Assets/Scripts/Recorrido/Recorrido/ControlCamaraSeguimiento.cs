using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamaraSeguimiento : MonoBehaviour
{
	public bool activar;
    public Camera camaraPrincipal;
    public GameObject avatar;
    private bool _seguirPersonaje;
	private Vector3 distanciaCamara;
	private Vector3 rotacionCamara;
    void Start()
    {
		distanciaCamara=new Vector3(0,60,-60);
        //distanciaCamara=new Vector3(0,120,-120);
		rotacionCamara=new Vector3(24,0,0);
        _seguirPersonaje = true;
    }
    void Update()
    {
        if (_seguirPersonaje&&activar)
        {
			Vector3 rotacionAvatar=avatar.transform.eulerAngles;
			float anguloRotacionY = (float)(rotacionAvatar.y * Mathf.PI / 180.0);
			Vector3 cambioPorAngulo = new Vector3(distanciaCamara.z * Mathf.Sin(anguloRotacionY), distanciaCamara.y, distanciaCamara.z * Mathf.Cos(anguloRotacionY));
			camaraPrincipal.transform.position=avatar.transform.position+cambioPorAngulo;
			camaraPrincipal.transform.eulerAngles=avatar.transform.eulerAngles+rotacionCamara;
			
			//_seguirPersonaje=false;
        }
    }

    public bool seguirPersonaje
    {
        set { _seguirPersonaje = value; }
        get { return _seguirPersonaje; }
    }
}
