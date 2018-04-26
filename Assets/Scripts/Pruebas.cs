using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        string direccionLocalEsculturas = "C:/Users/AndresFelipe/Documents/ProyectosTesis/ProyectosUnity/Prototipo3_Creacion/AssetBundles/StandaloneWindows/";
        string direccionWebEsculturas = "ftp://pruebarealidadaumentada:contrasenia@files.000webhost.com/Prototipo_3/Esculturas/";
        string direccionLocalPinturas = "C:/Users/AndresFelipe/Desktop/RecursosObras/Pinturas/";
        string direccionWebPinturas = "ftp://pruebarealidadaumentada:contrasenia@files.000webhost.com/Prototipo_3/Pinturas/";
        string direccionEsculturas = direccionLocalEsculturas;
        string dreccionPinturas = direccionLocalPinturas;

        DatosUsuario.Instance.nombreUsuario = "Andrés Sánchez";
        DatosUsuario.Instance.idUsuario = "123";
        DatosUsuario.Instance.obras = new List<Obra>();

        Obra obra = new Obra("Amphitrite", 5);
        obra.calificada = false;
        obra.url = direccionEsculturas + "obra5";
        obra.tipo = "escultura";
        obra.audios.Add(new ElementoMultimedia("Audio1", "Audios 1"));
        obra.videos.Add(new ElementoMultimedia("Video1", "Video 1"));
        obra.audios.Add(new ElementoMultimedia("Audio2", "Audios 2"));
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("Gioconda", 100);
        obra.url = dreccionPinturas + "La Gioconda.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("El Beso", 101);
        obra.url = dreccionPinturas + "El beso.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("La joven de la perla", 102);
        obra.url = dreccionPinturas + "La joven de la perla.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("La noche estrellada", 103);
        obra.url = dreccionPinturas + "La noche estrellada.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("Los tres musicos", 104);
        obra.url = dreccionPinturas + "Los tres musicos.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("Gótico estadounidense", 105);
        obra.url = dreccionPinturas + "Gótico estadounidense.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("Retrato del artista sin barba", 106);
        obra.url = dreccionPinturas + "Retrato del artista sin barba.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("Un domingo por la tarde en la isla de La Grande Jatte", 107);
        obra.url = dreccionPinturas + "Un domingo por la tarde en la isla de La Grande Jatte.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("La persistencia de la memoria", 108);
        obra.url = dreccionPinturas + "La persistencia de la memoria.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("El hijo del hombre", 109);
        obra.url = dreccionPinturas + "El hijo del hombre.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);


        obra = new Obra("Borghese vase", 4);
        obra.url = direccionEsculturas + "obra4";
        obra.tipo = "escultura";
        DatosUsuario.Instance.obras.Add(obra);

        GameObject acomodarObras = GameObject.Find("AcomodarObras");
        AcomodarObras script = acomodarObras.GetComponent<AcomodarObras>();
        StartCoroutine(script.acomodarObras());

    }
}
