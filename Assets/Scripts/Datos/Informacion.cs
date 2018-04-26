using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informacion {

	private List<DetalleInformacion> _informaion;
	public Informacion(){
		_informaion=new List<DetalleInformacion>();
	}
	public List<DetalleInformacion> informacion {
		get { return _informaion; }
        set { _informaion = value; }
	}

}
