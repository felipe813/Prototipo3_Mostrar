using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObraActual : Singleton<ObraActual>
{

	public string idObraActual="";

    public static ObraActual Instance
	{
    	get
    	{
        	return ((ObraActual)mInstance);
    	}
    	set
    	{
        	mInstance = value;
    	}
	}
}
