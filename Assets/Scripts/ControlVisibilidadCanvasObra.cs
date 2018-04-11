using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVisibilidadCanvasObra : ControlVisibilidadCanvas
{

    public GameObject transformacionPanel;

    public void activarPanelTransformacion()
    {
        this.transformacionPanel.SetActive(true);
    }

    public void desactivarPanelTransformacion()
    {
        this.transformacionPanel.SetActive(false);
    }
}
