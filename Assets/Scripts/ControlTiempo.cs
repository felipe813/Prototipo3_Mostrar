using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlTiempo : MonoBehaviour
{
    public Text txtTiempo;
    private int segundos;
    private int minutos;
    private int horas;
    private float _tiempo;
    private void Start()
    {
		segundos=-1;
    }
    void Update()
    {
        _tiempo += Time.deltaTime;
        if (segundos != (int)_tiempo)
        {
            segundos = (int)_tiempo;
            if (segundos >= 60)
            {
                minutos = segundos / 60;
                segundos = segundos % 60;
                if (minutos >= 60)
                {
                    horas = minutos / 60;
                }
            }
            txtTiempo.text = darFormato(segundos, minutos, horas);
        }
    }
    public int tiempo
    {
        get { return (int)_tiempo; }
        set { _tiempo = value; }
    }
    private string darFormato(int s, int m, int h)
    {
        string retorno = "";
        if (h < 10) retorno += "0";
        retorno += h.ToString() + ":";
        if (m < 10) retorno += "0";
        retorno += m.ToString() + ":";
        if (s < 10) retorno += "0";
        retorno += s.ToString();
        return retorno;
    }
}