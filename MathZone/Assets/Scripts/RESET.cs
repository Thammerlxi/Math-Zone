using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RESET : MonoBehaviour
{
    // Start is called before the first frame update

    public void Reset()
    {
        PlayerPrefs.SetInt("ReachedLevel", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
