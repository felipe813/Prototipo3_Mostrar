using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamaras : MonoBehaviour
{
    public Camera camaraPrincipal;
    private Transform transformacion;
    public GameObject camaraContenedora;
    private Transform transformacionContenedora;
	private float segundosAnimacion;

    void Start()
    {
		GameObject aux=new GameObject();
        //aux.transform.position=camaraPrincipal.transform.position;
        aux.transform.position=new Vector3(0,0,0);
		//aux.transform.eulerAngles=camaraPrincipal.transform.eulerAngles;
        aux.transform.eulerAngles=new Vector3(0,0,0);
		transformacion=aux.transform;

		segundosAnimacion=1;

       /*  Debug.Log("Local");
        Debug.Log(camaraPrincipal.transform.localPosition);
        Debug.Log(camaraPrincipal.transform.localEulerAngles);
        Debug.Log("Global");
        Debug.Log(camaraPrincipal.transform.position);
        Debug.Log(camaraPrincipal.transform.eulerAngles); */
    }
    public void activarCamaraPrincipal()
    {
        //StartCoroutine(transladarCamaraAInicio2(this.camaraPrincipal.transform.localPosition, this.camaraPrincipal.transform.localEulerAngles,
        //transformacion.position, transformacion.eulerAngles));
        camaraPrincipal.transform.localEulerAngles=new Vector3(0,0,0);
        camaraPrincipal.transform.localPosition=new Vector3(0,0,0);
    }

    public void activarCamaraObra(Vector3 posicion, float anguloRotacionX, bool esPintura)
    {
        

        float distanciaCamaraAObra;
        Vector3 anguloRotacion = new Vector3(0, anguloRotacionX, 0);
        anguloRotacionX = (float)(anguloRotacionX * Mathf.PI / 180.0);
        Vector3 alturaCamara;
        if (esPintura)
        {
            alturaCamara = new Vector3(0f, 0f, 0f);
            distanciaCamaraAObra = -30f;
        }
        else
        {
            alturaCamara = new Vector3(0f, 18f, 0f);
            distanciaCamaraAObra = -60f;
        }
        Vector3 cambioPorAngulo = new Vector3(distanciaCamaraAObra * Mathf.Sin(anguloRotacionX), 0f, distanciaCamaraAObra * Mathf.Cos(anguloRotacionX));
        Vector3 posicionFinal = posicion + cambioPorAngulo + alturaCamara;
        StartCoroutine(transladarCamaraAObra(this.camaraPrincipal.transform.position, this.camaraPrincipal.transform.eulerAngles,
        posicionFinal, anguloRotacion));

		
    }

    private IEnumerator transladarCamaraAObra(Vector3 posInicial, Vector3 rotacionInicial, Vector3 posFinal, Vector3 rotacionFinal)
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

    private IEnumerator transladarCamaraAInicio(Vector3 posInicial, Vector3 rotacionInicial, Vector3 posFinal, Vector3 rotacionFinal)
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
			this.camaraPrincipal.transform.localPosition=this.camaraPrincipal.transform.localPosition+aumentoPos;
			this.camaraPrincipal.transform.localEulerAngles=this.camaraPrincipal.transform.localEulerAngles+aumentoRotacion;
			contador++;
			yield return new WaitForSeconds(segundosCambio);
		}
        yield return null;
    }

    private IEnumerator transladarCamaraAInicio2(Vector3 posInicial, Vector3 rotacionInicial, Vector3 posFinal, Vector3 rotacionFinal)
    {    /*    
         Debug.Log("Local");
        Debug.Log(camaraPrincipal.transform.localPosition);
        Debug.Log(camaraPrincipal.transform.localEulerAngles);
        Debug.Log("Global");
        Debug.Log(camaraPrincipal.transform.position);
        Debug.Log(camaraPrincipal.transform.eulerAngles); */
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
        /*  Debug.Log("Local");
        Debug.Log(camaraPrincipal.transform.localPosition);
        Debug.Log(camaraPrincipal.transform.localEulerAngles);
        Debug.Log("Global");
        Debug.Log(camaraPrincipal.transform.position);
        Debug.Log(camaraPrincipal.transform.eulerAngles); */

        /* camaraPrincipal.transform.localEulerAngles=new Vector3(0,0,0);
        camaraPrincipal.transform.localPosition=new Vector3(0,0,0); */
        yield return null;

    }
}
