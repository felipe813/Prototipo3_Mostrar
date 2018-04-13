using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlCalificacion : MonoBehaviour
{
    public GameObject estrella1;
    public GameObject estrella2;
    public GameObject estrella3;
    public GameObject estrella4;
    public GameObject estrella5;
    public Sprite calificacion;
    private int _nota;
    public void calificacion0()
    {
        estrella1.GetComponent<Image>().sprite = calificacion;
        estrella2.GetComponent<Image>().sprite = calificacion;
        estrella3.GetComponent<Image>().sprite = calificacion;
        estrella4.GetComponent<Image>().sprite = calificacion;
        estrella5.GetComponent<Image>().sprite = calificacion;
    }
    public void calificacion1(Sprite valor)
    {
        calificacion0();
        if (_nota == 1)
        {
            _nota = 0;
        }
        else
        {
            estrella1.GetComponent<Image>().sprite = valor;
            _nota = 1;
        }
    }
    public void calificacion2(Sprite valor)
    {
        calificacion0();
        if (_nota == 2)
        {
            _nota = 0;
        }
        else
        {
            estrella1.GetComponent<Image>().sprite = valor;
            estrella2.GetComponent<Image>().sprite = valor;
            _nota = 2;
        }
    }
    public void calificacion3(Sprite valor)
    {
        calificacion0();
        if (_nota == 3)
        {
            _nota = 0;
        }
        else
        {
            estrella1.GetComponent<Image>().sprite = valor;
            estrella2.GetComponent<Image>().sprite = valor;
            estrella3.GetComponent<Image>().sprite = valor;
            _nota = 3;
        }
    }
    public void calificacion4(Sprite valor)
    {
        calificacion0();
        if (_nota == 4)
        {
            _nota = 0;
        }
        else
        {
            estrella1.GetComponent<Image>().sprite = valor;
            estrella2.GetComponent<Image>().sprite = valor;
            estrella3.GetComponent<Image>().sprite = valor;
            estrella4.GetComponent<Image>().sprite = valor;
            _nota = 4;
        }
    }
    public void calificacion5(Sprite valor)
    {
        if (_nota == 5)
        {
            calificacion0();
            _nota = 0;
        }
        else
        {
            estrella1.GetComponent<Image>().sprite = valor;
            estrella2.GetComponent<Image>().sprite = valor;
            estrella3.GetComponent<Image>().sprite = valor;
            estrella4.GetComponent<Image>().sprite = valor;
            estrella5.GetComponent<Image>().sprite = valor;
            _nota = 5;
        }
    }
    public int nota
    {
        get { return _nota; }
        set { _nota = value; }
    }
}