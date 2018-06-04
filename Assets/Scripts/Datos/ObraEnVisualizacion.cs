using System.Collections.Generic;
using UnityEngine;

public class ObraEnVisualizacion : Singleton<ObraEnVisualizacion>
{
	private GameObject _obraSeleccionada;

	 public static ObraEnVisualizacion Instance
    {
        get
        {
            return ((ObraEnVisualizacion)mInstance);
        }
        set
        {
            mInstance = value;
        }
    }

	public GameObject obraSeleccionada
    {
        get { return _obraSeleccionada; }
        set { _obraSeleccionada = value; }
    }
}
