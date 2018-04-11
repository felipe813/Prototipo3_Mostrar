using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CargarObras : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(cargar());
    }
    public IEnumerator cargar()
    {
        while (!DatosUsuario.Instance.datosCompletos)
        {
            yield return null;
        }
        int cantidadObras = DatosUsuario.Instance.cantidadObras();
        for (int i = 0; i < cantidadObras; i++)
        {
            StartCoroutine(MostrarObra(i));
        }
    }
    private IEnumerator MostrarObra(int index)
    {
        string url = DatosUsuario.Instance.obras[index].url;
        string tipo = DatosUsuario.Instance.obras[index].tipo;
        if (tipo.Equals("escultura"))
        {
            WWW www = new WWW(url);
            while (!www.isDone)
            {
                yield return null;
            }
            AssetBundle obra = www.assetBundle;
            GameObject mya = obra.LoadAsset("Obra") as GameObject;
            GameObject obraPresentada = Instantiate(mya);
            GameObject modelo3D = GameObject.Find("Modelo" + DatosUsuario.Instance.obras[index].id);
            GameObject obraPrincipal = modelo3D.transform.GetChild(0).gameObject;

            obraPrincipal.AddComponent<AbrirObra>();
            obraPrincipal.GetComponent<AbrirObra>().id = DatosUsuario.Instance.obras[index].id;
            obraPresentada.transform.position = DatosUsuario.Instance.obras[index].posicion;
            GameObject contenedorObra = GameObject.Find("Obras");
            obraPresentada.transform.parent = contenedorObra.transform;
            obraPresentada.transform.Rotate(Vector3.up, DatosUsuario.Instance.obras[index].anguloRotacion);
        }
        else if (tipo.Equals("pintura"))
        {
            GameObject cuadro = (GameObject)Resources.Load("Prefabs/Obra") as GameObject;
            GameObject obraPresentada = Instantiate(cuadro, transform);
            GameObject contenedorObra = GameObject.Find("Obras");
            obraPresentada.transform.parent = contenedorObra.transform;
            obraPresentada.transform.Rotate(Vector3.up, DatosUsuario.Instance.obras[index].anguloRotacion);
            obraPresentada.transform.position = DatosUsuario.Instance.obras[index].posicion;
            using (WWW www = new WWW(url))
            {
                yield return www;
                //GameObject marco = GameObject.Find("Cuadro");
				GameObject marco = obraPresentada.transform.Find("Cuadro").gameObject;
                marco.AddComponent<AbrirObra>();
                marco.GetComponent<AbrirObra>().id = DatosUsuario.Instance.obras[index].id;
                marco.GetComponent<Renderer>().material.mainTexture = www.texture;
            }
        }
    }
}
