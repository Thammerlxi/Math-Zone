using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProcess : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // PlayerPrefs.SetInt("ReachedLevel", 1);  //RESETTER !!
        if (PlayerPrefs.HasKey("ReachedLevel"))
        {
            LevelManager.CurrentLevel = PlayerPrefs.GetInt("ReachedLevel");
        }
        else
        {
            PlayerPrefs.SetInt("ReachedLevel",1);
            LevelManager.CurrentLevel = 1;

        }
            
        // Debug.Log(PlayerPrefs.GetInt("ReachedLevel"));
 

    }


}
