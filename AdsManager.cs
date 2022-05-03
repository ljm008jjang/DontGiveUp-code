using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{

    private static AdsManager instance;

    public static AdsManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AdsManager>();

                if (instance == null)
                {
                    GameObject container = new GameObject("AdsManager");
                    instance = container.AddComponent<AdsManager>();
                }
            }
            return instance;
        }
    }

    public Admob_reward[] admob_Rewards;
    public bool isRewardVideoEnd = true;


}
