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
    // Inferior
    //2.....0
    //4     5
    //
    //3.....1
    // Superior
    //2.....0
    //      
    //4     5
    //3.....1
    void Start()
    {
        creacionCompleta = false;
        Vector3 posicionPlanoInferior = planoInferior.transform.position;
        Vector3 escalaPlanoInferior = planoInferior.transform.localScale * 10;
        verticesPlanoInferior = new Vector3[6];
        verticesPlanoInferior[0] = new Vector3(posicionPlanoInferior.x + escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z + escalaPlanoInferior.z / 2);
        verticesPlanoInferior[1] = new Vector3(posicionPlanoInferior.x + escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z - escalaPlanoInferior.z / 2);
        verticesPlanoInferior[2] = new Vector3(posicionPlanoInferior.x - escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z + escalaPlanoInferior.z / 2);
        verticesPlanoInferior[3] = new Vector3(posicionPlanoInferior.x - escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z - escalaPlanoInferior.z / 2);
        verticesPlanoInferior[4] = new Vector3(posicionPlanoInferior.x - escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z + escalaPlanoInferior.z / 6);
        verticesPlanoInferior[5] = new Vector3(posicionPlanoInferior.x + escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z + escalaPlanoInferior.z / 6);

        Vector3 posicionPlanoSuperior = planoSuperior.transform.position;
        Vector3 escalaPlanoSuperior = planoSuperior.transform.localScale * 10;
        verticesPlanoSuperior = new Vector3[6];
        verticesPlanoSuperior[0] = new Vector3(posicionPlanoSuperior.x + escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z + escalaPlanoSuperior.z / 2);
        verticesPlanoSuperior[1] = new Vector3(posicionPlanoSuperior.x + escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z - escalaPlanoSuperior.z / 2);
        verticesPlanoSuperior[2] = new Vector3(posicionPlanoSuperior.x - escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z + escalaPlanoSuperior.z / 2);
        verticesPlanoSuperior[3] = new Vector3(posicionPlanoSuperior.x - escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z - escalaPlanoSuperior.z / 2);
        verticesPlanoSuperior[4] = new Vector3(posicionPlanoSuperior.x - escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z - escalaPlanoSuperior.z / 6);
        verticesPlanoSuperior[5] = new Vector3(posicionPlanoSuperior.x + escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z - escalaPlanoSuperior.z / 6);

        creacionCompleta = true;
    }

    public IEnumerator acomodarObras()
    {
        while (!creacionCompleta)
        {
            yield return null;
        }
        cantidadPinturas = DatosUsuario.Instance.cantidadPinturas();
        cantidadEsculturas = DatosUsuario.Instance.cantidadEsculturas();

        altopinturas = 14;
        Vector3[] medio = new Vector3[10];
        switch (cantidadPinturas)
        {
            case 1:
                // Si hay una pintura se pone arriba
                medio[0] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[2]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 0f, 0, "pintura");
                break;
            case 2:
                // Si hay dos pinturas se pone una arriba y otra abajo
                medio[0] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[2]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 0f, 0, "pintura");

                medio[1] = puntoMedio(verticesPlanoInferior[2], verticesPlanoInferior[0]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), 0f, 1, "pintura");
                break;
            case 3:
                medio[0] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[5]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[4]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), -90f, 1, "pintura");

                medio[2] = puntoMedio(verticesPlanoInferior[2], verticesPlanoInferior[0]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), 0f, 2, "pintura");
                break;
            case 4:
                medio[0] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[5]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[4]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), -90f, 1, "pintura");

                medio[2] = puntoMedio(verticesPlanoInferior[5], verticesPlanoInferior[1]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), 90f, 2, "pintura");

                medio[3] = puntoMedio(verticesPlanoInferior[4], verticesPlanoInferior[3]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[3].x, medio[3].y + altopinturas, medio[3].z), -90f, 3, "pintura");
                break;
            case 5:
                medio[0] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[5]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[4]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), -90f, 1, "pintura");

                medio[2] = puntoMedio(verticesPlanoInferior[5], verticesPlanoInferior[1]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), 90f, 2, "pintura");

                medio[3] = puntoMedio(verticesPlanoInferior[4], verticesPlanoInferior[3]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[3].x, medio[3].y + altopinturas, medio[3].z), -90f, 3, "pintura");

                medio[4] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[2]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[4].x, medio[4].y + altopinturas, medio[4].z), 0f, 4, "pintura");
                break;
            case 6:
                medio[0] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[5]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[4]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), -90f, 1, "pintura");

                medio[2] = puntoMedio(verticesPlanoInferior[5], verticesPlanoInferior[1]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), 90f, 2, "pintura");

                medio[3] = puntoMedio(verticesPlanoInferior[4], verticesPlanoInferior[3]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[3].x, medio[3].y + altopinturas, medio[3].z), -90f, 3, "pintura");

                medio[4] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[2]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[4].x, medio[4].y + altopinturas, medio[4].z), 0f, 4, "pintura");

                medio[5] = puntoMedio(verticesPlanoInferior[2], verticesPlanoInferior[0]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[5].x, medio[5].y + altopinturas, medio[5].z), 0f, 5, "pintura");

                break;
            case 7:
                medio[0] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[5]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[4]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), -90f, 1, "pintura");

                medio[2] = puntoMedio(verticesPlanoInferior[5], verticesPlanoInferior[1]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), 90f, 2, "pintura");

                medio[3] = puntoMedio(verticesPlanoInferior[4], verticesPlanoInferior[3]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[3].x, medio[3].y + altopinturas, medio[3].z), -90f, 3, "pintura");

                Vector3 aux = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[2]);

                medio[4] = puntoMedio(verticesPlanoSuperior[0], aux);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[4].x, medio[4].y + altopinturas, medio[4].z), 0f, 4, "pintura");

                medio[5] = puntoMedio(verticesPlanoInferior[2], verticesPlanoInferior[0]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[5].x, medio[5].y + altopinturas, medio[5].z), 0f, 5, "pintura");

                medio[6] = puntoMedio(aux, verticesPlanoSuperior[2]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[6].x, medio[6].y + altopinturas, medio[6].z), 0f, 6, "pintura");
                break;
            case 8:
                medio[0] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[5]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[4]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), -90f, 1, "pintura");

                medio[2] = puntoMedio(verticesPlanoInferior[5], verticesPlanoInferior[1]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), 90f, 2, "pintura");

                medio[3] = puntoMedio(verticesPlanoInferior[4], verticesPlanoInferior[3]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[3].x, medio[3].y + altopinturas, medio[3].z), -90f, 3, "pintura");

                Vector3 aux2 = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[2]);
                Vector3 aux3 = puntoMedio(verticesPlanoInferior[2], verticesPlanoInferior[0]);

                medio[4] = puntoMedio(verticesPlanoSuperior[0], aux2);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[4].x, medio[4].y + altopinturas, medio[4].z), 0f, 4, "pintura");

                medio[5] = puntoMedio(verticesPlanoInferior[0], aux3);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[5].x, medio[5].y + altopinturas, medio[5].z), 0f, 5, "pintura");

                medio[6] = puntoMedio(aux2, verticesPlanoSuperior[2]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[6].x, medio[6].y + altopinturas, medio[6].z), 0f, 6, "pintura");

                medio[7] = puntoMedio(aux3, verticesPlanoInferior[2]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[7].x, medio[7].y + altopinturas, medio[7].z), 0f, 7, "pintura");
                break;
            case 9:

                Vector3 aux4 = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[5]);
                Vector3 aux5 = puntoMedio(verticesPlanoSuperior[4], verticesPlanoSuperior[2]);
                Vector3 aux6 = puntoMedio(verticesPlanoInferior[2], verticesPlanoInferior[0]);

                medio[0] = puntoMedio(verticesPlanoSuperior[0], aux4);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = puntoMedio(aux4, verticesPlanoSuperior[5]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), 90f, 1, "pintura");

                medio[2] = puntoMedio(verticesPlanoSuperior[2], aux5);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), -90f, 2, "pintura");

                medio[3] = puntoMedio(aux5, verticesPlanoSuperior[4]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[3].x, medio[3].y + altopinturas, medio[3].z), -90f, 3, "pintura");

                medio[4] = puntoMedio(verticesPlanoInferior[5], verticesPlanoInferior[1]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[4].x, medio[4].y + altopinturas, medio[4].z), 90f, 4, "pintura");

                medio[5] = puntoMedio(verticesPlanoInferior[4], verticesPlanoInferior[3]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[5].x, medio[5].y + altopinturas, medio[5].z), -90f, 5, "pintura");

                medio[6] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[2]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[6].x, medio[6].y + altopinturas, medio[6].z), 0f, 6, "pintura");

                medio[7] = puntoMedio(verticesPlanoInferior[0], aux6);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[7].x, medio[7].y + altopinturas, medio[7].z), 0f, 7, "pintura");

                medio[8] = puntoMedio(aux6, verticesPlanoInferior[2]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[8].x, medio[8].y + altopinturas, medio[8].z), 0f, 8, "pintura");
                break;
            case 10:
                Vector3 aux7 = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[5]);
                Vector3 aux8 = puntoMedio(verticesPlanoSuperior[4], verticesPlanoSuperior[2]);
                Vector3 aux9 = puntoMedio(verticesPlanoInferior[5], verticesPlanoInferior[1]);
                Vector3 aux10 = puntoMedio(verticesPlanoInferior[4], verticesPlanoInferior[3]);

                medio[0] = puntoMedio(verticesPlanoSuperior[0], aux7);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = puntoMedio(aux7, verticesPlanoSuperior[5]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), 90f, 1, "pintura");

                medio[2] = puntoMedio(verticesPlanoSuperior[2], aux8);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), -90f, 2, "pintura");

                medio[3] = puntoMedio(aux8, verticesPlanoSuperior[4]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[3].x, medio[3].y + altopinturas, medio[3].z), -90f, 3, "pintura");

                medio[4] = puntoMedio(verticesPlanoInferior[5], aux9);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[4].x, medio[4].y + altopinturas, medio[4].z), 90f, 4, "pintura");

                medio[5] = puntoMedio(aux9, verticesPlanoInferior[1]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[5].x, medio[5].y + altopinturas, medio[5].z), 90f, 5, "pintura");


                medio[6] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[2]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[6].x, medio[6].y + altopinturas, medio[6].z), 0f, 6, "pintura");

                medio[7] = puntoMedio(verticesPlanoInferior[4], aux10);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[7].x, medio[7].y + altopinturas, medio[7].z), -90f, 7, "pintura");

                medio[8] = puntoMedio(aux10, verticesPlanoInferior[3]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[8].x, medio[8].y + altopinturas, medio[8].z), -90f, 8, "pintura");

                medio[9] = puntoMedio(verticesPlanoInferior[2], verticesPlanoInferior[0]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[9].x, medio[9].y + altopinturas, medio[9].z), 0f, 9, "pintura");

                break;
            default:
                break;
        }

        Vector3[] medioE = new Vector3[10];
        switch (cantidadEsculturas)
        {
            case 1:
                // Si hay una escultura se pone abajo
                medioE[0] = puntoMedio(verticesPlanoInferior);
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");
                break;
            case 2:
                medioE[0] = puntoMedio(verticesPlanoInferior);
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");

                medioE[1] = puntoMedio(verticesPlanoSuperior);
                DatosUsuario.Instance.addPosicionObra(medioE[1], 0f, 1, "escultura");
                break;
            case 3:
                Vector3 aux1 = puntoMedio(verticesPlanoInferior[2], verticesPlanoInferior[1]);

                medioE[0] = puntoMedio(verticesPlanoInferior[2], aux1);
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");

                medioE[1] = puntoMedio(verticesPlanoInferior[1], aux1);
                DatosUsuario.Instance.addPosicionObra(medioE[1], 0f, 1, "escultura");

                medioE[2] = puntoMedio(verticesPlanoSuperior);
                DatosUsuario.Instance.addPosicionObra(medioE[2], 0f, 2, "escultura");
                break;
            case 4:
                Vector3 aux2 = puntoMedio(verticesPlanoInferior[2], verticesPlanoInferior[1]);
                Vector3 aux3 = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[3]);

                medioE[0] = puntoMedio(verticesPlanoInferior[2], aux2);
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");

                medioE[1] = puntoMedio(verticesPlanoInferior[1], aux2);
                DatosUsuario.Instance.addPosicionObra(medioE[1], 0f, 1, "escultura");

                medioE[2] = puntoMedio(verticesPlanoSuperior[0], aux3);
                DatosUsuario.Instance.addPosicionObra(medioE[2], 0f, 2, "escultura");

                medioE[3] = puntoMedio(verticesPlanoSuperior[3], aux3);
                DatosUsuario.Instance.addPosicionObra(medioE[3], 0f, 3, "escultura");
                break;
            case 5:
                Vector3 aux4 = puntoMedio(verticesPlanoInferior[2], verticesPlanoInferior[1]);
                Vector3 aux5 = puntoMedio(verticesPlanoInferior[0], verticesPlanoInferior[2]);
                Vector3 aux6 = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[3]);

                medioE[0] = puntoMedio(aux4, aux5);
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");

                medioE[1] = puntoMedio(verticesPlanoInferior[1], aux4);
                DatosUsuario.Instance.addPosicionObra(medioE[1], 0f, 1, "escultura");

                medioE[2] = puntoMedio(verticesPlanoInferior[3], aux4);
                DatosUsuario.Instance.addPosicionObra(medioE[2], 0f, 2, "escultura");

                medioE[3] = puntoMedio(verticesPlanoSuperior[3], aux6);
                DatosUsuario.Instance.addPosicionObra(medioE[3], 0f, 3, "escultura");

                medioE[4] = puntoMedio(verticesPlanoSuperior[0], aux6);
                DatosUsuario.Instance.addPosicionObra(medioE[4], 0f, 4, "escultura");
                break;
            case 6:
                Vector3 aux7 = puntoMedio(verticesPlanoInferior[2], verticesPlanoInferior[1]);
                Vector3 aux8 = puntoMedio(verticesPlanoInferior[0], verticesPlanoInferior[2]);
                Vector3 aux9 = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[1]);
                Vector3 aux10 = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[2]);

                medioE[0] = puntoMedio(aux7, aux8);
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");

                medioE[1] = puntoMedio(verticesPlanoInferior[1], aux7);
                DatosUsuario.Instance.addPosicionObra(medioE[1], 0f, 1, "escultura");

                medioE[2] = puntoMedio(verticesPlanoInferior[3], aux7);
                DatosUsuario.Instance.addPosicionObra(medioE[2], 0f, 2, "escultura");

                medioE[3] = puntoMedio(aux9, aux10);
                DatosUsuario.Instance.addPosicionObra(medioE[3], 0f, 3, "escultura");

                medioE[4] = puntoMedio(verticesPlanoSuperior[1], aux9);
                DatosUsuario.Instance.addPosicionObra(medioE[4], 0f, 4, "escultura");

                medioE[5] = puntoMedio(verticesPlanoSuperior[3], aux9);
                DatosUsuario.Instance.addPosicionObra(medioE[5], 0f, 5, "escultura");
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            default:
                break;
        }
        DatosUsuario.Instance.datosCompletos = true;

    }

    private Vector3 puntoMedio(Vector3[] vertices)
    {
        return new Vector3((vertices[0].x + vertices[2].x) / 2, vertices[0].y, (vertices[0].z + vertices[1].z) / 2);
    }

    private Vector3 puntoMedio(Vector3 vertice2, Vector3 vertice1)
    {
        //Punto medio vertices diagonal
        return new Vector3((vertice2.x + vertice1.x) / 2, (vertice2.y + vertice1.y) / 2, (vertice2.z + vertice1.z) / 2);
    }

}
