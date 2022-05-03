using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AdamantBox : MonoBehaviour, IPointerClickHandler
{
    private static AdamantBox _Instance;
    WaitForSeconds ws = new WaitForSeconds(1);

    public Coroutine countCoroutine = null;

    public AdamantBoxData adamantBoxData;

    public static AdamantBox Instance
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
        count = adamantBoxData.count;
        reward = adamantBoxData.reward;
        if (countCoroutine == null)
            countCoroutine = StartCoroutine(CountTime());
    }

    public int count = 300;
    public int reward = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Player.Instance.playerData.isFirstStart)
        {
            UIManager.Instance.OpenAdamantBoxPanel();
        }
           
    }

    public void ShowAD()
    {
        if (count >= 300 && Application.internetReachability != NetworkReachability.NotReachable)
        {
            
            //count--;
            SoundManager.Instance.clickAudioSource.Play();
            UIManager.Instance.CloseAdamantBoxPanel();
            AdsManager.Instance.admob_Rewards[2].ShowRewardedAd();
        }
        else
        {
            SoundManager.Instance.clickFailAudioSource.Play();
        }
    }
    public IEnumerator CountTime()
    {
        StartCoroutine(UIManager.Instance.AdamantBoxSliderUpdate());

        while(count >= 0 && count < 300)
        {
            yield return ws;
            if(!Player.Instance.playerData.isFirstStart)
            count++;
        }

        count = 300;

        if (reward.Equals(0))
        {
            reward = UnityEngine.Random.Range(0, 11);

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

            reward += 90 + tmp;
        }

        countCoroutine = null;

    }
}

[System.Serializable]
public class AdamantBoxData{
    public int count;
    public int reward;
}
