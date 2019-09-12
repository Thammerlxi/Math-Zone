using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScriptRed : MonoBehaviour
{
    private LevelManager LevelScript;
    private GameObject tmp;
    public GameObject GCprefab;

    [SerializeField] private Text TimerText;
    [SerializeField] private float mainTimer;

    private float timer;
    private bool CanCount = true;
    private bool doOnce = false;
    private int RndLevel;
    public List<int> RndPos = new List<int>(LevelManager.RedMax);

    //private CanvasGroup fc;

    void Start()
    {
        LevelScript = GCprefab.GetComponentInChildren<LevelManager>();
        //LevelScript.GenerateRandomPos();
        GenerateRndList();
        Shuffler.Shuffle(RndPos);
        tmp = GameObject.Find("LevelCanvas");
        timer = mainTimer;
        iniGame();
        //fc = GameObject.FindGameObjectWithTag("FE").GetComponent<CanvasGroup>();
       // StartCoroutine(FadeOut(fc));
    }
    
    void Update()
    {

        if(timer >= 0.0f && CanCount)
        {

            timer -= Time.deltaTime;
            TimerText.text = timer.ToString("F");

        }
        else if (timer <= 0.0f && !doOnce)
        {
            CanCount = false;
            doOnce = true;
            TimerText.text = "0.00";
            timer = 0.0f;
            GameOver();

        }

    }

    public void ResetTimer()
    {
        timer = mainTimer;
        CanCount = true;
        doOnce = false;
    }

    void GameOver()
    {

        Debug.Log("gg");

    }

    void iniGame()
    {
        RndLevel = Random.Range(0,LevelManager.RedMax+1);
        tmp.transform.GetChild(0).GetComponent<Image>().sprite = LevelScript.RedLevels[RndLevel];


    }

    void GenerateRndList()
    {
        for(int i = 0; i < LevelManager.RedMax; i++)
        {
            RndPos[i] = i;
        }

    }

    /*public IEnumerator FadeOut(CanvasGroup cg)
    {
        while (cg.alpha > 0)
        {
            cg.alpha -= 0.07f;


            yield return new WaitForSeconds(0.03f);
        }
    }*/

}
