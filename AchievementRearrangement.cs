using System;
using UnityEngine;

public class AchievementRearrangement : MonoBehaviour
{
    public AchievementSetting[] achievementObjects;
    //private int[]
    // Start is called before the first frame update
    void Start()
    {
        Array.Resize<AchievementSetting>(ref achievementObjects, this.GetComponentsInChildren<AchievementSetting>().Length);
        achievementObjects = this.GetComponentsInChildren<AchievementSetting>();


    }

    public void Rearrangement()
    {
        foreach (var item in achievementObjects)
        {

            if (item.reward.text == ""/*item.gameObject.GetComponent<Button>().enabled == false*/)
            {
                item.gameObject.transform.SetAsLastSibling();
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        Rearrangement();
    }
}
