using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class Admob_Interstitial : MonoBehaviour
{
    /*
    private static Admob_Interstitial _Instance;

    public static Admob_Interstitial Instance
    {
        get
        {
            return _Instance;
        }
    }

    private void Awake()
    {
        _Instance = this;
    }
    */
    private InterstitialAd interstitial;
    public bool IsInterstitialOn = true;
    WaitForSeconds om = new WaitForSeconds(60f);

    private void Start()
    {
        RequestInterstitial();
    }

    private void RequestInterstitial()
    {
        
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-2528340394482420/3549413608";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-2528340394482420/9776760668";
#else
        string adUnitId = "unexpected_platform";
#endif

        //string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        //this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        LoadAdError loadAdError = args.LoadAdError;

        // Gets the domain from which the error came.
        string domain = loadAdError.GetDomain();

        // Gets the error code. See
        // https://developers.google.com/android/reference/com/google/android/gms/ads/AdRequest
        // and https://developers.google.com/admob/ios/api/reference/Enums/GADErrorCode
        // for a list of possible codes.
        int code = loadAdError.GetCode();

        // Gets an error message.
        // For example "Account not approved yet". See
        // https://support.google.com/admob/answer/9905175 for explanations of
        // common errors.
        string message = loadAdError.GetMessage();

        // Gets the cause of the error, if available.
        AdError underlyingError = loadAdError.GetCause();

        // All of this information is available via the error's toString() method.
        Debug.Log("Load error string: " + loadAdError.ToString());

        // Get response information, which may include results of mediation requests.
        ResponseInfo responseInfo = loadAdError.GetResponseInfo();
        Debug.Log("Response info: " + responseInfo.ToString());
        RequestInterstitial();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
        StartCoroutine(countInstitialTime());
    }

    IEnumerator countInstitialTime()
    {
        IsInterstitialOn = false;

        yield return om;

        IsInterstitialOn = true;
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        if (UIManager.Instance.portalR.isGoingScene)
            StartCoroutine(SceneMoveManager.Instance.NextIe());
        else
            StartCoroutine(SceneMoveManager.Instance.PreviousIe());
        RequestInterstitial();
        Invoke("DelayedADEnd", 1f);
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    void DelayedADEnd()
    {
        AdsManager.Instance.isRewardVideoEnd = true;
    }
    public void ShowIntertitialAD()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            RequestInterstitial();
        }
    }
}
