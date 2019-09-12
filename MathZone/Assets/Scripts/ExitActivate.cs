using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitActivate : MonoBehaviour
{
    public GameObject ExitPanel;
    public GameObject IntInfo;

    public void ActivatePanel()

    {
        ExitPanel.SetActive(true);
    }

    public void DeactivePanel()
    {

        ExitPanel.SetActive(false);

    }
    public void CloseInfo()
    {
        IntInfo.SetActive(false);

    }
    
}
