using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class AnaMenu : MonoBehaviour
{
    private AudioSource backSource;
    public Button DevamButton;

    public void Start()
    {
        if (!IsSeeButton())
        {
            DevamButton.gameObject.SetActive(false);
        }
        else
        {
            DevamButton.onClick.AddListener(DevamEt);
        }
    }
    public void DevamEt()
    {
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("currentScene") );
    }

    bool IsSeeButton()
    {
        return (PlayerPrefs.GetInt("skor") != 0) ? true: false;
    }

    public void ReStart()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}