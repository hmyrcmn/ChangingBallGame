using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.SceneManagement;
public class ScorePanel : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI scoretext ;
    // Start is called before the first frame update
    public static ScorePanel ins;
    public void Awake(){
        if(ins==null){
            ins=this;
        }
    }
    void Start()
    {
        ScoreUpdate();
       
    }

    // Update is called once per frame
    void Update()
    {
        //toAraMenu();
      // scoretext = PlayerPrefs.GetInt("skor").ToString();
     
    }

     public void toAraMenu(){
         SceneManager.LoadSceneAsync("AraMenu") ;
    }
    public void ScoreUpdate(){
        scoretext.text ="SKOR: " +PlayerPrefs.GetInt("skor").ToString();
    }

}
