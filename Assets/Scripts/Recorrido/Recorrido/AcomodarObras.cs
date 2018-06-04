using System.Collections;
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
    /*  
     0 * * 1 * * 2
     * * * * * * *
     3 * * * * * 4
     5 * * 6 * * 7
     8 * * * * * 9
     * * * * * * *
    10 * *11 * *12 
    */
    void Start()
    {
        creacionCompleta = false;
        Vector3 posicionPlanoInferior = planoInferior.transform.position;
        Vector3 escalaPlanoInferior = planoInferior.transform.localScale * 10;
        verticesPlanoInferior = new Vector3[13];
        verticesPlanoInferior[0] = new Vector3(posicionPlanoInferior.x - escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z + escalaPlanoInferior.z / 2);
        verticesPlanoInferior[2] = new Vector3(posicionPlanoInferior.x + escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z + escalaPlanoInferior.z / 2);
        verticesPlanoInferior[1] = puntoMedio(verticesPlanoInferior[0], verticesPlanoInferior[2]);
        verticesPlanoInferior[3] = new Vector3(posicionPlanoInferior.x - escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z + escalaPlanoInferior.z / 6);
        verticesPlanoInferior[4] = new Vector3(posicionPlanoInferior.x + escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z + escalaPlanoInferior.z / 6);
        verticesPlanoInferior[12] = new Vector3(posicionPlanoInferior.x + escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z - escalaPlanoInferior.z / 2);
        verticesPlanoInferior[10] = new Vector3(posicionPlanoInferior.x - escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z - escalaPlanoInferior.z / 2);
        verticesPlanoInferior[11] = puntoMedio(verticesPlanoInferior[10], verticesPlanoInferior[12]);
        verticesPlanoInferior[5] = puntoMedio(verticesPlanoInferior[10], verticesPlanoInferior[0]);
        verticesPlanoInferior[7] = puntoMedio(verticesPlanoInferior[2], verticesPlanoInferior[12]);
        verticesPlanoInferior[6] = puntoMedio(verticesPlanoInferior[0], verticesPlanoInferior[12]);
        verticesPlanoInferior[8] = new Vector3(posicionPlanoInferior.x - escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z - escalaPlanoInferior.z / 6);
        verticesPlanoInferior[9] = new Vector3(posicionPlanoInferior.x + escalaPlanoInferior.x / 2, posicionPlanoInferior.y, posicionPlanoInferior.z - escalaPlanoInferior.z / 6);

        Vector3 posicionPlanoSuperior = planoSuperior.transform.position;
        Vector3 escalaPlanoSuperior = planoSuperior.transform.localScale * 10;
        verticesPlanoSuperior = new Vector3[13];
        verticesPlanoSuperior[0] = new Vector3(posicionPlanoSuperior.x - escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z + escalaPlanoSuperior.z / 2);
        verticesPlanoSuperior[2] = new Vector3(posicionPlanoSuperior.x + escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z + escalaPlanoSuperior.z / 2);
        verticesPlanoSuperior[1] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[2]);
        verticesPlanoSuperior[3] = new Vector3(posicionPlanoSuperior.x - escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z + escalaPlanoSuperior.z / 6);
        verticesPlanoSuperior[4] = new Vector3(posicionPlanoSuperior.x + escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z + escalaPlanoSuperior.z / 6);
        verticesPlanoSuperior[12] = new Vector3(posicionPlanoSuperior.x + escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z - escalaPlanoSuperior.z / 2);
        verticesPlanoSuperior[10] = new Vector3(posicionPlanoSuperior.x - escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z - escalaPlanoSuperior.z / 2);
        verticesPlanoSuperior[11] = puntoMedio(verticesPlanoSuperior[10], verticesPlanoSuperior[12]);
        verticesPlanoSuperior[5] = puntoMedio(verticesPlanoSuperior[10], verticesPlanoSuperior[0]);
        verticesPlanoSuperior[7] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[12]);
        verticesPlanoSuperior[6] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[12]);
        verticesPlanoSuperior[8] = new Vector3(posicionPlanoSuperior.x - escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z - escalaPlanoSuperior.z / 6);
        verticesPlanoSuperior[9] = new Vector3(posicionPlanoSuperior.x + escalaPlanoSuperior.x / 2, posicionPlanoSuperior.y, posicionPlanoSuperior.z - escalaPlanoSuperior.z / 6);

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

        altopinturas = 18;
        Vector3[] medio = new Vector3[10];
        switch (cantidadPinturas)
        {
            case 1:
                // Si hay una pintura se pone arriba
                medio[0] = verticesPlanoSuperior[1];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 0f, 0, "pintura");
                break;
            case 2:
                // Si hay dos pinturas se pone una arriba y otra abajo
                medio[0] = verticesPlanoSuperior[1];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 0f, 0, "pintura");

                medio[1] = verticesPlanoInferior[1];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), 0f, 1, "pintura");
                break;
            case 3:
                medio[0] = verticesPlanoSuperior[4];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = verticesPlanoSuperior[3];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), -90f, 1, "pintura");

                medio[2] = verticesPlanoInferior[1];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), 0f, 2, "pintura");
                break;
            case 4:
                medio[0] = verticesPlanoSuperior[4];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = verticesPlanoSuperior[3];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), -90f, 1, "pintura");

                medio[2] = verticesPlanoInferior[9];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), 90f, 2, "pintura");

                medio[3] = verticesPlanoInferior[8];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[3].x, medio[3].y + altopinturas, medio[3].z), -90f, 3, "pintura");
                break;
            case 5:
                medio[0] = verticesPlanoSuperior[4];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = verticesPlanoSuperior[3];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), -90f, 1, "pintura");

                medio[2] = verticesPlanoInferior[9];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), 90f, 2, "pintura");

                medio[3] = verticesPlanoInferior[8];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[3].x, medio[3].y + altopinturas, medio[3].z), -90f, 3, "pintura");

                medio[4] = verticesPlanoSuperior[1];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[4].x, medio[4].y + altopinturas, medio[4].z), 0f, 4, "pintura");
                break;
            case 6:
                medio[0] = verticesPlanoSuperior[4];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = verticesPlanoSuperior[3];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), -90f, 1, "pintura");

                medio[2] = verticesPlanoInferior[9];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), 90f, 2, "pintura");

                medio[3] = verticesPlanoInferior[8];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[3].x, medio[3].y + altopinturas, medio[3].z), -90f, 3, "pintura");

                medio[4] = verticesPlanoSuperior[1];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[4].x, medio[4].y + altopinturas, medio[4].z), 0f, 4, "pintura");

                medio[5] = verticesPlanoInferior[1];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[5].x, medio[5].y + altopinturas, medio[5].z), 0f, 5, "pintura");

                break;
            case 7:
                medio[0] = verticesPlanoSuperior[4];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = verticesPlanoSuperior[3];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), -90f, 1, "pintura");

                medio[2] = verticesPlanoInferior[9];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), 90f, 2, "pintura");

                medio[3] = verticesPlanoInferior[8];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[3].x, medio[3].y + altopinturas, medio[3].z), -90f, 3, "pintura");



                medio[4] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[1]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[4].x, medio[4].y + altopinturas, medio[4].z), 0f, 4, "pintura");

                medio[5] = verticesPlanoInferior[1];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[5].x, medio[5].y + altopinturas, medio[5].z), 0f, 5, "pintura");

                medio[6] = puntoMedio(verticesPlanoSuperior[1], verticesPlanoSuperior[0]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[6].x, medio[6].y + altopinturas, medio[6].z), 0f, 6, "pintura");
                break;
            case 8:
                medio[0] = verticesPlanoSuperior[4];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = verticesPlanoSuperior[3];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), -90f, 1, "pintura");

                medio[2] = verticesPlanoInferior[9];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), 90f, 2, "pintura");

                medio[3] = verticesPlanoInferior[8];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[3].x, medio[3].y + altopinturas, medio[3].z), -90f, 3, "pintura");

                medio[4] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[1]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[4].x, medio[4].y + altopinturas, medio[4].z), 0f, 4, "pintura");

                medio[5] = puntoMedio(verticesPlanoInferior[2], verticesPlanoInferior[1]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[5].x, medio[5].y + altopinturas, medio[5].z), 0f, 5, "pintura");

                medio[6] = puntoMedio(verticesPlanoSuperior[1], verticesPlanoSuperior[0]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[6].x, medio[6].y + altopinturas, medio[6].z), 0f, 6, "pintura");

                medio[7] = puntoMedio(verticesPlanoInferior[1], verticesPlanoInferior[0]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[7].x, medio[7].y + altopinturas, medio[7].z), 0f, 7, "pintura");
                break;
            case 9:

                medio[0] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[4]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = verticesPlanoSuperior[7];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), 90f, 1, "pintura");

                medio[2] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[3]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), -90f, 2, "pintura");

                medio[3] = verticesPlanoSuperior[5];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[3].x, medio[3].y + altopinturas, medio[3].z), -90f, 3, "pintura");

                medio[4] = verticesPlanoInferior[9];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[4].x, medio[4].y + altopinturas, medio[4].z), 90f, 4, "pintura");

                medio[5] = verticesPlanoInferior[8];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[5].x, medio[5].y + altopinturas, medio[5].z), -90f, 5, "pintura");

                medio[6] = verticesPlanoSuperior[1];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[6].x, medio[6].y + altopinturas, medio[6].z), 0f, 6, "pintura");

                medio[7] = puntoMedio(verticesPlanoInferior[2], verticesPlanoInferior[1]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[7].x, medio[7].y + altopinturas, medio[7].z), 0f, 7, "pintura");

                medio[8] = puntoMedio(verticesPlanoInferior[1], verticesPlanoInferior[0]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[8].x, medio[8].y + altopinturas, medio[8].z), 0f, 8, "pintura");
                break;
            case 10:

                medio[0] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[4]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[0].x, medio[0].y + altopinturas, medio[0].z), 90f, 0, "pintura");

                medio[1] = verticesPlanoSuperior[7];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[1].x, medio[1].y + altopinturas, medio[1].z), 90f, 1, "pintura");

                medio[2] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[3]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[2].x, medio[2].y + altopinturas, medio[2].z), -90f, 2, "pintura");

                medio[3] = verticesPlanoSuperior[5];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[3].x, medio[3].y + altopinturas, medio[3].z), -90f, 3, "pintura");

                medio[4] = verticesPlanoInferior[7];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[4].x, medio[4].y + altopinturas, medio[4].z), 90f, 4, "pintura");

                medio[5] = puntoMedio(verticesPlanoInferior[9], verticesPlanoInferior[12]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[5].x, medio[5].y + altopinturas, medio[5].z), 90f, 5, "pintura");

                medio[6] = verticesPlanoSuperior[1];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[6].x, medio[6].y + altopinturas, medio[6].z), 0f, 6, "pintura");

                medio[7] = verticesPlanoInferior[5];
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[7].x, medio[7].y + altopinturas, medio[7].z), -90f, 7, "pintura");

                medio[8] = puntoMedio(verticesPlanoInferior[8], verticesPlanoInferior[10]);
                DatosUsuario.Instance.addPosicionObra(new Vector3(medio[8].x, medio[8].y + altopinturas, medio[8].z), -90f, 8, "pintura");

                medio[9] = verticesPlanoInferior[1];
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

                medioE[0] = puntoMedio(verticesPlanoInferior[0], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");

                medioE[1] = puntoMedio(verticesPlanoInferior[12], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[1], 0f, 1, "escultura");

                medioE[2] = puntoMedio(verticesPlanoSuperior);
                DatosUsuario.Instance.addPosicionObra(medioE[2], 0f, 2, "escultura");
                break;
            case 4:

                medioE[0] = puntoMedio(verticesPlanoInferior[0], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");

                medioE[1] = puntoMedio(verticesPlanoInferior[12], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[1], 0f, 1, "escultura");

                medioE[2] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[2], 0f, 2, "escultura");

                medioE[3] = puntoMedio(verticesPlanoSuperior[10], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[3], 0f, 3, "escultura");
                break;
            case 5:

                medioE[0] = verticesPlanoInferior[6];
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");

                medioE[1] = puntoMedio(verticesPlanoInferior[12], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[1], 0f, 1, "escultura");

                medioE[2] = puntoMedio(verticesPlanoInferior[10], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[2], 0f, 2, "escultura");

                medioE[3] = puntoMedio(verticesPlanoSuperior[10], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[3], 0f, 3, "escultura");

                medioE[4] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[4], 0f, 4, "escultura");
                break;
            case 6:

                medioE[0] = verticesPlanoInferior[6];
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");

                medioE[1] = puntoMedio(verticesPlanoInferior[12], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[1], 0f, 1, "escultura");

                medioE[2] = puntoMedio(verticesPlanoInferior[10], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[2], 0f, 2, "escultura");

                medioE[3] = puntoMedio(verticesPlanoSuperior[6], verticesPlanoSuperior[11]);
                DatosUsuario.Instance.addPosicionObra(medioE[3], 0f, 3, "escultura");

                medioE[4] = puntoMedio(verticesPlanoSuperior[0], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[4], 0f, 4, "escultura");

                medioE[5] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[5], 0f, 5, "escultura");
                break;
            case 7:
                medioE[0] = puntoMedio(verticesPlanoInferior[6], verticesPlanoInferior[3]);
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");

                medioE[1] = puntoMedio(verticesPlanoInferior[12], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[1], 0f, 1, "escultura");

                medioE[2] = puntoMedio(verticesPlanoInferior[10], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[2], 0f, 2, "escultura");

                medioE[3] = puntoMedio(verticesPlanoInferior[4], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[3], 0f, 3, "escultura");

                medioE[4] = puntoMedio(verticesPlanoSuperior[6], verticesPlanoSuperior[1]);
                DatosUsuario.Instance.addPosicionObra(medioE[4], 0f, 4, "escultura");

                medioE[5] = puntoMedio(verticesPlanoSuperior[8], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[5], 0f, 5, "escultura");

                medioE[6] = puntoMedio(verticesPlanoSuperior[9], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[6], 0f, 6, "escultura");
                break;
            case 8:
                medioE[0] = puntoMedio(verticesPlanoInferior[6], verticesPlanoInferior[3]);
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");

                medioE[1] = puntoMedio(verticesPlanoInferior[12], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[1], 0f, 1, "escultura");

                medioE[2] = puntoMedio(verticesPlanoInferior[10], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[2], 0f, 2, "escultura");

                medioE[3] = puntoMedio(verticesPlanoInferior[4], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[3], 0f, 3, "escultura");

                medioE[4] = puntoMedio(verticesPlanoSuperior[6], verticesPlanoSuperior[0]);
                DatosUsuario.Instance.addPosicionObra(medioE[4], 0f, 4, "escultura");

                medioE[5] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[5], 0f, 5, "escultura");

                medioE[6] = puntoMedio(verticesPlanoSuperior[8], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[6], 0f, 6, "escultura");

                medioE[7] = puntoMedio(verticesPlanoSuperior[9], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[7], 0f, 7, "escultura");
                break;
            case 9:
                medioE[0] = puntoMedio(verticesPlanoInferior[6], verticesPlanoInferior[2]);
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");

                medioE[1] = puntoMedio(verticesPlanoInferior[12], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[1], 0f, 1, "escultura");

                medioE[2] = puntoMedio(verticesPlanoInferior[10], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[2], 0f, 2, "escultura");

                medioE[3] = puntoMedio(verticesPlanoInferior[0], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[3], 0f, 3, "escultura");

                medioE[4] = puntoMedio(verticesPlanoSuperior[6], verticesPlanoSuperior[0]);
                DatosUsuario.Instance.addPosicionObra(medioE[4], 0f, 4, "escultura");

                medioE[5] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[5], 0f, 5, "escultura");

                medioE[6] = puntoMedio(verticesPlanoSuperior[8], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[6], 0f, 6, "escultura");

                medioE[7] = puntoMedio(verticesPlanoSuperior[9], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[7], 0f, 7, "escultura");

                medioE[8] = verticesPlanoInferior[6];
                DatosUsuario.Instance.addPosicionObra(medioE[8], 0f, 8, "escultura");
                break;
            case 10:
                medioE[0] = puntoMedio(verticesPlanoInferior[6], verticesPlanoInferior[2]);
                DatosUsuario.Instance.addPosicionObra(medioE[0], 0f, 0, "escultura");

                medioE[1] = puntoMedio(verticesPlanoInferior[12], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[1], 0f, 1, "escultura");

                medioE[2] = puntoMedio(verticesPlanoInferior[10], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[2], 0f, 2, "escultura");

                medioE[3] = puntoMedio(verticesPlanoInferior[0], verticesPlanoInferior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[3], 0f, 3, "escultura");

                medioE[4] = puntoMedio(verticesPlanoSuperior[6], verticesPlanoSuperior[0]);
                DatosUsuario.Instance.addPosicionObra(medioE[4], 0f, 4, "escultura");

                medioE[5] = puntoMedio(verticesPlanoSuperior[2], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[5], 0f, 5, "escultura");

                medioE[6] = puntoMedio(verticesPlanoSuperior[10], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[6], 0f, 6, "escultura");

                medioE[7] = puntoMedio(verticesPlanoSuperior[12], verticesPlanoSuperior[6]);
                DatosUsuario.Instance.addPosicionObra(medioE[7], 0f, 7, "escultura");

                medioE[8] = verticesPlanoInferior[6];
                DatosUsuario.Instance.addPosicionObra(medioE[8], 0f, 8, "escultura");

                medioE[9] = verticesPlanoSuperior[6];
                DatosUsuario.Instance.addPosicionObra(medioE[9], 0f, 9, "escultura");
                break;
            default:
                break;
        }
        DatosUsuario.Instance.datosCompletos = true;

    }

    private Vector3 puntoMedio(Vector3[] vertices)
    {
        return puntoMedio(vertices[0], vertices[12]);
        //return new Vector3((vertices[0].x + vertices[2].x) / 2, vertices[0].y, (vertices[0].z + vertices[1].z) / 2);
    }

    private Vector3 puntoMedio(Vector3 vertice2, Vector3 vertice1)
    {
        //Punto medio vertices diagonal
        return new Vector3((vertice2.x + vertice1.x) / 2, (vertice2.y + vertice1.y) / 2, (vertice2.z + vertice1.z) / 2);
    }

}
