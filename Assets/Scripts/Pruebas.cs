using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        string direccionLocalEsculturas = "C:/Users/AndresFelipe/Documents/ProyectosTesis/ProyectosUnity/Prototipo3_Creacion/AssetBundles/StandaloneWindows/";
        //string direccionWebEsculturas = "ftp://pruebarealidadaumentada:contrasenia@files.000webhost.com/Prototipo_3/Esculturas/";
        string direccionLocalPinturas = "C:/Users/AndresFelipe/Desktop/RecursosObras/Pinturas/";
        //string direccionWebPinturas = "ftp://pruebarealidadaumentada:contrasenia@files.000webhost.com/Prototipo_3/Pinturas/";
        string direccionEsculturas = direccionLocalEsculturas;
        string dreccionPinturas = direccionLocalPinturas;

        DatosUsuario.Instance.nombreUsuario = "Andrés Sánchez";
        DatosUsuario.Instance.idUsuario = "123";
        DatosUsuario.Instance.obras = new List<Obra>();

        Obra obra = new Obra("Amphitrite", "5");
        obra.calificada = false;
        obra.url = direccionEsculturas + "obra5";
        obra.tipo = "escultura";
        obra.audios.Add(new ElementoMultimedia("Audio1", "Audios 1"));
        obra.videos.Add(new ElementoMultimedia("Video1", "Video 1"));
        obra.audios.Add(new ElementoMultimedia("Audio2", "Audios 2"));
        obra.informacion.informacion.Add(new DetalleInformacion());
        obra.informacion.informacion.Add(new DetalleInformacion());
        obra.informacion.informacion.Add(new DetalleInformacion());
        obra.informacion.informacion.Add(new DetalleInformacion());
        obra.informacion.informacion.Add(new DetalleInformacion());
        obra.informacion.informacion[0].encabezado = "Autor";
        obra.informacion.informacion[0].datos.Add("Leonadro da Vinci");
        obra.informacion.informacion[1].encabezado = "Descripcion";
        obra.informacion.informacion[1].datos.Add("El Retrato de Lisa Gherardini, esposa de Francesco del Giocondo, más conocido como La Gioconda (La Joconde en francés), o"
        +" Mona Lisa, es una obra pictórica del pintor renacentista italiano Leonardo da Vinci. Fue adquirida por el rey Francisco I de Francia a principios del siglo XVI "
        +"y desde entonces es propiedad del Estado Francés. Se exhibe en el Museo del Louvre de París.");
        obra.informacion.informacion[2].encabezado = "Fecha de creacion";
        obra.informacion.informacion[2].datos.Add("1503");
        obra.informacion.informacion[4].encabezado = "Técnica";
        obra.informacion.informacion[4].datos.Add("Óleo sobre tabla de álamo");
        obra.informacion.informacion[3].encabezado = "Estilo";
        obra.informacion.informacion[3].datos.Add("Renacimiento");
        obra.informacion.informacion[3].datos.Add("Barroco");
        obra.informacion.informacion[3].datos.Add("Cubismo");
        DatosUsuario.Instance.obras.Add(obra);
        obra = new Obra("Gioconda", "100");
        obra.url = dreccionPinturas + "La Gioconda.jpg";
        obra.tipo = "pintura";

        obra.informacion.informacion.Add(new DetalleInformacion());
        obra.informacion.informacion.Add(new DetalleInformacion());
        obra.informacion.informacion.Add(new DetalleInformacion());
        obra.informacion.informacion.Add(new DetalleInformacion());
        obra.informacion.informacion[0].encabezado = "Autor";
        obra.informacion.informacion[0].datos.Add("Leonadro da Vinci");
        obra.informacion.informacion[1].encabezado = "Fecha de creacion";
        obra.informacion.informacion[1].datos.Add("1503");
        obra.informacion.informacion[2].encabezado = "Técnica";
        obra.informacion.informacion[2].datos.Add("Óleo sobre tabla de álamo");
        obra.informacion.informacion[3].encabezado = "Estilo";
        obra.informacion.informacion[3].datos.Add("Renacimiento");
        obra.informacion.informacion[3].datos.Add("Barroco");
        obra.informacion.informacion[3].datos.Add("Cubismo");

        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("El Beso", "101");
        obra.url = dreccionPinturas + "El beso.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("La joven de la perla", "102");
        obra.url = dreccionPinturas + "La joven de la perla.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("La noche estrellada", "103");
        obra.url = dreccionPinturas + "La noche estrellada.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("Los tres musicos", "104");
        obra.url = dreccionPinturas + "Los tres musicos.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("Gótico estadounidense", "105");
        obra.url = dreccionPinturas + "Gótico estadounidense.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("Retrato del artista sin barba", "106");
        obra.url = dreccionPinturas + "Retrato del artista sin barba.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("Un domingo por la tarde en la isla de La Grande Jatte", "107");
        obra.url = dreccionPinturas + "Un domingo por la tarde en la isla de La Grande Jatte.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("La persistencia de la memoria", "108");
        obra.url = dreccionPinturas + "La persistencia de la memoria.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("El hijo del hombre", "109");
        obra.url = dreccionPinturas + "El hijo del hombre.jpg";
        obra.tipo = "pintura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("Borghese vase", "4");
        obra.url = direccionEsculturas + "obra4";
        obra.tipo = "escultura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("Borghese vase", "4");
        obra.url = direccionEsculturas + "obra4";
        obra.tipo = "escultura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("Borghese vase", "4");
        obra.url = direccionEsculturas + "obra4";
        obra.tipo = "escultura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("Borghese vase", "4");
        obra.url = direccionEsculturas + "obra4";
        obra.tipo = "escultura";
        DatosUsuario.Instance.obras.Add(obra);

        obra = new Obra("Borghese vase", "4");
        obra.url = direccionEsculturas + "obra4";
        obra.tipo = "escultura";
        DatosUsuario.Instance.obras.Add(obra);

        GameObject acomodarObras = GameObject.Find("AcomodarObras");
        AcomodarObras script = acomodarObras.GetComponent<AcomodarObras>();
        StartCoroutine(script.acomodarObras());

    }
}
