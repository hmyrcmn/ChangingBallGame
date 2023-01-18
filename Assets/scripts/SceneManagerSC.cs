using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerSC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoNextLevel();
    }
    void GoNextLevel(){
         PlayerPrefs.GetInt("playerScore");
         if(PlayerPrefs.GetInt("playerScore")==20){
             SceneManager.LoadSceneAsync("LEVEL2") ;
         }
        
    }
}
