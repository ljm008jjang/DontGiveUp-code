using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.iOS;
//using UnityEngine.SocialPlatforms.GameCenter;
using System.IO;
using GooglePlayGames;
//using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using TMPro;
using UnityEngine.SceneManagement;

public class CloudScript : MonoBehaviour
{
    private static CloudScript _Instance;

    public static CloudScript Instance
    {
        get
        {
            return _Instance;
        }
    }

    private const string GOOGLE_KEY = "com.flatworld.mggm.gkey";
    private const string GOOGLE_KEY_M = "com.flatworld.mggm.gkeyM";
    private const string ICLOUD_KEY = "com.flatworld.mggm.ikey";
    private const string ICLOUD_KEY_M = "com.flatworld.mggm.ikeyM";

    public TextMeshProUGUI LogText;

    public bool isClick = false;

    
    private Firebase.FirebaseApp app;


    private void Awake()
    {
        _Instance = this;

        /*
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
        */

    }

    // Start is called before the first frame update
    void Start()
    {


#if UNITY_ANDROID
        var config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();
        PlayGamesPlatform.InitializeInstance(config);

        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        LogIn();
#elif UNITY_IOS
        GameCenterLogin();
#endif

    }

    public void LogIn()
    {
  
        Social.localUser.Authenticate((bool success) =>
        {
            //if (success) LogText.text = Social.localUser.id + "\n" + Social.localUser.userName;
            //else LogText.text = "구글 로그인 실패";
        });
    }


    #if UNITY_ANDROID
    public void LogOut()
    {
        ((PlayGamesPlatform)Social.Active).SignOut();
        //LogText.text = "구글 로그아웃";
    }

    ISavedGameClient SavedGame()
    {
        return PlayGamesPlatform.Instance.SavedGame;
    }



    #endif

    void OnSaveCompleteObj()
    {
        UIManager.Instance.saveCompleteObj.gameObject.SetActive(true);
        UIManager.Instance.saveCompleteText.text = "진행 중";

        UIManager.Instance.saveCompleteObj.color = new Color(UIManager.Instance.saveCompleteObj.color.r, UIManager.Instance.saveCompleteObj.color.g, UIManager.Instance.saveCompleteObj.color.b, 1f);
        UIManager.Instance.saveCompleteText.color = new Color(0, 0, 0, 1);
    }

    public void LoadCloud()
    {
        SoundManager.Instance.clickAudioSource.Play();
#if UNITY_ANDROID
        if (!isClick)
        {
            isClick = true;
            OnSaveCompleteObj();

            if (Application.internetReachability != NetworkReachability.NotReachable)
            {
                SavedGame().OpenWithAutomaticConflictResolution(GOOGLE_KEY,DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLastKnownGood, LoadGame);
                SavedGame().OpenWithAutomaticConflictResolution(GOOGLE_KEY_M, DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLastKnownGood, LoadGame_M);
            }
            
            else
            {
                LogText.text = "로드 실패";
                UIManager.Instance.SaveCompleteObjFadeOutF();
            }

        }
#elif UNITY_IOS
        if (!isClick){
            isClick = true;
            OnSaveCompleteObj();
            if(Application.internetReachability != NetworkReachability.NotReachable)
            iCloudGetValue();
            else{
                LogText.text = "로드 실패";
                UIManager.Instance.SaveCompleteObjFadeOutF();
            }
        }
        
#endif

    }

#if UNITY_ANDROID

    void LoadGame(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
            SavedGame().ReadBinaryData(game, LoadData);
    }

    void LoadGame_M(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
            SavedGame().ReadBinaryData(game, LoadData_M);
    }

    void LoadData(SavedGameRequestStatus status, byte[] LoadedData)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            SaveManager.Instance.Clear();
            //LogText.text = "4";
            string[] data = System.Text.Encoding.UTF8.GetString(LoadedData).Split('^');


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
            File.WriteAllText(Application.persistentDataPath + "/WhenUpdateData.json", data[13]);

            /*
            int count = ((int)((data.Length - 13) * 0.25 + 0.1f));
            int k = 1;

            for (int i=1; i <= count; i++)
            {
                
                File.WriteAllText(Application.persistentDataPath + "/TileMap" + i + ".json", data[12+k]);
                k++;
                File.WriteAllText(Application.persistentDataPath + "/MineralData" + i + ".json", data[12 + k]);
                k++;
                File.WriteAllText(Application.persistentDataPath + "/DeadBoxData" + i + ".json", data[12 + k]);
                k++;
                File.WriteAllText(Application.persistentDataPath + "/MonsterManagerData" + i + ".json", data[12 + k]);
                k++;
            }
            */


            //LogText.text = "5";
            //SaveManager.Instance.CloudLoad();

            //UIManager.Instance.UpdateGoldText();
            //UIManager.Instance.UpdateAdamantText();
            //UIManager.Instance.UpdateUsableItemUI();
            //UIManager.Instance.UpdateStageText();
          
           LogText.text = "로드 완료";
        }
        else
        {
            LogText.text = "로드 실패";
        }

        //UIManager.Instance.SaveCompleteObjFadeOutF();
    }

    void LoadData_M(SavedGameRequestStatus status, byte[] LoadedData)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            SaveManager.Instance.Clear();
            //LogText.text = "4";
            string[] data = System.Text.Encoding.UTF8.GetString(LoadedData).Split('^');


            //byte[] bytes = System.Convert.FromBase64String(data);
            //string[] reformat = System.Text.Encoding.UTF8.GetString(bytes).Split('^');
            /*
            File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", data[0]);
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
            */
            int count = ((int)((data.Length - 1) * 0.25 + 0.1f));
            int k = 1;

            for (int i = 1; i <= count; i++)
            {

                File.WriteAllText(Application.persistentDataPath + "/TileMap" + i + ".json", data[k]);
                k++;
                File.WriteAllText(Application.persistentDataPath + "/MineralData" + i + ".json", data[k]);
                k++;
                File.WriteAllText(Application.persistentDataPath + "/DeadBoxData" + i + ".json", data[k]);
                k++;
                File.WriteAllText(Application.persistentDataPath + "/MonsterManagerData" + i + ".json", data[k]);
                k++;
            }



            //LogText.text = "5";
            SaveManager.Instance.CloudLoad();

            UIManager.Instance.UpdateGoldText();
            UIManager.Instance.UpdateAdamantText();
            UIManager.Instance.UpdateUsableItemUI();
            UIManager.Instance.UpdateStageText();

            LogText.text = "로드 완료";
        }
        else
        {
            LogText.text = "로드 실패";
        }

        UIManager.Instance.SaveCompleteObjFadeOutF();
    }




    void SaveGame(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            SaveManager.Instance.Save();

            var update = new SavedGameMetadataUpdate.Builder().Build();
            //LogText.text = "1";
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
            str += "^" + File.ReadAllText(Application.persistentDataPath + "/WhenUpdateData.json");
            /*
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
            */
            //LogText.text = "2";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            

            SavedGame().CommitUpdate(game, update, bytes, SaveData);
            //LogText.text = "3";
        }
        else
        {
            LogText.text = "저장 실패";
            UIManager.Instance.SaveCompleteObjFadeOutF();
        }
    }

    void SaveGame_M(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            //SaveManager.Instance.Save();

            var update = new SavedGameMetadataUpdate.Builder().Build();
            //LogText.text = "1";
            /*
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
            */
            string str = "";
            for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                if (File.Exists(Application.persistentDataPath + "/TileMap" + i + ".json"))
                {
                    str += "^" + File.ReadAllText(Application.persistentDataPath + "/TileMap" + i + ".json");
                    str += "^" + File.ReadAllText(Application.persistentDataPath + "/MineralData" + i + ".json");
                    str += "^" + File.ReadAllText(Application.persistentDataPath + "/DeadBoxData" + i + ".json");
                    str += "^" + File.ReadAllText(Application.persistentDataPath + "/MonsterManagerData" + i + ".json");
                }
            }
            //LogText.text = "2";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);


            SavedGame().CommitUpdate(game, update, bytes, SaveData_M);
            //LogText.text = "3";
        }
        else
        {
            LogText.text = "저장 실패";
            UIManager.Instance.SaveCompleteObjFadeOutF();
        }
    }

    void SaveData(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            LogText.text = "저장 완료";
        }
        else
        {
            LogText.text = "저장 실패";
        }
        //UIManager.Instance.SaveCompleteObjFadeOutF();
    }

    void SaveData_M(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            LogText.text = "저장 완료";
        }
        else
        {
            LogText.text = "저장 실패";
        }
        UIManager.Instance.SaveCompleteObjFadeOutF();
    }


#elif UNITY_IOS

    void iCloudGetValue()
    {
        string savedValue = iOSPlugin.iCloudGetStringValue(ICLOUD_KEY);
        string savedValue_M = iOSPlugin.iCloudGetStringValue(ICLOUD_KEY_M);

        if(!string.IsNullOrEmpty(savedValue))
        {
            SaveManager.Instance.Clear();
            //LogText.text = "4";
            string[] data = savedValue.Split('^');


            //byte[] bytes = System.Convert.FromBase64String(data);
            //string[] reformat = System.Text.Encoding.UTF8.GetString(bytes).Split('^');

            File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", data[0]);
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
            File.WriteAllText(Application.persistentDataPath + "/WhenUpdateData.json", data[13]);
            
            int count = ((int)((data_M.Length - 1) * 0.25 + 0.1f));
            int k = 1;
            string[] data_M = savedValue_M.Split('^');

            for (int i = 1; i <= count; i++)
            {

                File.WriteAllText(Application.persistentDataPath + "/TileMap" + i + ".json", data_M[k]);
                k++;
                File.WriteAllText(Application.persistentDataPath + "/MineralData" + i + ".json", data_M[k]);
                k++;
                File.WriteAllText(Application.persistentDataPath + "/DeadBoxData" + i + ".json", data_M[k]);
                k++;
                File.WriteAllText(Application.persistentDataPath + "/MonsterManagerData" + i + ".json", data_M[k]);
                k++;
            }
            

            // TileSave tileData = JsonUtility.FromJson<TileSave>(data[11 + GameManager.Instance.currentSceneIndex]);

            //LogText.text = "5";
            SaveManager.Instance.CloudLoad();

            UIManager.Instance.UpdateGoldText();
            UIManager.Instance.UpdateUsableItemUI();
            UIManager.Instance.UpdateStageText();
            UIManager.Instance.UpdateAdamantText();

            LogText.text = "로드 성공";
        }
        else
        {
            LogText.text = "로드 실패";
        }
        UIManager.Instance.SaveCompleteObjFadeOutF();
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
        str += "^" + File.ReadAllText(Application.persistentDataPath + "/WhenUpdateData.json");


        string str_M = "";
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            if (File.Exists(Application.persistentDataPath + "/TileMap" + i + ".json"))
            {
                str_M += "^" + File.ReadAllText(Application.persistentDataPath + "/TileMap" + i + ".json");
                str_M += "^" + File.ReadAllText(Application.persistentDataPath + "/MineralData" + i + ".json");
                str_M += "^" + File.ReadAllText(Application.persistentDataPath + "/DeadBoxData" + i + ".json");
                str_M += "^" + File.ReadAllText(Application.persistentDataPath + "/MonsterManagerData" + i + ".json");
            }
        }

        bool success = iOSPlugin.iCloudSaveStringValue(ICLOUD_KEY, str);
        bool success_m = iOSPlugin.iCloudSaveStringValue(ICLOUD_KEY_M, str_M);

        if (success && success_m)
        {
            LogText.text = "저장 성공";
        }
        else
        {
            LogText.text = "저장 실패";
        }
        UIManager.Instance.SaveCompleteObjFadeOutF();
    }


     public void GameCenterLogin()
    {
        if (Social.localUser.authenticated == true)
        {
            //Debug.Log("Success to true");
        }
        else
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    //Debug.Log("Success to authenticate");
                }
                else
                {
                    //Debug.Log("Faile to login");
                }
            });
        }
    }
#endif

    public void SaveCloud()
    {
        SoundManager.Instance.clickAudioSource.Play();
        if (File.Exists(Application.persistentDataPath + "/PlayerData.json"))
        {
#if UNITY_ANDROID
            if (!isClick)
            {
                isClick = true;
                OnSaveCompleteObj();
                if (Application.internetReachability != NetworkReachability.NotReachable)
                {
                    SavedGame().OpenWithAutomaticConflictResolution(GOOGLE_KEY, DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLastKnownGood, SaveGame);
                    SavedGame().OpenWithAutomaticConflictResolution(GOOGLE_KEY_M, DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLastKnownGood, SaveGame_M);
                }
                    
                else
                {
                    LogText.text = "저장 실패";
                    UIManager.Instance.SaveCompleteObjFadeOutF();
                }
            }

#elif UNITY_IOS
            if (!isClick){
                isClick = true;
                OnSaveCompleteObj();
                if (Application.internetReachability != NetworkReachability.NotReachable)
                    iCloudSaveValue();
                    else
                {
                    LogText.text = "저장 실패";
                    UIManager.Instance.SaveCompleteObjFadeOutF();
                }
                
                
                    

            }
            
#endif
        }

    }



}
