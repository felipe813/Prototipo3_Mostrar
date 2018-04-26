using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Obra
{
    private string _nombre;
    private int _id;
    private int _calificacion;
    private int _tiempoSegundos;
    private bool _calificada;
    private bool _favorita;
    private string _url;
    private Vector3 _posicion;
    private string _tipo;
    private float _anguloRotacion;
    private int _idObraRecorrido;

    private List<ElementoMultimedia> _videos;
    private List<ElementoMultimedia> _audios;
    private Informacion _informacion;
    public Obra(string nuevoNombre, int nuevoId)
    {
        _nombre = nuevoNombre;
        _id = nuevoId;
        _calificada = false;
        _videos = new List<ElementoMultimedia>();
        _audios = new List<ElementoMultimedia>();
        _informacion=new Informacion();
    }
    public int id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }
    public int calificacion
    {
        get { return _calificacion; }
        set { _calificacion = value; }
    }
    public int tiempoSegundos
    {
        get { return _tiempoSegundos; }
        set { _tiempoSegundos = value; }
    }
    public bool calificada
    {
        get { return _calificada; }
        set { _calificada = value; }
    }

    public string url
    {
        get { return _url; }
        set { _url = value; }
    }

    public bool favorita
    {
        get { return _favorita; }
        set { _favorita = value; }
    }
    public Vector3 posicion
    {
        get { return _posicion; }
        set { _posicion = value; }
    }
    public string tipo
    {
        get { return _tipo; }
        set { _tipo = value; }
    }
    public float anguloRotacion
    {
        get { return _anguloRotacion; }
        set { _anguloRotacion = value; }
    }
    public List<ElementoMultimedia> audios
    {
        get { return _audios; }
        set { _audios = value; }
    }
    public List<ElementoMultimedia> videos
    {
        get { return _videos; }
        set { _videos = value; }
    }
    public int idObraRecorrido
    {
        get { return _idObraRecorrido; }
        set { _idObraRecorrido = value; }
    }

    public Informacion informacion{
         get { return _informacion; }
        set { _informacion = value; }
    }
}
