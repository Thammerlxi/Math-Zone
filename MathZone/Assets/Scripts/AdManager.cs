using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    //"ca-app-pub-4739349643730107/5604701508" VideoAdID
    private RewardBasedVideoAd rewardBasedVideo;
    private GameObject tmp;
    public GameObject Loading;
    public GameObject IntInfoG;
    public GameObject HintPanel;
    public GameObject GSprefab;
    private LevelManager LevelScript;
    private bool NoInt;

    public void Start()
    {
        LevelScript = GSprefab.GetComponentInChildren<LevelManager>();
        tmp = GameObject.FindWithTag("HP");

#if UNITY_ANDROID
        string AppID = "ca-app-pub-4739349643730107~4230118078";
    #elif UNITY_IPHONE
            
    #else
            string appId = "unexpected_platform";
    #endif
        MobileAds.Initialize(AppID);

        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

        this.RequestRewardBasedVideo();
    }


    private void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        NoInt = false;

        //MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        NoInt = true;
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        this.RequestRewardBasedVideo();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        /*string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardBasedVideoRewarded event received for "
                        + amount.ToString() + " " + type);*/

        //show hint based on playing level
        tmp.transform.GetChild(0).GetComponent<Image>().sprite = LevelScript.Hints[(LevelManager.PlayingLevel) - 1];
        HintPanel.SetActive(true);

    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }

    public void UserOptToWatchAd()
    {
        if(NoInt == false)
        {
            Loading.SetActive(true);
            StartCoroutine(LoadAd());
        }
                 
        else if (NoInt == true)
        {
           // Loading.SetActive(false);
            IntInfoG.SetActive(true);
        }
       // StartCoroutine(LoadAd());
        
        /*if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }*/

    }

    IEnumerator LoadAd()
    {
        yield return new WaitUntil(() => rewardBasedVideo.IsLoaded() == true);
        if (Loading.activeSelf == true)
        {
            rewardBasedVideo.Show();
            Loading.SetActive(false);
        }

    }
    /*IEnumerator LoadAd()
    {
        Loading.SetActive(true);
        yield return new WaitUntil(() => rewardBasedVideo.IsLoaded() == true);
        rewardBasedVideo.Show();
        Loading.SetActive(false);
    }*/





}




