using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    private int Value;
    private String Tester;
    private string ButtonText;
    private int Qanswer;
    private int Qtrue;
    private LevelManager lvl;
    private GameScript Gs;
    private GameController Gc;
    public GameObject TruePanel;
    private Text Wt;
    public Button Hbutton;
    public AudioClip WrongS;
    public AudioClip CorrectS;
    private AudioSource source;


    // private GameObject tmp;

    void Start()
    {
        lvl = GameObject.FindGameObjectWithTag("AA").GetComponent<LevelManager>(); //initialize
        Gc = GameObject.FindGameObjectWithTag("AA").GetComponent<GameController>();
        Gs = GameObject.FindGameObjectWithTag("GS").GetComponent<GameScript>();
        Wt = GameObject.Find("WrongText").GetComponent<Text>();

        if(GetComponent<AudioSource>())
        source = GetComponent<AudioSource>();

    }


    public void ValueWrite(Text TextV) // buton kontrolü
	{
        ButtonText = GameObject.Find(this.name).GetComponentInChildren<Text>().text;
        TextV.color = Color.white;


        if (ButtonText == "<") //sil
        {

            TextV.text = "";          
        }
        else if (ButtonText == "Enter")
        {
            if (TextV.text == "Answer")
            {

            }
            else if (TextV.text == "")
            {

            }
            else
            {

                Qanswer = Convert.ToInt32(TextV.text);
                Qtrue = LevelManager.PlayingLevel - 1;

                if (Qanswer == lvl.answers[Qtrue])
                {
                    Debug.Log("True");
                    TextV.text = "";
                    //  tmp = GameObject.Find("LevelCanvas");
                    //  tmp.transform.GetChild(0).GetComponent<Image>().sprite = lvl.Levels[1];
                    source.PlayOneShot(CorrectS); // doğru sesi çal
                    StartCoroutine(WaitASec()); //sesi eşleme
                   // TruePanel.SetActive(true);
                }
                else
                {
                    TextV.text = "";
                    Debug.Log("False");
                    if(Gs.Cactive == false)
                    StartCoroutine(Gs.FadeInOut(0.5f, Wt));
                    else if(Gs.Cactive == true)
                    {
                        StopCoroutine(Gs.FadeInOut(0.5f, Wt));
                    }
                    source.PlayOneShot(WrongS);

                    //StartCoroutine(Gc.Wrong(Wt));


                }
            }
        }
        else
        {
            Value = Convert.ToInt32(ButtonText);
            Tester = TextV.text + Convert.ToString(Value);
            if (TextV.text == "Answer")
            {
                TextV.text = Convert.ToString(Value);
                Tester = "";
            }
            else if (Convert.ToInt32(Tester) > 999999)
            {


            }
            else
                TextV.text = TextV.text + Convert.ToString(Value);




        }

    }
    public void NextLevel()
    {
        
        if (LevelManager.PlayingLevel == LevelManager.Endgame)
        {
            lvl.ReturnLevelScene();
 

        }
        else if (LevelManager.PlayingLevel == LevelManager.CurrentLevel)
        {
            LevelManager.PlayingLevel++;
            LevelManager.CurrentLevel++;
            PlayerPrefs.SetInt("ReachedLevel", LevelManager.CurrentLevel);
            TruePanel.SetActive(false);
            Gs.IniGame();
            resetAd();

        }
        else
        {
            LevelManager.PlayingLevel++;
            TruePanel.SetActive(false);
            Gs.IniGame();
            resetAd();

        }



    }

    public void resetAd()
    {
        Hbutton.GetComponent<UnityAD>().initializeAd();

    }

    public IEnumerator WaitASec()
    {

        yield return new WaitForSeconds(0.1f);
        TruePanel.SetActive(true);
    }
}
