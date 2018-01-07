using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableAfterAnimate : MonoBehaviour {
    private Text t_Score;
    private Animation anim;
    public AnimationClip[] clips;


    private void Awake()
    {
        t_Score = GetComponent<Text>();
        anim = GetComponent<Animation>();
        
    }


    private void OnEnable()
    {
        var r = Random.Range(0, clips.Length);
        anim.clip = clips[r];
        anim.Play();

        StringBuilder stb = new StringBuilder("+");
        stb.Append(UIManager.instance.scoreFloatValue);
        t_Score.text = stb.ToString();
    }

    public void Disable(){
        gameObject.SetActive(false);
    }
}
