using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrillPowerScript : MonoBehaviour, IPointerClickHandler//버프
{
    private static DrillPowerScript _Instance;

    public static DrillPowerScript Instance
    {
        get
        {
            return _Instance;
        }
    }

    WaitForSeconds ws = new WaitForSeconds(60);
    WaitForSeconds oneSec = new WaitForSeconds(1);
    public int maxGauge = 300;
    public int gauge = 300;
    //public int level = 0;
    //public int cost;
    [SerializeField]
    float DrillCoeffient;
    public bool isOn;
    public DrillPowerData drillPowerData;
    public Animator animator;

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
        if(!isOn)
            isOn = drillPowerData.isOn;
        maxGauge = drillPowerData.maxGauge;
        gauge = drillPowerData.gauge;
        if (isOn)
        {
            StartCoroutine(CountTime());
            StartCoroutine(UIManager.Instance.DrillPowerUpUIUpdate());
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gauge>=maxGauge)
        {
            SoundManager.Instance.clickAudioSource.Play();
            gauge = 0;
            StartCoroutine(DrillAmplification());
            StartCoroutine(CountTime());
            StartCoroutine(UIManager.Instance.DrillPowerUpUIUpdate());
        }else
        SoundManager.Instance.clickFailAudioSource.Play();
    }
    IEnumerator DrillAmplification()//작동중 저장하고 끄면 어케되지? 작동중 드릴 업그레이드하면?
    {
        Player.Instance.miningPowerBuffCoefficient += 0.1f * CashStoreManager.Instance.drillLevel;

        animator.SetBool("isOn", true);

        yield return ws;

        animator.SetBool("isOn", false);

        Player.Instance.miningPowerBuffCoefficient -= 0.1f * CashStoreManager.Instance.drillLevel;
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
public class DrillPowerData
{
    public bool isOn = false;
    public int maxGauge = 300;
    public int gauge = 300;
    //public int level = 0;
}
