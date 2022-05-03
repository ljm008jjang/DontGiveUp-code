using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AchievementData
{
    public string _questName; //퀘스트 명
    public int _questNum;
    public float _reward; //보상
    public int _requirement;

    //생성자
    public AchievementData() { }

    public AchievementData(string name, int questNum, float reward, int requirement)
    {
        _questName = name;
        _questNum = questNum;
        _reward = reward;
        _requirement = requirement;

    }
}
