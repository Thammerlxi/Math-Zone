using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneBackButton : MonoBehaviour
{
    private string Scenename;
    public GameObject ExitPanel;
    public GameObject InfoPanel;

    void Start()
    {
        Scenename = SceneManager.GetActiveScene().name;
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Scenename == "GameScene")
            SceneManager.LoadScene("LevelSelect");
            else if(Scenename == "LevelSelect")
               SceneManager.LoadScene("MainMenu");
            else if(Scenename == "MainMenu")
            {
                if (InfoPanel.activeSelf)
                    InfoPanel.SetActive(false);
                else
                    ExitPanel.SetActive(true);

            }

        }
    }
}
