using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CloudAchvAndRankManager : MonoBehaviour
{
    private static CloudAchvAndRankManager _Instance;

    public static CloudAchvAndRankManager Instance
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

    //업적 = ReportProgress
    //리더보드 =ReportScore
    //https://twocap.tistory.com/22 참고

    //Social.ReportScore("Dontgiveup.gold.rank.classic",gold, null);
    // Start is called before the first frame update
    public void Gold()
    {
#if UNITY_ANDROID
        GooglePlayGames.PlayGamesPlatform.Instance.ReportScore(GameManager.Instance.gold, "CgkI1p7mtbgfEAIQAw", null);
#elif UNITY_IOS
        Social.ReportScore(GameManager.Instance.gold, "Dontgiveup.gold.rank.classic",null);
#endif
    }

    public void Achiv()
    {
#if UNITY_ANDROID
        Social.ReportProgress("CgkI1p7mtbgfEAIQAg", 100f, null);
#endif
    }
}
