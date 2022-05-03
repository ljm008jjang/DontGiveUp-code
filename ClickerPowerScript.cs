using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerPowerScript : MonoBehaviour, IPointerClickHandler
{
    private static ClickerPowerScript _Instance;

    public static ClickerPowerScript Instance
    {
        get
        {
            return _Instance;
        }
    }


    WaitForSeconds ws = new WaitForSeconds(30);
    WaitForSeconds oneSec = new WaitForSeconds(1);
    public int maxGauge = 180;
    public int gauge = 180;
    //public int level = 0;
    public bool isOn;
    public bool isADOn = true;
    public ClickerPowerData clickerPowerData;
    public Animator animator;
    [SerializeField]
    float tmpF;

    private void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
        //StartCoroutine(CountTime());
        GetVariable();
        tmpF = ClickerManager.Instance.period;
    }

    public void GetVariable()
    {
        if (!isOn)
            isOn = clickerPowerData.isOn;
        maxGauge = clickerPowerData.maxGauge;
        gauge = clickerPowerData.gauge;
        //level = clickerPowerData.level;
        if (isOn)
        {
            StartCoroutine(CountTime());
            StartCoroutine(UIManager.Instance.ClickerPowerUpUIUpdate());
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (gauge>=maxGauge)
        {
            SoundManager.Instance.clickAudioSource.Play();
            gauge = 0;
            StartCoroutine(ClickerAmplification());
            StartCoroutine(CountTime());
            StartCoroutine(UIManager.Instance.ClickerPowerUpUIUpdate());
        }else
        SoundManager.Instance.clickFailAudioSource.Play();
    }

    IEnumerator ClickerAmplification()//작동중 저장하고 끄면 어케되지?
    {
        float clickerCoeffient;
        //WaitForSeconds tmpWs = ClickerManager.Instance.ws;
        clickerCoeffient = 1-(CashStoreManager.Instance.clickerLevel * 0.05f); 
        ClickerManager.Instance.tmpF *=  clickerCoeffient;//업그레이드시 clickerCoeffient 감소
        /*
        if(tmpF < 0.1f)
        {
            tmpF = 0.1f;
        }
        */
        ClickerManager.Instance.ws = new WaitForSeconds(ClickerManager.Instance.tmpF);

        animator.SetBool("isOn", true);

        yield return ws;

        animator.SetBool("isOn", false);

        ClickerManager.Instance.tmpF /= clickerCoeffient;

        ClickerManager.Instance.ws = new WaitForSeconds(ClickerManager.Instance.tmpF);


    }


    IEnumerator CountTime()//이어서 해야됨
    {
        while (gauge < maxGauge)
        {
            gauge += 1;
            yield return oneSec;
        }
    }

}

[System.Serializable]
public class ClickerPowerData
{
    public bool isOn = false;
    public int maxGauge = 300;
    public int gauge = 300;
    public int level = 0;
}