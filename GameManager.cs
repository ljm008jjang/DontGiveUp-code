using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour
{

    private static GameManager _Instance;

    public static GameManager Instance
    {
        get
        {
            return _Instance;
        }
    }

    Player player;
    UIManager UIManager;
    public GameManagerData gameManagerData;
    public int gold = 10000;
    public int adamant = 1000;
    public bool isGameStop;
    public int currentSceneIndex;
    bool bPaused;
    public DeadBoxes deadBoxes;
    public DeadBox deadBox;
    //public List<bool> isGetKey = new List<bool>();//1스테이지에서 얻었다 -> 0인덱스에 저장
    public bool[] isGetKey;
    public int penaltyRemainTime = 0;
    WaitForSeconds ws = new WaitForSeconds(1);
    Coroutine penalty = null;

    public bool stopCoroutine = false;
    

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            bPaused = true;
        }
        else
        {
            if (bPaused)
            {
                bPaused = false;
                if (!player.playerData.isFirstStart && AdsManager.Instance.isRewardVideoEnd)
                {
                    Time.timeScale = 0;
                    UIManager.pausePanel.gameObject.SetActive(true);
                }
                
            }
        }

    }

    private void Awake()
    {
        _Instance = this;
        Application.targetFrameRate = 60;
        
    }

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        player = Player.Instance;
        UIManager = UIManager.Instance;

        StartCoroutine(CountPenaltyTime());
        //GetVariable();
        

    }

    public void Initialized()
    {
        isGetKey = new bool[SceneManager.sceneCountInBuildSettings];
        gameManagerData.isGetKey = new bool[SceneManager.sceneCountInBuildSettings];
    }

    public void GetVariable()
    {
        gold = gameManagerData.gold;
        adamant = gameManagerData.adamant;
        //currentSceneIndex = gameManagerData.currentSceneIndex;

        penaltyRemainTime = gameManagerData.penaltyRemainTime;
        for(int i = 0; i < gameManagerData.isGetKey.Length; i++)
        {
            isGetKey[i] = gameManagerData.isGetKey[i];
        }
        //isGetKey = gameManagerData.isGetKey;
    }

    public void Revive()
    {
        SoundManager.Instance.clickAudioSource.Play();
        /*
        for(int i=0; i < deadBoxes.deadBoxArray.Length; i++)
        {
            if (!deadBoxes.deadBoxArray[i].isActiveAndEnabled)
            {
                deadBox = deadBoxes.deadBoxArray[i];
                break;
            }
        }
        */
        deadBox = deadBoxes.deadBoxArray[0];

        deadBox.transform.position = player.deathPos;
        deadBox.gold = Mathf.FloorToInt(gold * 0.5f);
        gold = deadBox.gold;

        player.health = player.maxHealth;
        player.isAlive = true;
        player.GoFirstPos();
        player.OxygenRemain = player.maxOxygen;

        player.CoroutineWhenAlive();

        ItemManager.Instance.teleport = 0;
        ItemManager.Instance.bomb = 0;
        ItemManager.Instance.aidPack = 0;
        ItemManager.Instance.dynamite = 0;
        ItemManager.Instance.oxygenCapsule = 0;
        ItemManager.Instance.storeTicket = 0;

        UIManager.UpdateUsableItemUI();

        for (int i = 0; i < ItemManager.Instance.Inventory.Count; i++)
        {
            for(int j = 0; j < ItemManager.Instance.Inventory[i].Count; j++)
            {
                if (ReferenceEquals(ItemManager.Instance.Inventory[i][0], null))
                {
                    break;
                }
                else
                {
                    deadBox.itemList.Add(ItemManager.Instance.Inventory[i][0]);
                    ItemManager.Instance.Inventory[i].RemoveAt(0);
                    ItemManager.Instance.Inventory[i].Add(null);
                }
            }
            
        }

        StartCoroutine(deadBox.DeadBoxOn());
        penaltyRemainTime = 120;
        if (ReferenceEquals(penalty, null))
        {
            penalty = StartCoroutine(CountPenaltyTime());
        }
        else
        {
            StopCoroutine(penalty);
            penalty = StartCoroutine(CountPenaltyTime());
        }

        Time.timeScale = 1;

            UIManager.Instance.HealthUIUpdate();
        UIManager.DeadUI.gameObject.SetActive(false);
        UIManager.Instance.UpdateGoldText();
    }

    IEnumerator CountPenaltyTime()
    {
        player.miningPowerDebuffCoefficient = 0.7f;
        UIManager.debuffImage.gameObject.SetActive(true);
        while (penaltyRemainTime > 0)
        {
            yield return ws;
            penaltyRemainTime--;
        }
        UIManager.debuffImage.gameObject.SetActive(false);
        player.miningPowerDebuffCoefficient = 1f;
    }

    public void ADRevive(bool isAD)
    {
        //AdsManager.Instance.admob_Rewards[1].ShowRewardedAd();
        if (!isAD)
        {
            if (adamant >= 150)
            {
                SoundManager.Instance.clickAudioSource.Play();
                adamant -= 150;
                Player.Instance.health = Player.Instance.maxHealth;
                Player.Instance.isAlive = true;
                //Player.Instance.GoFirstPos();
                Player.Instance.OxygenRemain = Player.Instance.maxOxygen;

                Player.Instance.CoroutineWhenAlive();

                Time.timeScale = 1;

                UIManager.Instance.HealthUIUpdate();
                UIManager.Instance.UpdateAdamantText();
                UIManager.Instance.DeadUI.gameObject.SetActive(false);
                SaveManager.Instance.Save();
            }
            else
            {
                SoundManager.Instance.clickFailAudioSource.Play();
            }
        }
        else
        {
            AdsManager.Instance.admob_Rewards[6].ShowRewardedAd();
        }
        
        
    }

    public void GetMoney()
    {
        gold += 100000;
    }

    public void GetAdamant()
    {
        adamant += 10000;
    }

    public void GetMiningPower()
    {
        player.miningPower += 1;
    }

    public void BuyAdamant(int index)
    {
        switch (index)
        {
            case 0:
                adamant += 1500;
                break;
            case 1:
                adamant += 3500;
                break;
            case 2:
                adamant += 8500;
                break;
            case 3:
                adamant += 18000;
                break;
        }

        SaveManager.Instance.Save();
        UIManager.UpdateAdamantText();
    }

    public void Fail()
    {
        //Debug.Log("xx");
    }
    /*
    private void OnApplicationQuit()
    {
        SaveManager.Instance.Save();
    }
    */
    public void GameQuit()
    {
        SaveManager.Instance.Save();
        Application.Quit();
    }
}
[System.Serializable]
public class GameManagerData
{
    public int gold;
    public int adamant;
    public int currentSceneIndex;
    public bool[] isGetKey;
    public int penaltyRemainTime;
}
