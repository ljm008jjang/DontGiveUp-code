using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashStoreManager : MonoBehaviour
{
    private static CashStoreManager _Instance;

    WaitForSeconds ws = new WaitForSeconds(30);
    public int drillCost;
    public int drillLevel = 0;
    public int clickerCost;
    public int clickerLevel = 0;
    public int boosterCost;
    
    public int boosterLevel = 0;
    public CashStoreManagerData cashStoreManagerData;
    public static CashStoreManager Instance
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

    private void Start()
    {
        GetVariable();
    }

    public void GetVariable()
    {
        drillLevel = cashStoreManagerData.drillLevel;
        clickerLevel = cashStoreManagerData.clickerLevel;
        boosterLevel = cashStoreManagerData.boosterLevel;
    }


    public void ClickBuyClickerPowerUpUI()
    {
        if(GameManager.Instance.adamant >= clickerCost && clickerLevel <= 11)
        {
            if (CashStoreManager.Instance.clickerLevel.Equals(0))
            {
                UIManager.Instance.clickerPowerUpUI.gameObject.SetActive(true);
                UIManager.Instance.clickerPowerUpSlider.gameObject.SetActive(true);
                ClickerPowerScript.Instance.isOn = true;


            }
            GameManager.Instance.adamant -= clickerCost;
            //Player.Instance.miningPowerBuffCoefficient += 0.1f;


            clickerLevel++;

            UIManager.Instance.UpdateCashStoreCostUI(2);
            UIManager.Instance.UpdateAdamantText();

            SaveManager.Instance.Save();
        }
        
        
    }
    public void ClickBuyDrillPowerUp()
    {
        if(GameManager.Instance.adamant >= drillCost && drillLevel <= 11)
        {
            if (drillLevel.Equals(0))
            {
                UIManager.Instance.drillPowerUpUI.gameObject.SetActive(true);
                UIManager.Instance.drillPowerUpSlider.gameObject.SetActive(true);
                DrillPowerScript.Instance.isOn = true;

            }

            GameManager.Instance.adamant -= drillCost;
            //Player.Instance.miningPowerBuffCoefficient += 0.1f;


            drillLevel++;

            UIManager.Instance.UpdateCashStoreCostUI(0);
            UIManager.Instance.UpdateAdamantText();
            SaveManager.Instance.Save();
        }
    }

    public void ClickBuyBoosterUp()
    {
        if(GameManager.Instance.adamant >= boosterCost && boosterLevel <= 15)
        {
            GameManager.Instance.adamant -= boosterCost;

            switch (boosterLevel)
            {
                case 0:
                    Player.Instance.maxFuel += 0.5f;
                    break;
                case 1:
                    Player.Instance.maxFuel += 0.5f;
                    break;
                case 2:
                    Player.Instance.maxFuel += 0.5f;
                    break;
                case 3:
                    Player.Instance.maxFuel += 0.5f;
                    break;
                case 4:
                    Player.Instance.maxFuel += 0.5f;
                    break;
                case 5:
                    Player.Instance.maxFuel += 0.5f;
                    break;
                case 6:
                    Player.Instance.maxFuel += 0.5f;
                    break;
                case 7:
                    Player.Instance.maxFuel += 0.5f;
                    break;
                case 8:
                    Player.Instance.maxFuel += 1f;
                    break;
                case 9:
                    Player.Instance.maxFuel += 1f;
                    break;
                case 10:
                    Player.Instance.maxFuel += 1f;
                    break;
                default:
                    Player.Instance.maxFuel += 1.5f;
                    break;


            }

            UIManager.Instance.fuelSlider.maxValue = Player.Instance.maxFuel;

            boosterLevel++;

            UIManager.Instance.UpdateCashStoreCostUI(4);
            UIManager.Instance.UpdateAdamantText();

            SaveManager.Instance.Save();
        }
    }

    

    public void CalculateDrillPowerUpCost()
    {
        
        switch (drillLevel)
        {
            case 0:
                drillCost = 400;
                
                break;
            case 1:
                drillCost = 800;
                
                break;
            case 2:
                drillCost = 1200;
                
                break;
            case 3:
                drillCost = 1600;
                
                break;
            case 4:
                drillCost = 2000;
                
                break;
            case 5:
                drillCost = 2500;
                
                break;
            case 6:
                drillCost = 3000;
                
                break;
            case 7:
                drillCost = 3600;
                
                break;
            case 8:
                drillCost = 5000;
                
                break;
            case 9:
                drillCost = 7500;
                
                break;
            case 10:
                drillCost = 10000;
                
                break;
            case 11:
                drillCost = 15000;
                
                break;
        }
    }

    public void CalculateClickerPowerUpCost()
    {
        switch (clickerLevel)
        {
            case 0:
                clickerCost = 400;
                break;
            case 1:
                clickerCost = 800;
                break;
            case 2:
                clickerCost = 1200;
                break;
            case 3:
                clickerCost = 1600;
                break;
            case 4:
                clickerCost = 2000;
                break;
            case 5:
                clickerCost = 2500;
                break;
            case 6:
                clickerCost = 3000;
                break;
            case 7:
                clickerCost = 3600;
                break;
            case 8:
                clickerCost = 5000;
                break;
            case 9:
                clickerCost = 7500;
                break;
            case 10:
                clickerCost = 10000;
                break;
            case 11:
                clickerCost = 15000;
                break;
        }
    }

    public void CalculateBoosterCost()
    {
        switch (boosterLevel)
        {
            case 0:
                boosterCost = 400;
                break;
            case 1:
                boosterCost = 800;
                break;
            case 2:
                boosterCost = 1200;
                break;
            case 3:
                boosterCost = 1600;
                break;
            case 4:
                boosterCost = 2000;
                break;
            case 5:
                boosterCost = 2500;
                break;
            case 6:
                boosterCost = 3000;
                break;
            case 7:
                boosterCost = 3600;
                break;
            case 8:
                boosterCost = 5000;
                break;
            case 9:
                boosterCost = 7500;
                break;
            case 10:
                boosterCost = 10000;
                break;
            default:
                boosterCost = 15000;
                break;
        }
    }
    int goldNum;
    public void ReturnInt(int a)
    {
        SoundManager.Instance.clickAudioSource.Play();
        goldNum = a;
    }

    public void BuyGold()
    {
        switch (goldNum)
        {
            case 0:
                if(GameManager.Instance.adamant >= 2000)
                {
                    SoundManager.Instance.clickAudioSource.Play();

                    GameManager.Instance.adamant -= 2000;
                    GameManager.Instance.gold += 150000; 
                }
                else
                    SoundManager.Instance.clickFailAudioSource.Play();
                break;
            case 1:
                if (GameManager.Instance.adamant >= 5000)
                {
                    SoundManager.Instance.clickAudioSource.Play();
                    GameManager.Instance.adamant -= 5000;
                    GameManager.Instance.gold += 400000;
                }
                else
                    SoundManager.Instance.clickFailAudioSource.Play();
                break;
            case 2:
                if (GameManager.Instance.adamant >= 14000)
                {
                    SoundManager.Instance.clickAudioSource.Play();
                    GameManager.Instance.adamant -= 14000;
                    GameManager.Instance.gold += 1200000;
                }
                else
                    SoundManager.Instance.clickFailAudioSource.Play();
                break;
            case 3:
                if (GameManager.Instance.adamant >= 28000)
                {
                    SoundManager.Instance.clickAudioSource.Play();
                    GameManager.Instance.adamant -= 28000;
                    GameManager.Instance.gold += 2600000;
                }
                else
                    SoundManager.Instance.clickFailAudioSource.Play();
                break;
        }
        UIManager.Instance.UpdateGoldText();
        UIManager.Instance.UpdateAdamantText();
        SaveManager.Instance.Save();
    }

    public void BuyPermanentStoreTicket()
    {
        if(GameManager.Instance.adamant >= 10000)
        {
            GameManager.Instance.adamant -= 10000;
            ItemManager.Instance.isBuyPermanentStoreTicket = true;
            UIManager.Instance.UpdateAdamantText();
            UIManager.Instance.UpdateCashStoreCostUI(6);
            SaveManager.Instance.Save();
        }
    }
}

[System.Serializable]
public class CashStoreManagerData
{
    public int drillLevel = 0;
    public int clickerLevel = 0;
    public int boosterLevel = 0;
}
