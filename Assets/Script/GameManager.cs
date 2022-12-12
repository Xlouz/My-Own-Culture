using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject volumeUI;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
    }
    public void VolumeUI(bool condition)
    {
        if (condition)
        {
            volumeUI.SetActive(true);
        }
        else
        {
            volumeUI.SetActive(false);
        }
    }

    public void LoadSumatera()
    {
        SceneManager.LoadScene("Sumatera");
    }
    public void LoadSelectMap()
    {
        SceneManager.LoadScene("SelectMap");
    }
}
