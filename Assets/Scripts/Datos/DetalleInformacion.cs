using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///
public class DetalleInformacion {
///
	private string _encabezado;
	private List<string> _datos;
    ///
	public string encabezado
    {
        get { return _encabezado; }
        set { _encabezado = value; }
    }


	public List<string> datos
    {
        get { return _datos; }
        set { _datos = value; }
    }

}
