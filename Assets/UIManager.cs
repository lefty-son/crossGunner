using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance;
    public GameObject p_Home, p_Control, p_Top;
    public Animation[] a_HomeAnimations;
    public Text t_Score;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void SetScore(){
        t_Score.text = GameManger.instance.Score.ToString();
    }

    public void OnStart(){
        if(!GameManger.instance.IsStart){
            foreach(Animation anim in a_HomeAnimations){
                var anim_FaintOut = anim.GetClip("UI_FaintOut");
                anim.clip = anim_FaintOut;
                anim.Play();
            }
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
}
