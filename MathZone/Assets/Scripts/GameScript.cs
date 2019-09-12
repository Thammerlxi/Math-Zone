using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameScript : MonoBehaviour
{
    private LevelManager LevelScript;
    private GameObject tmp;
    private CanvasGroup fc;
    private Scene ActiveScene;
    public GameObject GCprefab;
    public static bool Playbutton;
    public Text LevelText;
    private Text Atext;
    public Text Wt;
    public bool Cactive = false;

    void Start()
    {
        //GameObject clone = (GameObject)Instantiate(GCprefab);
        LevelScript = GCprefab.GetComponentInChildren<LevelManager>();
        tmp = GameObject.Find("LevelCanvas");
        fc = GameObject.FindGameObjectWithTag("FE").GetComponent<CanvasGroup>();
        Atext = GameObject.Find("AnswerText").GetComponent<Text>();
        IniGame();
    }

    void Update()
    {
        if (Atext.text == "")
        {
            Atext.color = new Color(0.4716981f, 0.4716981f, 0.4716981f);
            Atext.text = "Answer";

        }

    }

    public IEnumerator FadeOut(CanvasGroup cg)
    {
        while (cg.alpha > 0)
        {
            cg.alpha -= 0.07f;


            yield return new WaitForSeconds(0.03f);
        }


    }
    public IEnumerator FadeInOut(float t, Text i)
    {
        Cactive = true;
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        Cactive = false ;
    }

    public void IniGame()
    {
        Wt.color = new Color(Wt.color.r, Wt.color.g, Wt.color.b, 0);
        if (Playbutton)
        {
            fc.alpha = 1;
            tmp.transform.GetChild(0).GetComponent<Image>().sprite = LevelScript.Levels[(LevelManager.CurrentLevel) - 1];
            LevelText.text = "LEVEL " + LevelManager.PlayingLevel;
            StartCoroutine(FadeOut(fc));
            


            Playbutton = false;
        }
        else
        {
            fc.alpha = 1;
            tmp.transform.GetChild(0).GetComponent<Image>().sprite = LevelScript.Levels[(LevelManager.PlayingLevel) - 1];
            LevelText.text = "LEVEL " + LevelManager.PlayingLevel;
            StartCoroutine(FadeOut(fc));

        }

    }
    



}
