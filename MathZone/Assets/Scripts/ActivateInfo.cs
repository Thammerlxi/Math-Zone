using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateInfo : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject InfoB;

    public void openInfo()
    {
        InfoPanel.SetActive(true);
    }
    public void closeInfo()
    {
        InfoPanel.SetActive(false);
        InfoB.GetComponent<CloseSound>().CloseS();
    }
}
