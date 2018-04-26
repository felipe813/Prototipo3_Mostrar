using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementoMultimedia {

	private string _urlMultimedia;
	private string _nombreMultimedia;
	// Use this for initialization
	public ElementoMultimedia(string url,string nombre){
		_nombreMultimedia=nombre;
		_urlMultimedia=url;
	}
	public string urlMultimedia
    {
        get{return _urlMultimedia;}
        set{ _urlMultimedia=value;}
    }
	public string nombreMultimedia
    {
        get{return _nombreMultimedia;}
        set{ _nombreMultimedia=value;}
    }
}
