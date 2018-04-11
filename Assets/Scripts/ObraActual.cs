using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObraActual : Singleton<ObraActual>
{

	public int idObraActual=0;

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
