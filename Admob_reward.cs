using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class Admob_reward : MonoBehaviour
{
    private RewardedAd rewardedAd;
    // Start is called before the first frame update

    //public bool isRewardVideoEnd = false;

    public string placementIDAndroid;
    public string placementIDIOS;
    public int adsNum;

    void Start()
    {
        // Initialize the Mobile Ads SDK.
        MobileAds.Initialize((initStatus) =>
        {
            Dictionary<string, AdapterStatus> map = initStatus.getAdapterStatusMap();
            foreach (KeyValuePair<string, AdapterStatus> keyValuePair in map)
            {
                string className = keyValuePair.Key;
                AdapterStatus status = keyValuePair.Value;
                switch (status.InitializationState)
                {
                    case AdapterState.NotReady:
                        // The adapter initialization did not complete.
                        MonoBehaviour.print("Adapter: " + className + " not ready.");
                        break;
                    case AdapterState.Ready:
                        // The adapter was successfully initialized.
                        MonoBehaviour.print("Adapter: " + className + " is initialized.");
                        break;
                }
            }
        });

        this.RequestRewardedAd();
    }
    

    // 보상형 광고
    private void RequestRewardedAd()
    {
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = placementIDAndroid;
#elif UNITY_IPHONE
            adUnitId = placementIDIOS;
#else
            adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;



        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.LoadAdError);
        RequestRewardedAd();
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.AdError);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        RequestRewardedAd();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        

        //isRewardVideoEnd = true;
        if (adsNum.Equals(0))//몬스터
        {
            
            //Debug.Log("AD");

            Time.timeScale = 1;

            if (MonsterBoxManager.Instance.reward < 5999)
            {
                GameManager.Instance.adamant += MonsterBoxManager.Instance.reward * 2;
                UIManager.Instance.UpdateAdamantText();
            }
            else
            {
                GameManager.Instance.gold += MonsterBoxManager.Instance.reward * 2;
                UIManager.Instance.UpdateGoldText();
            }

            UIManager.Instance.CloseMonsterRewardUI();



            MonsterBoxManager.Instance.reward = 0;


            SaveManager.Instance.Save();
            //isRewardVideoEnd = false;
        }
        else if (adsNum.Equals(1))//부활
        {
            
            //Player.Instance.health = Player.Instance.maxHealth;
            //Player.Instance.isAlive = true;
            ////Player.Instance.GoFirstPos();
            //Player.Instance.OxygenRemain = Player.Instance.maxOxygen;

            //Player.Instance.CoroutineWhenAlive();

            

            //UIManager.Instance.HealthUIUpdate();
            //UIManager.Instance.DeadUI.gameObject.SetActive(false);
            //SaveManager.Instance.Save();
            ////AdsManager.Instance.admob_Rewards[1].isRewardVideoEnd = false;
        }
        else if (adsNum.Equals(2))//아다만트광고
        {
            AdamantBox.Instance.count = 0;

            /*
            int adamant = UnityEngine.Random.Range(0, 11);

            int tmp = 0;

            for (int i = 0; i < GameManager.Instance.isGetKey.Length; i++)
            {
                if (GameManager.Instance.isGetKey[i])
                {
                    tmp++;

                }
                else
                {
                    break;
                }
            }

            adamant += 90 + tmp;
            */

            GameManager.Instance.adamant += AdamantBox.Instance.reward;

            AdamantBox.Instance.reward = 0;

            
            if(AdamantBox.Instance.countCoroutine == null)
            {
                AdamantBox.Instance.countCoroutine = StartCoroutine(AdamantBox.Instance.CountTime());
            }
            
            //StartCoroutine(UIManager.Instance.MoneyBoxSliderUpdate());

            

            UIManager.Instance.UpdateAdamantText();
            SaveManager.Instance.Save();
        }
        else if(adsNum.Equals(3))// 드릴
        {
           

            StartCoroutine(UIManager.Instance.CountDrillBuff());

        }else if (adsNum.Equals(4))//자동굴착기
        {
            StartCoroutine(ClickerManager.Instance.ClickerAD());
        }
        else if (adsNum.Equals(5))//다이너마이트
        {
            StartCoroutine(UIManager.Instance.CountDynamiteBuff());
        }
        else if (adsNum.Equals(6))//즉시부활
        {
            SoundManager.Instance.clickAudioSource.Play();
            //adamant -= 150;
            Player.Instance.health = Player.Instance.maxHealth;
            Player.Instance.isAlive = true;
            //Player.Instance.GoFirstPos();
            Player.Instance.OxygenRemain = Player.Instance.maxOxygen;

            Player.Instance.CoroutineWhenAlive();

            Time.timeScale = 1;

            UIManager.Instance.HealthUIUpdate();
            //UIManager.Instance.UpdateAdamantText();
            UIManager.Instance.DeadUI.gameObject.SetActive(false);
            SaveManager.Instance.Save();
        }
        else if (adsNum.Equals(7))//머니박스
        {
            GameManager.Instance.gold += MoneyBox.Instance.reward * 3;

            MoneyBox.Instance.reward = 0;

            StartCoroutine(MoneyBox.Instance.CountTime());

            UIManager.Instance.UpdateGoldText();
        }
        else if (adsNum.Equals(8))//산소
        {
            StartCoroutine(UIManager.Instance.CountOxygenBuff());
        }
        else if (adsNum.Equals(9))//부스터
        {
            StartCoroutine(UIManager.Instance.CountBoosterBuff());
        }

        Debug.Log(adsNum);
        //UIManager.Instance.DelayedClosePausePanel();
        Invoke("DelayedADEnd", 1f);

    }

    void DelayedADEnd()
    {
        AdsManager.Instance.isRewardVideoEnd = true;
    }

    public void ShowRewardedAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            AdsManager.Instance.isRewardVideoEnd = false;
            this.rewardedAd.Show();
            
        }
        else
        {
            Debug.Log("NOT Loaded Interstitial");
            RequestRewardedAd();
        }
    }

    private void OnDestroy()
    {
        MonoBehaviour.print("ondestroy()");
        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded -= HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad -= HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening -= HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow -= HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed -= HandleRewardedAdClosed;
    }

    /*
        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
     
     */

}
