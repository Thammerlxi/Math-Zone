using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PbuttonText : MonoBehaviour
{

    public Text Pbutton;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("ReachedLevel"))
        {
            Pbutton.text = PlayerPrefs.GetInt("ReachedLevel") + " / " + LevelManager.Endgame;
        }
        else
        {
            Pbutton.text = 1 + " / " + LevelManager.Endgame;

        }
    }
   

}
