using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    private Button btn;
    private int checker;
    private int Bvalue;

    private void Awake()
    {
        checker = LevelManager.CurrentLevel;
        //checker = PlayerPrefs.GetInt("ReachedLevel");
        btn = GameObject.Find(this.name).GetComponent<Button>();
        Bvalue = Convert.ToInt32(btn.GetComponentInChildren<Text>().text);
        if (Bvalue > checker)
        {
            btn.interactable = false;
        }
        
    }

    void Start()
    {

    }

    public void LoadScene()
    {

        LevelManager.PlayingLevel = Bvalue;
        SceneManager.LoadScene("GameScene");
    }

    
}
