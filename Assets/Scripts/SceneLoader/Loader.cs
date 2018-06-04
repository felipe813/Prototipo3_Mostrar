using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

	public GameObject canvasLoader;
 
	public void LoadLevel(string nombreEscena)
	{
		Debug.Log(nombreEscena);
		canvasLoader.SetActive(true);
		StartCoroutine (LoadAsynchronously (nombreEscena));
	}

	IEnumerator LoadAsynchronously (string nombreEscena)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync (nombreEscena);


		while (!operation.isDone) 
		{
			Debug.Log("Cargando "+operation.progress*100+" %");
			yield return null;
		}
	} 
}
