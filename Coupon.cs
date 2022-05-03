using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class Coupon : MonoBehaviour
{
    private static Coupon instance;

    public static Coupon Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Coupon>();

                if (instance == null)
                {
                    GameObject container = new GameObject("CouponManager");
                    instance = container.AddComponent<Coupon>();
                }
            }
            return instance;
        }
    }

    public TextMeshProUGUI answerText;
    public TMP_InputField couponInputField;
    public List<string> coupon;
    public CouponUsingData data;
    private int a;



    public GameObject couponButton;



    public void ClickYes()
    {

        if (couponInputField.text.ToLower() == coupon[0].ToLower())
            a = 0;
        else if (couponInputField.text.ToLower() == coupon[1].ToLower())
            a = 1;
        else if (couponInputField.text.ToLower() == coupon[2].ToLower())
            a = 2;
        else if (couponInputField.text.ToLower() == coupon[3].ToLower())
            a = 3;
        else if (couponInputField.text.ToLower() == coupon[4].ToLower())
            a = 4;
        else if (couponInputField.text.ToLower() == coupon[5].ToLower())
            a = 5;
        else if (couponInputField.text.ToLower() == coupon[6].ToLower())
            a = 6;
        else if (couponInputField.text.ToLower() == coupon[7].ToLower())
            a = 7;
        else if (couponInputField.text.ToLower() == coupon[8].ToLower())
            a = 8;
        else if (couponInputField.text.ToLower() == coupon[9].ToLower())
            a = 9;
        else if (couponInputField.text.ToLower() == coupon[10].ToLower())
            a = 10;
        else if (couponInputField.text.ToLower() == coupon[11].ToLower())
            a = 11;
        else if (couponInputField.text.ToLower() == coupon[12].ToLower())
            a = 12;
        else if (couponInputField.text.ToLower() == coupon[13].ToLower())
            a = 13;
        else if (couponInputField.text.ToLower() == coupon[14].ToLower())
            a = 14;
        else if (couponInputField.text.ToLower() == coupon[15].ToLower())
            a = 15;
        else if (couponInputField.text.ToLower() == coupon[16].ToLower())
            a = 16;
        else if (couponInputField.text.ToLower() == coupon[17].ToLower())
            a = 17;
        else if (couponInputField.text.ToLower() == coupon[18].ToLower())
            a = 18;
        else
            a = data.isGetCoupon.Length;

        if (a >= coupon.Count)
        {
            answerText.text = "쿠폰번호가 잘못되었습니다";
        }
        else if (!data.isGetCoupon[a] && couponInputField.text.ToLower() == coupon[a].ToLower())
        {
            switch (a)
            {
                case 0:
                    GameManager.Instance.gold += 1000000000;
                    UIManager.Instance.UpdateGoldText();
                    break;
                case 1:
                    GameManager.Instance.adamant += 10000000;
                    UIManager.Instance.UpdateAdamantText();
                    break;
                case 2:
                    for (int i = 0; i < ItemDB.Instance.itemPrefabs.Length; i++)
                    {
                        for (int j = 0; j < 40; j++)
                            ItemManager.Instance.AddItem(ItemDB.Instance.itemPrefabs[i]);
                    }
                    break;
                case 3:
                    for (int j = 0; j < GameManager.Instance.isGetKey.Length-1; j++)
                    {
                        GameManager.Instance.isGetKey[j] = true;

                    }
                    break;
                case 4:
                    ItemManager.Instance.isBuyPermanentStoreTicket = false;
                    break;
                case 5:
                    GameManager.Instance.adamant += 500;
                    UIManager.Instance.UpdateAdamantText();
                    data.isGetCoupon[a] = true;
                    break;
                case 6:
                    GameManager.Instance.adamant += 1000;
                    UIManager.Instance.UpdateAdamantText();
                    data.isGetCoupon[a] = true;;
                    break;
                case 7:
                    GameManager.Instance.adamant += 1500;
                    UIManager.Instance.UpdateAdamantText();
                    data.isGetCoupon[a] = true;
                    break;
                case 8:
                    GameManager.Instance.gold += 10000;
                    UIManager.Instance.UpdateGoldText();
                    data.isGetCoupon[a] = true;
                    break;
                case 9:
                    GameManager.Instance.gold += 10000;
                    UIManager.Instance.UpdateGoldText();
                    data.isGetCoupon[a] = true;
                    break;
                case 10:
                    SaveManager.Instance.Clear();
                    break;
                case 11:
                    Time.timeScale = 10.0f;
                    break;
                case 12:
                    Time.timeScale = 1.0f;

                    break;
                case 13:
                    for (int j = 0; j < GameManager.Instance.isGetKey.Length; j++)
                    {
                        GameManager.Instance.isGetKey[j] = false;

                    }
                    break;
                case 14:
                    for (int j = 0; j < data.isGetCoupon.Length-1; j++)
                    {
                        data.isGetCoupon[j] = false;

                    }
                    break;
                case 15:
                    Player.Instance.miningPower = Player.Instance.miningPower * 2;
                    break;
                case 16:
                    Player.Instance.miningPower = Player.Instance.miningPower / 2;
                    break;
                case 17:
                    Player.Instance.miningPower = Player.Instance.miningPower * 1.5f;
                    break;
                case 18:
                    Player.Instance.miningPower = Player.Instance.miningPower / 1.5f;
                    break;
                default:
                    break;

                
            }
            answerText.text = "보상획득";
        }
        else if (data.isGetCoupon[a] == true)
        {
            answerText.text = "이미 사용한 쿠폰입니다";
        }


    }

    public void ClickNo()
    {
        couponInputField.text = "";
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            couponButton.SetActive(false);
        }
        coupon.Add("flatmggm17201");
        coupon.Add("flatmggm17202");
        coupon.Add("flatmggm17203");
        coupon.Add("flatmggm17204");
        coupon.Add("flatmggm17205");
        coupon.Add("Thankyou");
        coupon.Add("HappyDrilling");
        coupon.Add("Dontgiveup");
        coupon.Add("HappyChuseok");
        coupon.Add("dudududu");
        coupon.Add("flatmggm17206");
        coupon.Add("flatmggm17207");
        coupon.Add("flatmggm17208");
        coupon.Add("flatmggm17209");
        coupon.Add("flatmggm172010");
        coupon.Add("flatmggm172011");
        coupon.Add("flatmggm172012");
        coupon.Add("flatmggm172013");
        coupon.Add("flatmggm172014");
        Array.Resize(ref data.isGetCoupon, coupon.Count);

    }
}
[System.Serializable]
public class CouponUsingData
{
    public bool[] isGetCoupon = new bool[4] {false,false,false,false};
}
