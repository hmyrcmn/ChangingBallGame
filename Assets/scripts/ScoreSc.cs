using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    void ContinueGame()
    {
        if (PlayerPrefs.HasKey("saved_level") == false)
        {
            Debug.Log("Saved game not found.");
        }
        else
        {
            string saved_level_name = PlayerPrefs.GetString("saved_level");
            if(SceneManager.GetSceneByName(saved_level_name).IsValid())
            {
                SceneManager.LoadScene(saved_level_name);
            }
            else
            {
                Debug.Log("Saved game is not valid.");
            }
        }
    }
}