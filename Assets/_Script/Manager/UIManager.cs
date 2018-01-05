using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance;
    public GameObject p_Home, p_Control, p_Top, p_Credit;
    public Animation a_Score;
    public Animation[] a_HomeAnimations;
    public Text t_Score;

    public Image[] i_Left, i_Right;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void SetScore(){
        t_Score.text = GameManger.instance.Score.ToString();
        a_Score.Play();
    }

    public void OnStart(){
        if(!GameManger.instance.IsStart){
            foreach(Animation anim in a_HomeAnimations){
                var anim_FaintOut = anim.GetClip("UI_FaintOut");
                anim.clip = anim_FaintOut;
                anim.Play();
            }
            SetArrowColor();
            GameManger.instance.StartGame();
        }
    }

    public void OnGamePanel(){
        p_Control.SetActive(true);
        p_Top.SetActive(true);
    }

    public void OffHomePanel(){
        p_Home.SetActive(false);
    }

    public void OnCreditPanel(){
        p_Credit.SetActive(true);
    }

    public void OffCreditPanel(){
        p_Credit.SetActive(false);
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
}
