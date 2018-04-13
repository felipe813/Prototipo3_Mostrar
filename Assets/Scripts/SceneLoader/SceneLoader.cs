 using UnityEngine;
 using System.Collections;
 using UnityEngine.SceneManagement;
 
 public class SceneLoader: MonoBehaviour {
 
      public void LoadScene(string escena)
      { 
         //Application.LoadLevel(level);
		 SceneManager.LoadScene(escena);
       }
 }