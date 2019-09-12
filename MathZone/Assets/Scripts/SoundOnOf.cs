using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOf : MonoBehaviour
{
    public Sprite SOn;
    public Sprite SOff;

    public void Start()
    {
        if (!AudioListener.pause)
        {
            this.GetComponent<Image>().sprite = SOn;
        }

            
        else if (AudioListener.pause)
        {
            this.GetComponent<Image>().sprite = SOff;
        }
            
    }
    public void Sound()
    {

        if (!AudioListener.pause)
        {
            AudioListener.pause = true;
            this.GetComponent<Image>().sprite = SOff;

        } else if (AudioListener.pause)
        {
            AudioListener.pause = false;
            this.GetComponent<Image>().sprite = SOn;

        }








    }
 
}
