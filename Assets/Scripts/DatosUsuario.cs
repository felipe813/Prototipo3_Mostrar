using System.Collections.Generic;
using UnityEngine;
public class DatosUsuario : Singleton<DatosUsuario>
{
    public string idUsuario;
    public string nombreUsuario;
    public List<Obra> obras;
    public bool datosCompletos;
    public static DatosUsuario Instance
    {
        get
        {
            return ((DatosUsuario)mInstance);
        }
        set
        {
            mInstance = value;
        }
    }
    public int cantidadObras(){
        return obras.Count;
    }
    public Obra buscarObra(int idObra){
        Obra retorno=null;
        for (int i = 0; i < obras.Count; i++)
        {
            Debug.Log("Comparo "+obras[i].id+" con "+idObra);
            if(obras[i].id==idObra){
                retorno=obras[i];
                break;
            }
        }
        return retorno;
    }
    protected DatosUsuario() { }
    // Método para hacer una impresion en consola de los datos de todas las obras de un usuaio para un recorrido.
	public void ImprimirDatosObras()
    {
        for (int i = 0; i < obras.Count; i++)
        {
            Debug.Log("La obra No "+obras[i].id+" llamada <"+obras[i].nombre+"> tiene una calificación de "
			+obras[i].calificacion+", su estado de calificacion es "+obras[i].calificada+" y se ha visto por "+
            obras[i].tiempoSegundos+" segundos.");
        }
    }
}