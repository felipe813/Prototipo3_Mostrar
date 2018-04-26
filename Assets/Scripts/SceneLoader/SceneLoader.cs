 using UnityEngine;
 using System.Collections;
 using UnityEngine.SceneManagement;
 
 public static class SceneLoader {
 
      public static void LoadScene(string escena)
      { 
         //Application.LoadLevel(level);
		 SceneManager.LoadScene(escena);
       }
 }