using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    public List<Sprite> Levels;
    public List<int> answers;
    public List<Sprite> Hints;

    public static int CurrentLevel = 1;// Reached Level
    public static int PlayingLevel = 1; // Active Level
    public static int Endgame = 50; // LASTLEVEL

    public static int RedRecord;
    public static int RedMax = 5; // RedLevelSayısı
    public List<Sprite> RedLevels;
    public List<int> RedAnswers;
    public List<int> RedA1;
    public List<int> RedA2;
    public List<int> RedA3;
    //public List<int> RndPos;
    //public List<int> RndPos = new List<int>(RedMax);


    public void LoadLevelScene(string levelname) // level yükleme fonksiyonu
    {
        string Bname = GameObject.Find(this.name).GetComponentInChildren<Text>().text; // buttonun textinde yazan degeri çekme
        if (Bname == "PC") // play butonuna tıklarsa
        {
            GameScript.Playbutton = true;
            LevelManager.PlayingLevel = LevelManager.CurrentLevel;

        }        
        SceneManager.LoadScene(levelname); // diger level yukleme butonları
    }

    public void ReturnLevelScene() 
    {
        SceneManager.LoadScene("LevelSelect");

    }

    public void Exit()
    {
        Application.Quit();
    }

   public void GenerateRandomPos()
    {
        /*int Maxrange = (RedMax) + 1;
        Debug.Log(RedMax);
        Debug.Log(Maxrange);
        for (int i = 0; i < RndPos.; i++)
        {
            RndPos[i] = UnityEngine.Random.Range(0, Maxrange);
           // Debug.Log(RndPos[i]);
        }*/

        //   Shuffle(RndPos);
    }

  

}
