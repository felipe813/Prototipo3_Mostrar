﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcomodarObras : MonoBehaviour
{
    public GameObject planoInferior;
    public GameObject planoSuperior;
    private Vector3[] verticesPlanoInferior;
    private Vector3[] verticesPlanoSuperior;
    private int cantidadPinturas;
    private int cantidadEsculturas;
    private int altopinturas;
	private bool creacionCompleta;
    // Use this for initialization
    //2.....0
    //
    //3.....1
    void Start()
    {
		creacionCompleta=false;
        Vector3 posicionPlanoInferior = planoInferior.transform.position;
        Vector3 escalaPlanoInferior = planoInferior.transform.localScale * 10;
        verticesPlanoInferior = new Vector3[4];
        verticesPlanoInferior[0] = new Vector3(posicionPlanoInferior.x + escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z + escalaPlanoInferior.z / 2);
        verticesPlanoInferior[1] = new Vector3(posicionPlanoInferior.x + escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z - escalaPlanoInferior.z / 2);
        verticesPlanoInferior[2] = new Vector3(posicionPlanoInferior.x - escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z + escalaPlanoInferior.z / 2);
        verticesPlanoInferior[3] = new Vector3(posicionPlanoInferior.x - escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z - escalaPlanoInferior.z / 2);

        Vector3 posicionPlanoSuperior = planoSuperior.transform.position;
        Vector3 escalaPlanoSuperior = planoSuperior.transform.localScale * 10;
        verticesPlanoSuperior = new Vector3[4];
        verticesPlanoSuperior[0] = new Vector3(posicionPlanoSuperior.x + escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z + escalaPlanoSuperior.z / 2);
		verticesPlanoSuperior[1] = new Vector3(posicionPlanoSuperior.x + escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z - escalaPlanoSuperior.z / 2);
        verticesPlanoSuperior[2] = new Vector3(posicionPlanoSuperior.x - escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z + escalaPlanoSuperior.z / 2);
        verticesPlanoSuperior[3] = new Vector3(posicionPlanoSuperior.x - escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z - escalaPlanoSuperior.z / 2);
	
		creacionCompleta=true;
	}

    public IEnumerator acomodarObras()
    {
		while( !creacionCompleta){
			yield return null;
		}
        cantidadPinturas = DatosUsuario.Instance.cantidadPinturas();
        cantidadEsculturas = DatosUsuario.Instance.cantidadEsculturas();

        altopinturas = 14;
        Vector3[] medio=new Vector3[10];
        switch (cantidadPinturas)
        {
            case 1:
				// Si hay una pintura se pone arriba
				medio[0]=puntoMedioX(verticesPlanoSuperior[0], verticesPlanoSuperior[2]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x,medio[0].y+altopinturas,medio[0].z), 0f, 0, "pintura");
                break;
            case 2:
				// Si hay dos pinturas se pone una arriba y otra abajo
                medio[0]=puntoMedioX(verticesPlanoSuperior[0], verticesPlanoSuperior[2]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x,medio[0].y+altopinturas,medio[0].z), 0f, 0, "pintura");
				
				medio[1]=puntoMedioX(verticesPlanoInferior[0], verticesPlanoInferior[2]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x,medio[1].y+altopinturas,medio[1].z), 0f, 1, "pintura");
                break;
			case 3:
				medio[0]=puntoMedioZ(verticesPlanoSuperior[0], verticesPlanoSuperior[1]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x,medio[0].y+altopinturas,medio[0].z), 90f, 0, "pintura");
				
				medio[1]=puntoMedioZ(verticesPlanoSuperior[2], verticesPlanoSuperior[3]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x,medio[1].y+altopinturas,medio[1].z), -90f, 1, "pintura");

				medio[2]=puntoMedioX(verticesPlanoInferior[0], verticesPlanoInferior[2]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x,medio[2].y+altopinturas,medio[2].z), 0f, 2, "pintura");
				break;
            default:
                break;
        }

        Vector3[] medioE=new Vector3[10];
        switch (cantidadEsculturas)
        {
            case 1:
				// Si hay una escultura se pone abajo
				medioE[0]=puntoMedio(verticesPlanoInferior);
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");
                break;
            default:
                break;
        }
		DatosUsuario.Instance.datosCompletos=true;
		
    }

    private Vector3 puntoMedioX(Vector3 vertice2, Vector3 vertice0)
    {
        return new Vector3((vertice2.x + vertice0.x) / 2, vertice0.y, vertice0.z);
    }

    private Vector3 puntoMedioZ(Vector3 vertice0, Vector3 vertice1)
    {
        return new Vector3(vertice0.x, vertice0.y, (vertice1.z + vertice0.z) / 2);
    }

    private Vector3 puntoMedio(Vector3[] vertices)
    {
        return new Vector3((vertices[0].x + vertices[2].x) / 2, vertices[0].y, (vertices[0].z + vertices[1].z) / 2);
    }

}