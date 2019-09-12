using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Monetization;
using System.Collections;

[RequireComponent(typeof(Button))]

public class UnityAD : MonoBehaviour
{

    public string placementId = "rewardedVideo";
    private Button adButton;
    public GameObject Loading;
    public GameObject HintPanel;
    public GameObject GSprefab;
    private LevelManager LevelScript;

#if UNITY_IOS
   private string gameId = "3196888";
#elif UNITY_ANDROID
    private string gameId = "3196889";
#endif

    void Start()
    {
        LevelScript = GSprefab.GetComponentInChildren<LevelManager>();

        adButton = GetComponent<Button>();
        if (adButton)
        {
            adButton.onClick.AddListener(ShowAd);
        }
       
        if (Monetization.isSupported)
        {
            adButton.interactable = false;
            Monetization.Initialize(gameId, false); // true means test mode
        }
    }

    void Update()
    {
        if (adButton)
        {
            adButton.interactable = Monetization.IsReady(placementId);
        }
    }

   public void ShowAd()
    {
       // Loading.SetActive(true);
        ShowAdCallbacks options = new ShowAdCallbacks();
        options.finishCallback = HandleShowResult;
        ShowAdPlacementContent ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;
        ad.Show(options);
    }

    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            // Reward the player
            // Loading.SetActive(false);
           // Monetization.Initialize(gameId, true);
            Debug.Log("REWARD");
            HintPanel.transform.GetChild(0).GetComponent<Image>().sprite = LevelScript.Hints[(LevelManager.PlayingLevel) - 1];
            HintPanel.SetActive(true);
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("The player skipped the video - DO NOT REWARD!");
        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }
    }

    public void initializeAd()
    {
        adButton.interactable = false;
        Monetization.Initialize(gameId, true);
    }





}
