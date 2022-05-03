using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenUpdate : MonoBehaviour// 앞으로 업데이트할때 체크할 변수와 함수들은 여기에 모아두기
{
    public WhenUpdateData whenUpdataData;

    public bool firstUpdate_104 = true;


    private void Start()
    {
        GetVariable();
        WhenUpdate104();
    }

    public void GetVariable()
    {
        firstUpdate_104 = whenUpdataData.firstUpdate_104;
    }

    void WhenUpdate104()
    {
        if (firstUpdate_104)
        {
            /*
            Debug.Log(CashStoreManager.Instance.cashStoreManagerData.drillLevel);

            switch (CashStoreManager.Instance.cashStoreManagerData.drillLevel)
            {
                case 1:
                    GameManager.Instance.adamant += 400;
                    break;
                case 2:
                    GameManager.Instance.adamant += 1200;
                    break;
                case 3:
                    GameManager.Instance.adamant += 2400;
                    break;
                case 4:
                    GameManager.Instance.adamant += 4000;
                    break;
                case 5:
                    GameManager.Instance.adamant += 6000;
                    break;
                case 6:
                    GameManager.Instance.adamant += 8500;
                    break;
                case 7:
                    GameManager.Instance.adamant += 11500;
                    break;
                case 8:
                    GameManager.Instance.adamant += 15100;
                    break;
                case 9:
                    GameManager.Instance.adamant += 20100;
                    break;
                case 10:
                    GameManager.Instance.adamant += 27600;
                    break;
                case 11:
                    GameManager.Instance.adamant += 37600;
                    break;
                case 12:
                    GameManager.Instance.adamant += 52600;
                    break;
            }

            */
            firstUpdate_104 = false;
        }
       
         
    }
}

[System.Serializable]
public class WhenUpdateData
{
    public bool firstUpdate_104 = true;
}
