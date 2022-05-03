using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementSetting : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI requirement;
    public TextMeshProUGUI reward;
    public TextMeshProUGUI sub;
    public int questBoxNum;
    [SerializeField]
    public AchievementData data;
    private Button rewardButton;
    public Image buttonImage;
    private Color originColor = new Color(163 / 255f, 187 / 255f, 191 / 255f);
    private Color clearColor = new Color(81 / 255f, 255 / 255f, 111 / 255f);

    public void ButtonClick()
    {
        if (AchievementManager.Instance.achievementManagerData.isGetReward[questBoxNum] == true) //(data._requirement == )
        {
        SoundManager.Instance.clickAudioSource.Play();
            switch (questBoxNum)
            {
                case 0: 
                    Player.Instance.miningPower += data._reward;
                    SceneMoveManager.Instance.rainbowTileData.health = Player.Instance.miningPower * 2.8f;
                    break;
                case 1:
                    Player.Instance.maxOxygen += (int)data._reward;
                    UIManager.Instance.oxygenSlider.maxValue = Player.Instance.maxOxygen;
                    break;
                case 2:
                    AchievementManager.Instance.achievementManagerData.clickerMinusTime += (int)data._reward;
                    break;
                case 3:
                    if (AchievementManager.Instance.achievementManagerData.currentQuestNum[questBoxNum] == 0)
                    {
                        AchievementManager.Instance.achievementManagerData.inventoryCount += (int)data._reward;
                        ClickerManager.Instance.maxMineralCapacity += (int)data._reward;

                    }
                    else if (AchievementManager.Instance.achievementManagerData.currentQuestNum[questBoxNum] == 1)
                    {
                        Player.Instance.miningPower += data._reward;
                        SceneMoveManager.Instance.rainbowTileData.health = Player.Instance.miningPower * 2.8f;
                    }
                    break;
                case 4:
                    Player.Instance.maxHealth += (int)data._reward;
                    UIManager.Instance.HealthSlider.maxValue = Player.Instance.maxHealth;
                    break;
                case 5:
                    if (AchievementManager.Instance.achievementManagerData.currentQuestNum[questBoxNum] %2== 0)
                    {
                        Player.Instance.miningPower += data._reward;
                        SceneMoveManager.Instance.rainbowTileData.health = Player.Instance.miningPower * 2.8f;
                    }
                    else if (AchievementManager.Instance.achievementManagerData.currentQuestNum[questBoxNum]%2 == 1)
                    {
                        AchievementManager.Instance.achievementManagerData.inventoryCount += (int)data._reward;
                        ClickerManager.Instance.maxMineralCapacity += (int)data._reward;
                    }
                    break;
                case 6:
                    AchievementManager.Instance.achievementManagerData.plusFeul += data._reward;
                    Player.Instance.maxFuel += data._reward;
                    UIManager.Instance.fuelSlider.maxValue = Player.Instance.maxFuel;
                    break;
                default:
                    break;
            }
            AchievementManager.Instance.achievementManagerData.isGetReward[questBoxNum] = false;
            AchievementManager.Instance.achievementManagerData.currentQuestNum[questBoxNum]++;
            FindQuest();
            ShowUI();
            CheckAchievementRewards.Instance.CheckRewards();
        }
        else
        {
            SoundManager.Instance.clickFailAudioSource.Play();
        }

    }

    public void ShowUI()
    {
        if (data != null)
        {
            switch (questBoxNum)
            {
                case 0:
                    sub.text = "드릴파워";
                    reward.text = "+" + (data._reward * 100).ToString();
                    requirement.text = "현재 레벨 : " + Player.Instance.drillLevel;
                    break;
                case 1:
                    sub.text = "산소총량";
                    reward.text = "+" + data._reward.ToString();
                    requirement.text = "현재 레벨 : " + Player.Instance.capLevel;
                    break;
                case 2:
                    sub.text = "자동굴착기 주기";
                    reward.text = "-" + data._reward.ToString()+"초";
                    requirement.text = "현재 레벨 : " + ClickerManager.Instance.drillLevel;
                    break;
                case 3:
                    if (data._questNum%2 ==0)
                    {
                        sub.text = "자동굴착기 창고";
                        reward.text = "+" + data._reward.ToString() + "칸";
                    }
                    else
                    {
                        sub.text = "드릴파워";
                        reward.text = "+" + (data._reward*100).ToString();
                    }
                    requirement.text = "현재 레벨 : " + ClickerManager.Instance.InventoryLevel;
                    break;
                case 4:
                    sub.text = "체력";
                    reward.text = "+" + data._reward.ToString();
                    requirement.text = "";
                    break;
                case 5:
                    if (data._questNum % 2 == 0)
                    {
                        sub.text = "드릴파워";
                        reward.text = "+" + (data._reward*100).ToString();
                    }
                    else
                    {
                        sub.text = "자동굴착기 창고";
                        reward.text = "+" + data._reward.ToString() + "칸";

                    }
                    requirement.text = "사냥한 몬스터 수 : " + AchievementManager.Instance.achievementManagerData.killMonsters;
                    break;
                case 6:
                    sub.text = "부스터량";
                    reward.text = "+" + (data._reward*100).ToString();
                    requirement.text = "사용한 골드 : " + AchievementManager.Instance.achievementManagerData.useGold;
                    break;
                default:
                    break;
            }
            title.text = data._questName;

        }
        else
        {
            title.text = "끝";
            requirement.text = "";
            reward.text = "";
            sub.text = "";
            rewardButton.enabled = false;
        }
        AchievementManager.Instance.DrillUpgrade();
        AchievementManager.Instance.CapUpgrade();
        AchievementManager.Instance.ClickerLevel();
        AchievementManager.Instance.InvertoryLevel();
        AchievementManager.Instance.KillMonster();
        AchievementManager.Instance.UseMoney();
        AchievementManager.Instance.StageClear();

        if (AchievementManager.Instance.achievementManagerData.isGetReward[questBoxNum] == true)
        {
            buttonImage.color = clearColor;
        }
        else
        {
            buttonImage.color = originColor;
        }
    }

    public void FindQuest()
    {
        data = AchievementManager.Instance.achievementLists.Find(x => x._questNum == (AchievementManager.Instance.achievementManagerData.currentQuestNum[questBoxNum] + (questBoxNum * 1000)));
        
    }

    private void Awake()
    {
        rewardButton = this.GetComponentInChildren<Button>();
        FindQuest();
        ShowUI();
    }

    private void OnEnable()
    {
        FindQuest();
        ShowUI();
        
    }

}
