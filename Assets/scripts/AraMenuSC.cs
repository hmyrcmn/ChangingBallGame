using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AraMenuSC : MonoBehaviour
{
   
  public void goMainMenu(string sceneName){
        // MEVCUT SAHNEYİ YUÜKLER:
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadSceneAsync(sceneName) ;
    }

  
    
}
