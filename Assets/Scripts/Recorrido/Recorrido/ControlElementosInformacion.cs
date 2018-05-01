using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlElementosInformacion
{


    public static string getInformacion(Informacion informacion)
    {
        string retorno = "";
		if(informacion.cantidadDetalles()==0){
			retorno="<size=40><color=white><b> No existe información para mostrar de esta obra.</b></color></size>";
		}
        for (int i = 0; i < informacion.cantidadDetalles(); i++)
        {
            retorno += "<size=40><color=white><b>" + informacion.informacion[i].encabezado + "</b></color></size>\n";
            for (int j = 0; j < informacion.informacion[i].datos.Count; j++)
            {
                if (informacion.informacion[i].datos.Count > 1)
                {
                    retorno += "<size=30>     " + "- "+informacion.informacion[i].datos[j] + "</size>";
                }
                else
                {
                    retorno += "<size=30>     " + informacion.informacion[i].datos[j] + "</size>";
                }
                if (i != informacion.cantidadDetalles() - 1 || j != informacion.informacion[i].datos.Count - 1)
                {
                    retorno += "\n";
                }
            }
        }
        return retorno;
    }
}
