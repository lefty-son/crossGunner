using System;
using System.Collections;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    public static AdsManager instance;

    [SerializeField] private string appId;

    private InterstitialAd interstitial;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
#if UNITY_ANDROID
        appId = "ca-app-pub-8860756584846944~2900155425";
#elif UNITY_IOS
        appId = "ca-app-pub-8860756584846944~7119845302";
#else
        appId = "UNKNOWN_PLATFORM";
#endif

        RequestResi();


    }

    public void RequestResi()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8860756584846944/6189907019";
#elif UNITY_IOS
        string adUnitId = "ca-app-pub-8860756584846944/7794810334";
#else
        string   adUnitId = "unexpected_platform";
#endif

        interstitial = new InterstitialAd(adUnitId);
        interstitial.OnAdLoaded += HandleOnAdLoaded;
        interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        interstitial.OnAdOpening += HandleOnAdOpened;
        interstitial.OnAdClosed += HandleOnAdClosed;
        interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;


        // Create an empty ad request.
        //AdRequest request = new AdRequest.Builder().Build();

        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("07EB17C47DEAD7454116C04CDF20E1C5")
.Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
        interstitial.Destroy();
        RequestResi();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        interstitial.Destroy();
        RequestResi();
    }

    public void HandleOnAdLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeftApplication event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialLeftApplication event received");
    }

    public void ShowResi()
    {
        if (PrefManager.instance.GetAdsRemoved() == 1)
        {
            return;
        }
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
            GameManager.instance.InitAdsMeter();
        }
        else
        {
            RequestResi();
        }
    }
}
