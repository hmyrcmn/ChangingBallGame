/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// can ve skor goster
public class uı_manager_sc : MonoBehaviour
{
     [SerializeField]
   // private TMP_Text scoreText;

    [SerializeField]
    //private TMP_Text gameOverText;

    [SerializeField]
    //private TMP_Text restartText;

     [SerializeField]
    //private Image livesImg;

    private manager_sc manager_sc; 
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0"; // olustur 
        gameOverText.gameObject.SetActive(false); // name check
        restartText.gameObject.SetActive(false);  // name check
        manager_sc = GameObject.Find("manager_sc").GetComponent<manager_sc>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int score) {
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int currentLives) {
        //livesImg.sprite = liveSprites[currentLives];

        if (currentLives == 0) {
            GameOverSequence();
        }
    }


}
 */