using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject FailUI;
    public GameObject SuccessUI;
    public GameObject afterBuyButton;
    public GameObject beforeBuyButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.playerData.isBuyApart == true)
        {
            AfterBuyBtn();
        }
    }

    public void BuyApartment()
    {
        if (GameManager.Instance.gold >= 1000000000)
        {
            SuccessUI.SetActive(true);
            SoundManager.Instance.clickAudioSource.Play();
        }
        else
        {
            FailUI.SetActive(true);
            SoundManager.Instance.clickAudioSource.Play();
        }
    }

    public void RealBuy()
    {
        GameManager.Instance.gold -= 1000000000;
        Player.Instance.playerData.isBuyApart = true;
        SaveManager.Instance.Save();
        SoundManager.Instance.clickAudioSource.Play();
    }

    public void AfterBuyBtn()
    {
        afterBuyButton.SetActive(Player.Instance.playerData.isBuyApart);
        beforeBuyButton.SetActive(!Player.Instance.playerData.isBuyApart);
    }

}
