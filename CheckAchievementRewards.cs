using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class CheckAchievementRewards : MonoBehaviour
{
    private static CheckAchievementRewards instance;
    float[] rewards = new float[6];
    public static CheckAchievementRewards Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CheckAchievementRewards>();

                if (instance == null)
                {
                    GameObject container = new GameObject("CheckAchievementRewards");
                    instance = container.AddComponent<CheckAchievementRewards>();
                }
            }
            return instance;
        }
    }

    public TextMeshProUGUI[] text;
    // Start is called before the first frame update
    void Start()
    {
        CheckRewards();
    }
    private void Update()
    {
        CheckRewards();
    }

    public void CheckRewards()
    {
        int[] tempNum = AchievementManager.Instance.achievementManagerData.currentQuestNum;
        float[] tempReward = new float[6];
        for (int i = 0; i < tempNum.Length; i++)
        {
            for (int j = 0; j < tempNum[i]; j++)
            {
                var tempData = AchievementManager.Instance.achievementLists.Find(x => x._questNum == (j + (i * 1000)));
                switch (i)
                {
                    case 0:
                        tempReward[0] += tempData._reward;
                        break;
                    case 1:
                        tempReward[1] += tempData._reward;
                        break;
                    case 2:
                        tempReward[4] += tempData._reward;
                        break;
                    case 3:
                        if (j == 0)
                        {
                            tempReward[5] += tempData._reward;
                        }
                        else
                        {
                            tempReward[0] += tempData._reward;
                        }
                        break;
                    case 4:
                        tempReward[2] += tempData._reward;
                        break;
                    case 5:
                        if (j %2== 0)
                        {
                            tempReward[0] += tempData._reward;
                        }
                        else
                        {
                            
                            tempReward[5] += tempData._reward;
                        }
                        break;

                    case 6:
                        tempReward[3] += tempData._reward;
                        break;
                    default:
                        break;

                }
            }
        }
        rewards = tempReward;
        text[0].text = "드릴파워 : +" + tempReward[0]*100;
        text[1].text = "산소량 : +" + tempReward[1];
        text[2].text = "체력 : +" + tempReward[2];
        text[3].text = "부스터량 : +" + tempReward[3]*100;
        text[4].text = "자동굴착기 주기 : -" + tempReward[4] + "초";
        text[5].text = "자동굴착기 창고 : +" + tempReward[5] + "칸";

    }
}
