using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamaras : MonoBehaviour
{
    public Camera camaraPrincipal;
    private Transform transformacion;

	private float segundosAnimacion;

    void Start()
    {
		GameObject aux=new GameObject();
        aux.transform.position=camaraPrincipal.transform.position;
		aux.transform.eulerAngles=camaraPrincipal.transform.eulerAngles;
		transformacion=aux.transform;

		segundosAnimacion=1;
    }
    public void activarCamaraPrincipal()
    {
        StartCoroutine(transladarCamara(this.camaraPrincipal.transform.position, this.camaraPrincipal.transform.eulerAngles,
        transformacion.position, transformacion.eulerAngles));
    }

    public void activarCamaraObra(Vector3 posicion, float anguloRotacionX, bool esPintura)
    {
        float distanciaCamaraAObra = -30f;
        Vector3 anguloRotacion = new Vector3(0, anguloRotacionX, 0);
        anguloRotacionX = (float)(anguloRotacionX * Mathf.PI / 180.0);
        Vector3 alturaCamara;
        if (esPintura)
        {
            alturaCamara = new Vector3(0f, 0f, 0f);
        }
        else
        {
            alturaCamara = new Vector3(0f, 9f, 0f);
        }
        Vector3 cambioPorAngulo = new Vector3(distanciaCamaraAObra * Mathf.Sin(anguloRotacionX), 0f, distanciaCamaraAObra * Mathf.Cos(anguloRotacionX));
        Vector3 posicionFinal = posicion + cambioPorAngulo + alturaCamara;
        StartCoroutine(transladarCamara(this.camaraPrincipal.transform.position, this.camaraPrincipal.transform.eulerAngles,
        posicionFinal, anguloRotacion));

		
    }

    private IEnumerator transladarCamara(Vector3 posInicial, Vector3 rotacionInicial, Vector3 posFinal, Vector3 rotacionFinal)
    {
		float segundosCambio=0.02f;
		int cantidadCambios=(int)(segundosAnimacion/segundosCambio);
		//posicion
		Vector3 diferenciaPosicion=posFinal-posInicial;
		Vector3 aumentoPos=diferenciaPosicion/cantidadCambios;
		//rotacion
		Vector3 diferenciaRotacion=rotacionFinal-rotacionInicial;
		Vector3 aumentoRotacion=diferenciaRotacion/cantidadCambios;
		int contador=0;
		while(contador<cantidadCambios){
			this.camaraPrincipal.transform.position=this.camaraPrincipal.transform.position+aumentoPos;
			this.camaraPrincipal.transform.eulerAngles=this.camaraPrincipal.transform.eulerAngles+aumentoRotacion;
			contador++;
			yield return new WaitForSeconds(segundosCambio);
		}
        yield return null;
    }
}
