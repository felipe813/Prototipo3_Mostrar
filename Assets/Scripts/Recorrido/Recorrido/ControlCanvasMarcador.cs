using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCanvasMarcador : MonoBehaviour
{

    public GameObject canvas;

    public void activarCanvas()
    {
        canvas.SetActive(true);
    }

    public void desactivarCanvas()
    {
        canvas.SetActive(false);
    }
}
