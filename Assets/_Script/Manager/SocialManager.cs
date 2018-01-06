using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.SocialPlatforms;

public class SocialManager : MonoBehaviour {

    public static SocialManager instance;

    public enum ACHIEVE {
        ACHIEVE_1,ACHIEVE_2,ACHIEVE_3,ACHIEVE_4,ACHIEVE_5,ACHIEVE_6   
    }

    private readonly string GPGS_LEADERBOARD_ID = "CgkIkLSVpOIeEAIQAQ";
    private readonly string GPGS_LEADERBOARD_ID_INSANE = "CgkIkLSVpOIeEAIQAg";
    private readonly string IOS_LEADERBOARD_ID = "cg_world_record";
    private readonly string IOS_LEADERBOARD_ID_INSANE = "cg_insane_mode";

    private readonly string GPGS_ACHIEVE_1 = "CgkIkLSVpOIeEAIQAw";
    private readonly string GPGS_ACHIEVE_2 = "CgkIkLSVpOIeEAIQBw";
    private readonly string GPGS_ACHIEVE_3 = "CgkIkLSVpOIeEAIQCA";
    private readonly string GPGS_ACHIEVE_4 = "CgkIkLSVpOIeEAIQBA";
    private readonly string GPGS_ACHIEVE_5 = "CgkIkLSVpOIeEAIQBQ";
    private readonly string GPGS_ACHIEVE_6 = "CgkIkLSVpOIeEAIQBg";

    private readonly string IOS_ACHIEVE_1 = "70548003";
    private readonly string IOS_ACHIEVE_2 = "70548001";
    private readonly string IOS_ACHIEVE_3 = "70548000";
    private readonly string IOS_ACHIEVE_4 = "70547999";
    private readonly string IOS_ACHIEVE_5 = "70548002";
    private readonly string IOS_ACHIEVE_6 = "70548065";

    private void Awake()
    {
        if (instance == null) instance = this;

#if UNITY_ANDROID
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
#endif
    }

    private void Start()
    {
        TrySignIn();
    }

    public void TrySignIn()
    {
        if (!Social.localUser.authenticated)
        {
            SignIn();
        }
    }

    public void SignIn()
    {
#if UNITY_ANDROID
        PlayGamesPlatform.Instance.Authenticate((bool success) =>
        {
            if (success)
            {
                // to do ...
                // 구글 플레이 게임 서비스 로그인 성공 처리
            }
            else
            {
                return;
                // to do ...
                // 구글 플레이 게임 서비스 로그인 실패 처리
            }
        });

#elif UNITY_IOS

        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log(success);
                // to do ...
                // 애플 게임 센터 로그인 성공 처리
            }
            else
            {
        return;
                // to do ...
                // 애플 게임 센터 로그인 실패 처리
            }
        });

#endif
    }

    public void SignOut()
    {
        if (Social.localUser.authenticated)
        {
#if UNITY_ANDROID
            PlayGamesPlatform.Instance.SignOut();
#endif
        }
    }

    public void OnShowLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
#if UNITY_ANDROID
            string id = GPGS_LEADERBOARD_ID;
            ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(id); // Show current (Active) leaderboard
#elif UNITY_IOS
            string id = IOS_LEADERBOARD_ID;
            GameCenterPlatform.ShowLeaderboardUI(id, TimeScope.AllTime);
#endif
        }
    }

    public void OnRecordLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
#if UNITY_ANDROID
            string id = GPGS_LEADERBOARD_ID;
            Social.ReportScore(PrefManager.instance.GetTopScore(), id, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("record done ##");
                }
                else
                {
                    Debug.Log("unable to record ##");
                }
            });
#elif UNITY_IOS
            string id = IOS_LEADERBOARD_ID;
            Social.ReportScore(PrefManager.instance.GetTopScore(), id, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("record done ##");
                }
                else
                {
                    Debug.Log("unable to record ##");
                }
            });
#endif
        }
    }

    public void OnShowAchievementUI()
    {
        if (Social.localUser.authenticated == false)
        {
            SignIn();
        }
        Social.ShowAchievementsUI();
    }

    public void UnlockAchievement(ACHIEVE _type)
    {
        
        if(_type == ACHIEVE.ACHIEVE_1){
#if UNITY_ANDROID
            PlayGamesPlatform.Instance.ReportProgress(GPGS_ACHIEVE_1, 100f, (bool success) =>
            {
                PrefManager.instance.SetAchieve1();
            });
#elif UNITY_IOS
            Social.ReportProgress(IOS_ACHIEVE_1, 100f, (bool success) =>
            {
                PrefManager.instance.SetAchieve1();
            });
#endif
        }
        else if(_type == ACHIEVE.ACHIEVE_2){
            #if UNITY_ANDROID
            PlayGamesPlatform.Instance.ReportProgress(GPGS_ACHIEVE_2, 100f, (bool success) =>
            {
                PrefManager.instance.SetAchieve2();
            });
#elif UNITY_IOS
            Social.ReportProgress(IOS_ACHIEVE_2, 100f, (bool success) =>
            {
                PrefManager.instance.SetAchieve2();
            });
#endif
        }
        else if (_type == ACHIEVE.ACHIEVE_3)
        {
            #if UNITY_ANDROID
            PlayGamesPlatform.Instance.ReportProgress(GPGS_ACHIEVE_3, 100f, (bool success) =>
            {
                PrefManager.instance.SetAchieve3();
            });
#elif UNITY_IOS
            Social.ReportProgress(IOS_ACHIEVE_3, 100f, (bool success) =>
            {
                PrefManager.instance.SetAchieve3();
            });
#endif
        }
        else if (_type == ACHIEVE.ACHIEVE_4)
        {
            #if UNITY_ANDROID
            PlayGamesPlatform.Instance.ReportProgress(GPGS_ACHIEVE_4, 100f, (bool success) =>
            {
                PrefManager.instance.SetAchieve4();
            });
#elif UNITY_IOS
            Social.ReportProgress(IOS_ACHIEVE_4, 100f, (bool success) =>
            {
                PrefManager.instance.SetAchieve4();
            });
#endif
        }
        else if (_type == ACHIEVE.ACHIEVE_5)
        {
            #if UNITY_ANDROID
            PlayGamesPlatform.Instance.ReportProgress(GPGS_ACHIEVE_5, 100f, (bool success) =>
            {
                PrefManager.instance.SetAchieve5();
            });
#elif UNITY_IOS
            Social.ReportProgress(IOS_ACHIEVE_5, 100f, (bool success) =>
            {
                PrefManager.instance.SetAchieve5();
            });
#endif
        }
        else if (_type == ACHIEVE.ACHIEVE_6)
        {
            #if UNITY_ANDROID
            PlayGamesPlatform.Instance.ReportProgress(GPGS_ACHIEVE_6, 100f, (bool success) =>
            {
                PrefManager.instance.SetAchieve6();
            });
#elif UNITY_IOS
            Social.ReportProgress(IOS_ACHIEVE_6, 100f, (bool success) =>
            {
                PrefManager.instance.SetAchieve6();
            });
#endif
        }
        else {
            return;
        }
    }
}
