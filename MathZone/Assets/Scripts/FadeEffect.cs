using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FadeEffect : MonoBehaviour
{
    private CanvasGroup fc;

    void Start()
    {
        fc = GameObject.FindGameObjectWithTag("FE").GetComponent<CanvasGroup>();
        fc.alpha = 1;
        StartCoroutine(FadeOut(fc));
    }
    public IEnumerator FadeOut(CanvasGroup cg)
    {
        while (cg.alpha > 0)
        {
            cg.alpha -= 0.07f;


            yield return new WaitForSeconds(0.03f);
        }

    }


}
