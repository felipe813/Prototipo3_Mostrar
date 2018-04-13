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

	public int cantidadEsculturas(){
		int retorno = 0;
		for(int i=0;i<obras.Count;i++){
			if(obras[i].tipo.Equals("escultura")){
				retorno++;
			}
		}
		return retorno;
	}

	public int cantidadPinturas(){
		int retorno = 0;
		for(int i=0;i<obras.Count;i++){
			if(obras[i].tipo.Equals("pintura")){
				retorno++;
			}
		}
		return retorno;
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

	public void addPosicionObra(Vector3 posicion,float anguloRotacion,int index,string tipo){
		int contadorIndex = 0;
		for (int i = 0; i < obras.Count; i++)
		{
			if(obras[i].tipo.Equals(tipo)){
				if(contadorIndex==index){
					obras [i].posicion = posicion;
					obras [i].anguloRotacion = anguloRotacion;
				}
				contadorIndex++;
			}
		}
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