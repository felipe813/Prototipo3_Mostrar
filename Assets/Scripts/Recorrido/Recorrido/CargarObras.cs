using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CargarObras : MonoBehaviour
{
    private int cantidadObrasCargadas;
    private int cantidadObras;

    private List<GameObject> obras;
    GameObject escenario;
    void Start()
    {
        obras=new List<GameObject>();
        escenario=GameObject.Find("Escenario");
        cantidadObrasCargadas = 0;
        StartCoroutine(cargar());
    }
    public IEnumerator cargar()
    {
        while (!DatosUsuario.Instance.datosCompletos)
        {
            yield return null;
        }
        cantidadObras = DatosUsuario.Instance.cantidadObras();
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

            //while (!Caching.ready)
            //    yield return null;

            //WWW www = WWW.LoadFromCacheOrDownload(url, 1);
            // yield return www;
            WWW www = new WWW(url);
            while (!www.isDone)
            {
                yield return null;
            }
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error + " : " + url);
                cantidadObras--;
                yield return null;
            }
            else
            {
                AssetBundle obra = www.assetBundle;
                GameObject mya = obra.LoadAsset("Obra") as GameObject;
                obra.Unload(false);
                GameObject obraPresentada = Instantiate(mya);
                obras.Add(obraPresentada);
                GameObject modelo3D = GameObject.Find("Modelo" + DatosUsuario.Instance.obras[index].id);
                // GameObject modelo3D = GameObject.Find("Modelo");

                GameObject obraPrincipal = modelo3D.transform.GetChild(0).gameObject;

                obraPrincipal.AddComponent<AbrirObra>();
                obraPrincipal.GetComponent<AbrirObra>().id = DatosUsuario.Instance.obras[index].id;
                obraPresentada.transform.position = DatosUsuario.Instance.obras[index].posicion;
                GameObject contenedorObra = GameObject.Find("Obras");
                obraPresentada.transform.parent = contenedorObra.transform;
                obraPresentada.transform.Rotate(Vector3.up, DatosUsuario.Instance.obras[index].anguloRotacion);
                obraPresentada.transform.localScale = new Vector3(2f, 2f, 2f);

                //GameObject.Find("EspacioObra").SetActive(false);

                cantidadObrasCargadas++;

            }
            if (cantidadObrasCargadas == cantidadObras)
            {

                GameObject.Find("NavMesh").GetComponent<NavMeshDinamico>().construirNav();
            }
            /* WWW www = new WWW(url);
            while (!www.isDone)
            {
                yield return null;
            } */
            /*  AssetBundle obra = www.assetBundle;
             GameObject mya = obra.LoadAsset("Obra") as GameObject;
             obra.Unload(false);
             GameObject obraPresentada = Instantiate(mya);
             GameObject modelo3D = GameObject.Find("Modelo" + DatosUsuario.Instance.obras[index].id);
             // GameObject modelo3D = GameObject.Find("Modelo");
             GameObject obraPrincipal = modelo3D.transform.GetChild(0).gameObject;

             obraPrincipal.AddComponent<AbrirObra>();
             obraPrincipal.GetComponent<AbrirObra>().id = DatosUsuario.Instance.obras[index].id;
             obraPresentada.transform.position = DatosUsuario.Instance.obras[index].posicion;
             GameObject contenedorObra = GameObject.Find("Obras");
             obraPresentada.transform.parent = contenedorObra.transform;
             obraPresentada.transform.Rotate(Vector3.up, DatosUsuario.Instance.obras[index].anguloRotacion);

             GameObject.Find("EspacioObra").SetActive(false);

             cantidadObrasCargadas++;
             if (cantidadObrasCargadas == cantidadObras)
             {
                 GameObject.Find("NavMesh").GetComponent<NavMeshDinamico>().construirNav();
             } */
        }
        else if (tipo.Equals("pintura"))
        {

            using (WWW www = new WWW(url))
            {
                yield return www;
                if (!string.IsNullOrEmpty(www.error))
                {
                    Debug.Log(www.error + " : " + url);
                    cantidadObras--;
                    yield return null;
                }
                else
                {

                    GameObject cuadro = (GameObject)Resources.Load("Prefabs/Obra") as GameObject;
                    GameObject obraPresentada = Instantiate(cuadro, transform);
                    obras.Add(obraPresentada);
                    GameObject contenedorObra = GameObject.Find("Obras");
                    obraPresentada.transform.parent = contenedorObra.transform;
                    obraPresentada.transform.Rotate(Vector3.up, DatosUsuario.Instance.obras[index].anguloRotacion);
                    obraPresentada.transform.position = DatosUsuario.Instance.obras[index].posicion;

                    //GameObject marco = GameObject.Find("Cuadro");
                    GameObject marco = obraPresentada.transform.Find("Cuadro").gameObject;
                    marco.AddComponent<AbrirObra>();
                    //Debug.Log ("Se le agrego a el cuadro "+DatosUsuario.Instance.obras[index].id+" el script.");
                    marco.GetComponent<AbrirObra>().id = DatosUsuario.Instance.obras[index].id;
                    marco.GetComponent<Renderer>().material.mainTexture = www.texture;
                    cantidadObrasCargadas++;

                }
                if (cantidadObrasCargadas == cantidadObras)
                {
                    GameObject.Find("NavMesh").GetComponent<NavMeshDinamico>().construirNav();
                    GameObject contenedorObra = GameObject.Find("ImageTarget");
                    GameObject Escenario = GameObject.Find("Escenario");
                    Escenario.transform.parent = contenedorObra.transform;
                }
            }
        }
    }

    public void ActivarObras(){
        escenario.SetActive(true);
        for (int i = 0; i < obras.Count; i++)
        {
            obras[i].gameObject.SetActive(true);
        }
    }
}
