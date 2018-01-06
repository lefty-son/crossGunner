using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance;
    private static bool isFirst;
    public GameObject p_Home, p_Control, p_Top, p_Credit, p_Settings;
    public Animation a_Score, a_Background, a_Title;
    public Animation[] a_HomeAnimations, a_HomeScoreAnimations;
    public Text t_CurrentScore, t_LastScore, t_TopScore;

    public Image[] i_Left, i_Right;

    private void Awake()
    {
        if (instance == null) instance = this;
        isFirst = true;
    }

    public void Rate()
    {
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=com.atone.crossgunner");
#elif UNITY__IOS
        Application.OpenURL("itms-apps://itunes.apple.com/app/id1330908883");
#endif
    }

    public void SetScore(){
        t_CurrentScore.text = GameManager.instance.Score.ToString();
        a_Score.Play();
    }

    public void SetHomeScore(){
        t_LastScore.text = GameManager.instance.Score.ToString();
        StringBuilder stb = new StringBuilder("best: ");
        stb.Append(PrefManager.instance.GetTopScore());
        t_TopScore.text = stb.ToString();
    }

    public void OnStart(){
        if(!GameManager.instance.IsStart && !GameManager.instance.IsPlaying){
            FindObjectOfType<Blur>().StartCoroutine("BlurOut");

            if(isFirst){
                var clipTitle = a_Title.GetClip("Title_Out");
                a_Title.clip = clipTitle;
                a_Title.Play();
                a_Title.playAutomatically = false;
            }

            var clipBackground = a_Background.GetClip("Background_Out");
            a_Background.clip = clipBackground;
            a_Background.Play();

          
            foreach(Animation anim in a_HomeAnimations){
                var anim_FaintOut = anim.GetClip("UI_FaintOut");
                anim.clip = anim_FaintOut;
                anim.Play();
            }

            foreach (Animation anim in a_HomeScoreAnimations)
            {
                var anim_FaintOut = anim.GetClip("UI_ScoreScaleDown");
                anim.clip = anim_FaintOut;
                anim.Play();
            }

            GameManager.instance.StartGame();
            SetArrowColor();
            isFirst = false;
        }
    }

    public void OnGamePanel(){
        p_Control.SetActive(true);
        p_Top.SetActive(true);
    }

    public void OffGamePanel(){
        p_Control.SetActive(false);
        p_Top.SetActive(false);
    }

    public void OnHomePanel(){
        var clipBackground = a_Background.GetClip("Background_In");
        a_Background.clip = clipBackground;
        a_Background.Play();

        if(isFirst){
            var clipTitle = a_Title.GetClip("Title_In");
            a_Title.clip = clipTitle;
            a_Title.Play();
            isFirst = false;
        }

        foreach (Animation anim in a_HomeAnimations)
        {
            var anim_FaintOut = anim.GetClip("UI_ScaleUpForBlack");
            anim.clip = anim_FaintOut;
            anim.Play();
        }

        foreach (Animation anim in a_HomeScoreAnimations)
        {
            var anim_FaintOut = anim.GetClip("UI_ScoreScaleUp");
            anim.clip = anim_FaintOut;
            anim.Play();
        }

        SetHomeScore();
        p_Home.SetActive(true);
        OffGamePanel();
    }

    public void OffControlPanel(){
        p_Control.SetActive(false);
    }

    public void OffHomePanel(){
        p_Home.SetActive(false);
    }

    public void OnCreditPanel(){
        p_Home.SetActive(false);
        p_Credit.SetActive(true);
    }

    public void OffCreditPanel(){
        p_Credit.SetActive(false);
        p_Home.SetActive(true);
    }

    public void Shake(){
        EZCameraShake.CameraShaker.Instance.ShakeOnce(0.75f,20,0f,.35f);
    }

    private void SetArrowColor(){
        foreach(Image _img in i_Left){
            _img.color  = ObjectHelper.instance._left.color;
        }
        foreach (Image _img in i_Right)
        {
            _img.color = ObjectHelper.instance._right.color;
        }
    }

    public void OnSettingsPanel(){
        p_Home.SetActive(false);
        p_Settings.SetActive(true);
    }

    public void OffSettingsPanel()
    {
        p_Settings.SetActive(false);
        p_Home.SetActive(true);
    }

    public void OnQuit(){
        Application.Quit();
    }

}
