#if UNITY_IOS
using UnityEngine;
using UnityEngine.UI;

public class UIBindings : MonoBehaviour
{
    private const string ICLOUD_KEY = "myAppKey";



    void ShowBasicAlert() 
    {
        iOSPlugin.ShowAlert("Basic Alert", "Hello this is a basic alert !");
    }

    void ShowAlertConfirmation()
    {
        iOSPlugin.ShowAlertConfirmation("Basic Alert Confirmation", "Hello this is a basic confirmation !", "CallBack");
    }

    void RotateUpAlertConfirmation()
    {
        iOSPlugin.ShowAlertConfirmation("Rotating Up", "Should I Rotate Up?", "RotateUpCallBack");
    }

    void RotateDownAlertConfirmation()
    {
        iOSPlugin.ShowAlertConfirmation("Rotating Down", "Should I Rotate Down?", "RotateDownCallBack");
    }

    void ShareMessage()
    {
        iOSPlugin.ShareMessage("Sharing a message!", "https://www.youtube.com/c/dilmervalecillos");
    }

    void BatteryStatus()
    {
        var batteryStatus = iOSPlugin.GetBatteryStatus();
        iOSPlugin.ShowAlert("Battery Status", batteryStatus.ToString());
    }

    void BatteryLevel()
    {
        string batteryLevel = iOSPlugin.GetBatteryLevel();
        iOSPlugin.ShowAlert("Battery Level", batteryLevel);
    }

    /*
    void iCloudGetValue()
    {
        string savedValue = iOSPlugin.iCloudGetStringValue(ICLOUD_KEY);

        SaveManager.Instance.Clear();
            //LogText.text = "4";
            string[] data = savedValue.Split('^');


            //byte[] bytes = System.Convert.FromBase64String(data);
            //string[] reformat = System.Text.Encoding.UTF8.GetString(bytes).Split('^');

            File.WriteAllText(Application.persistentDataPath + "/PlayerData.json",data[0]);
            File.WriteAllText(Application.persistentDataPath + "/GameManagerData.json", data[1]);
            File.WriteAllText(Application.persistentDataPath + "/ItemManagerData.json", data[2]);
            File.WriteAllText(Application.persistentDataPath + "/ClickerManagerData.json", data[3]);
            File.WriteAllText(Application.persistentDataPath + "/DrillPowerData.json", data[4]);
            File.WriteAllText(Application.persistentDataPath + "/ClickerPowerData.json", data[5]);
            File.WriteAllText(Application.persistentDataPath + "/QuestManagerData.json", data[6]);
            File.WriteAllText(Application.persistentDataPath + "/SettingManagerData.json", data[7]);
            File.WriteAllText(Application.persistentDataPath + "/AchievementManagerData.json", data[8]);
            File.WriteAllText(Application.persistentDataPath + "/CashStoreManagerData.json", data[9]);
            File.WriteAllText(Application.persistentDataPath + "/AdamantBoxData.json", data[10]);
            File.WriteAllText(Application.persistentDataPath + "/MoneyBoxData.json", data[11]);
            File.WriteAllText(Application.persistentDataPath + "/CouponData.json", data[12]);

            int count = ((int)((data.Length - 13) * 0.25 + 0.1f));
            int k = 1;

            for (int i=1; i <= count; i++)
            {
                
                File.WriteAllText(Application.persistentDataPath + "/TileMap" + i + ".json", data[13+k]);
                k++;
                File.WriteAllText(Application.persistentDataPath + "/MineralData" + i + ".json", data[13 + k]);
                k++;
                File.WriteAllText(Application.persistentDataPath + "/DeadBoxData" + i + ".json", data[13 + k]);
                k++;
                File.WriteAllText(Application.persistentDataPath + "/MonsterManagerData" + i + ".json", data[13 + k]);
                k++;
            }


            // TileSave tileData = JsonUtility.FromJson<TileSave>(data[11 + GameManager.Instance.currentSceneIndex]);

            //LogText.text = "5";
            SaveManager.Instance.CloudLoad();

        UIManager.Instance.UpdateGoldText();
            UIManager.Instance.UpdateUsableItemUI();
            UIManager.Instance.UpdateStageText();

        iOSPlugin.ShowAlert("iCloud Value", string.IsNullOrEmpty(savedValue) ? "Nothing Saved Yet..." : savedValue);
    }

    void iCloudSaveValue()
    {
        SaveManager.Instance.Save();

        //string valueToSave = System.Guid.NewGuid().ToString();

        string str = File.ReadAllText(Application.persistentDataPath + "/PlayerData.json");
            str += "^" + File.ReadAllText(Application.persistentDataPath + "/GameManagerData.json");
            str += "^" + File.ReadAllText(Application.persistentDataPath + "/ItemManagerData.json");
            str += "^" + File.ReadAllText(Application.persistentDataPath + "/ClickerManagerData.json");
            str += "^" + File.ReadAllText(Application.persistentDataPath + "/DrillPowerData.json");
            str += "^" + File.ReadAllText(Application.persistentDataPath + "/ClickerPowerData.json");
            str += "^" + File.ReadAllText(Application.persistentDataPath + "/QuestManagerData.json");
            str += "^" + File.ReadAllText(Application.persistentDataPath + "/SettingManagerData.json");
            str += "^" + File.ReadAllText(Application.persistentDataPath + "/AchievementManagerData.json");
            str += "^" + File.ReadAllText(Application.persistentDataPath + "/CashStoreManagerData.json");
            str += "^" + File.ReadAllText(Application.persistentDataPath + "/AdamantBoxData.json");
            str += "^" + File.ReadAllText(Application.persistentDataPath + "/MoneyBoxData.json");
            str += "^" + File.ReadAllText(Application.persistentDataPath + "/CouponData.json");
            for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                if(File.Exists(Application.persistentDataPath + "/TileMap" + i + ".json"))
                {
                    str += "^" + File.ReadAllText(Application.persistentDataPath + "/TileMap" + i + ".json");
                    str += "^" + File.ReadAllText(Application.persistentDataPath + "/MineralData" + i + ".json");
                    str += "^" + File.ReadAllText(Application.persistentDataPath + "/DeadBoxData" + i + ".json");
                    str += "^" + File.ReadAllText(Application.persistentDataPath + "/MonsterManagerData" + i + ".json");
                }
            }

        bool success = iOSPlugin.iCloudSaveStringValue(ICLOUD_KEY, str);
        
        if(success)
        {
            iOSPlugin.ShowAlert("iCloud Value Saved Success", str);
        }
        else 
        {
            iOSPlugin.ShowAlert("iCloud Value Saved failed", str);
        }
    }
    */
}
#endif