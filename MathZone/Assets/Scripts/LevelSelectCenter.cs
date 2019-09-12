using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectCenter : MonoBehaviour
{
    public GameObject LSP;
    private int starty = -2626;
    private int LastLevel;
    private int focuslevel;
    private int y;

    void Update()
    {
       // Debug.Log(LSP.GetComponent<RectTransform>().offsetMax);
    }
    // Start is called before the first frame update
    void Start()
    {

        LastLevel = LevelManager.CurrentLevel;
        focuslevel = (LastLevel - 1) / 3;

        if (focuslevel <= 5)
            LSP.GetComponent<RectTransform>().anchoredPosition = new Vector2(LSP.GetComponent<RectTransform>().anchoredPosition.x, starty);
        else
            LSP.GetComponent<RectTransform>().anchoredPosition = new Vector2(LSP.GetComponent<RectTransform>().anchoredPosition.x, starty+((focuslevel-5)*295));





    }
}
//2625
//290