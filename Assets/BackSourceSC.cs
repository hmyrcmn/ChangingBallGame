using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackSourceSC : MonoBehaviour
{
    private static BackSourceSC backSource;

    void Awake() {

        
    if (backSource != null) {
         Destroy(this.gameObject);
    } else {
            backSource = this;
    }

        
        DontDestroyOnLoad(this.gameObject);

    }
    public void Update(){
        if(Input.GetKeyDown(KeyCode.Delete)){
           PlayerPrefs.DeleteAll();     
           print(  "kayıtlar silindi")   ;
        }
    }
               

}
