using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    private static AchievementManager instance;

    public static AchievementManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AchievementManager>();

                if (instance == null)
                {
                    GameObject container = new GameObject("AchievementManager");
                    instance = container.AddComponent<AchievementManager>();
                }
            }
            return instance;
        }
    }

    public List<AchievementData> achievementLists = new List<AchievementData>();
    public AchievementManagerData achievementManagerData;

    private void Awake()
    {
        instance = this;
        SettingList();

    }

    public void DrillUpgrade()
    {
        var temp = achievementLists.Find(x => x._questNum == (achievementManagerData.currentQuestNum[0]));
        if (temp != null)
        {
            if (Player.Instance.drillLevel >= temp._requirement && temp != null)
            {
                achievementManagerData.isGetReward[0] = true;
            }
        }
    }

    public void CapUpgrade()
    {
        var temp = achievementLists.Find(x => x._questNum == (achievementManagerData.currentQuestNum[1])+1000);
        if (temp != null)
        {
            if (Player.Instance.capLevel >= temp._requirement && temp != null)
            {
                achievementManagerData.isGetReward[1] = true;
            }
        }
    }

    public void ClickerLevel()
    {
        var temp = achievementLists.Find(x => x._questNum == (achievementManagerData.currentQuestNum[2])+2000);
        if (temp != null)
        {
            if (ClickerManager.Instance.drillLevel >= temp._requirement)
            {
                achievementManagerData.isGetReward[2] = true;
            }

        }
    }
    public void InvertoryLevel()
    {
        var temp = achievementLists.Find(x => x._questNum == (achievementManagerData.currentQuestNum[3])+3000);
        if (temp != null)
        {
            if (ClickerManager.Instance.InventoryLevel >= temp._requirement)
            {
                achievementManagerData.isGetReward[3] = true;
            }
        }
    }
    public void StageClear()
    {
        var temp = achievementLists.Find(x => x._questNum == (achievementManagerData.currentQuestNum[4])+4000);
        if (temp != null)
        {
            if (QuestManager.Instance.questManagerData.sceneLevel / 1000 >= temp._requirement+1)
            {
                achievementManagerData.isGetReward[4] = true;
            }
        }
    }
    public void KillMonster()
    {
        var temp = achievementLists.Find(x => x._questNum == (achievementManagerData.currentQuestNum[5]) + 5000);
        if (temp != null)
        {
            if (achievementManagerData.killMonsters >= temp._requirement)
            {
                achievementManagerData.isGetReward[5] = true;
            }
        }
    }

    public void UseMoney()
    {
        var temp = achievementLists.Find(x => x._questNum == (achievementManagerData.currentQuestNum[6] + 6000));
        if (temp != null)
        {
            if (achievementManagerData.useGold >= temp._requirement)
            {
                achievementManagerData.isGetReward[6] = true;
            }
        }
    }

    void SettingList()
    {
        // 퀘스트제목, 퀘스트넘버, 퀘스트보상1, 퀘스트보상2, 퀘스트목표
        // 드릴업그레이드(드릴파워)
        achievementLists.Add(new AchievementData("드릴 최초 업그레이드", 0, 0.1f, 2));
        achievementLists.Add(new AchievementData("드릴 10레벨 달성", 1, 0.5f, 10));
        achievementLists.Add(new AchievementData("드릴 20레벨 달성", 2, 1.0f, 20));
        achievementLists.Add(new AchievementData("드릴 30레벨 달성", 3, 1.5f, 30));
        //achievementLists.Add(new AchievementData("드릴 40레벨 달성", 4, 2.0f, 40));
        //achievementLists.Add(new AchievementData("드릴 50레벨 달성", 5, 2.5f, 50));
        //achievementLists.Add(new AchievementData("드릴 60레벨 달성", 6, 3.0f, 60));


        //모자 업그레이드(산소 총량)
        achievementLists.Add(new AchievementData("모자 최초 업그레이드", 1000, 1.0f, 2));
        achievementLists.Add(new AchievementData("모자 10레벨 달성", 1001, 10.0f, 10));
        achievementLists.Add(new AchievementData("모자 20레벨 달성", 1002, 15.0f, 20));
        achievementLists.Add(new AchievementData("모자 30레벨 달성", 1003, 20.0f, 30));
        //achievementLists.Add(new AchievementData("모자 40레벨 달성", 1004, 25.0f, 40));
        //achievementLists.Add(new AchievementData("모자 50레벨 달성", 1005, 30.0f, 50));
        //achievementLists.Add(new AchievementData("모자 60레벨 달성", 1006, 35.0f, 60));


        //클리커 드릴 업그레이드(생산주기 감소)
        achievementLists.Add(new AchievementData("자동굴착기 5레벨 달성", 2000, 1.0f, 5));
        achievementLists.Add(new AchievementData("자동굴착기 12레벨 달성", 2001, 1.0f, 12));
        achievementLists.Add(new AchievementData("자동굴착기 18레벨 달성", 2002, 1.0f, 18));

        //창고 업그레이드(창고 추가, 드릴파워)
        achievementLists.Add(new AchievementData("창고 10레벨 달성", 3000, 10.0f, 10));
        achievementLists.Add(new AchievementData("창고 15레벨 달성", 3001, 0.5f, 15));
        achievementLists.Add(new AchievementData("창고 20레벨 달성", 3002, 10.0f, 20));
        achievementLists.Add(new AchievementData("창고 25레벨 달성", 3003, 1.0f, 25));
        achievementLists.Add(new AchievementData("창고 30레벨 달성", 3004, 10.0f, 30));
        achievementLists.Add(new AchievementData("창고 35레벨 달성", 3005, 1.5f, 35));
        achievementLists.Add(new AchievementData("창고 40레벨 달성", 3006, 10.0f, 40));

        //스테이지 클리어(추가체력)
        achievementLists.Add(new AchievementData("스테이지 1클리어", 4000, 10.0f, 1));
        achievementLists.Add(new AchievementData("스테이지 2클리어", 4001, 10.0f, 2));
        achievementLists.Add(new AchievementData("스테이지 3클리어", 4002, 10.0f, 3));
        achievementLists.Add(new AchievementData("스테이지 4클리어", 4003, 10.0f, 4));
        achievementLists.Add(new AchievementData("스테이지 5클리어", 4004, 10.0f, 5));
        achievementLists.Add(new AchievementData("스테이지 6클리어", 4005, 10.0f, 6));
        achievementLists.Add(new AchievementData("스테이지 7클리어", 4006, 10.0f, 7));
        achievementLists.Add(new AchievementData("스테이지 8클리어", 4007, 10.0f, 8));
        achievementLists.Add(new AchievementData("스테이지 9클리어", 4008, 10.0f, 9));
        achievementLists.Add(new AchievementData("스테이지 10클리어", 4009, 10.0f, 10));

        //몬스터처지(다이아?)
        achievementLists.Add(new AchievementData("몬스터 1마리 처치", 5000, 0.1f, 1));
        achievementLists.Add(new AchievementData("몬스터 3마리 처치", 5001, 5.0f, 3));
        achievementLists.Add(new AchievementData("몬스터 5마리 처치", 5002, 0.3f, 5));
        achievementLists.Add(new AchievementData("몬스터 10마리 처치", 5003, 5.0f, 10));
        achievementLists.Add(new AchievementData("몬스터 20마리 처치", 5004, 0.5f, 20));
        achievementLists.Add(new AchievementData("몬스터 30마리 처치", 5005, 5.0f, 30));
        achievementLists.Add(new AchievementData("몬스터 40마리 처치", 5006, 0.5f, 40));
        achievementLists.Add(new AchievementData("몬스터 50마리 처치", 5007, 5.0f, 50));
        achievementLists.Add(new AchievementData("몬스터 75마리 처치", 5008, 0.5f, 75));
        achievementLists.Add(new AchievementData("몬스터 100마리 처치", 5009, 5.0f, 100));
        achievementLists.Add(new AchievementData("몬스터 125마리 처치", 5010, 0.5f, 125));
        achievementLists.Add(new AchievementData("몬스터 150마리 처치", 5011, 5.0f, 150));
        achievementLists.Add(new AchievementData("몬스터 175마리 처치", 5012, 0.5f, 175));
        achievementLists.Add(new AchievementData("몬스터 200마리 처치", 5013, 5.0f, 200));
        achievementLists.Add(new AchievementData("몬스터 225마리 처치", 5014, 0.5f, 225));
        achievementLists.Add(new AchievementData("몬스터 250마리 처치", 5015, 5.0f, 250));
        achievementLists.Add(new AchievementData("몬스터 275마리 처치", 5016, 0.5f, 275));
        achievementLists.Add(new AchievementData("몬스터 300마리 처치", 5017, 5.0f, 300));

        //골드사용(부스터 총량 증가) 
        achievementLists.Add(new AchievementData("골드 10만 사용", 6000, 0.2f, 100000));
        achievementLists.Add(new AchievementData("골드 30만 사용", 6001, 0.2f, 300000));
        achievementLists.Add(new AchievementData("골드 50만 사용", 6002, 0.2f, 500000));
        for (int i = 1; i < 21; i++)
        {
            achievementLists.Add(new AchievementData("골드 "+100*i +"만 사용", 6002 +i, 0.2f, 1000000*i));
        }

    }

}

[System.Serializable]
public class AchievementManagerData
{
    public int[] currentQuestNum = new int[7] { 0, 0, 0, 0, 0, 0, 0};
    public bool[] isGetReward = new bool[7] { false, false, false, false, false, false, false};
    public int stageScore;
    public int inventoryCount;
    public int killMonsters;
    public int useGold;
    public float plusFeul;
    public int clickerMinusTime;
}
