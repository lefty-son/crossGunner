using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPrefChecker : MonoBehaviour {

    public Button b_Muted, b_NightMode;

    void OnEnable()
    {
        CheckPrefs();
    }

    private void CheckPrefs()
    {
        if (PrefManager.instance.GetIsMuted() == 0)
        {
            // 58 53 53
            b_Muted.image.color = Color.white;
        }
        else
        {
            b_Muted.image.color = new Color32(58, 53, 53, 255);
        }

        if (PrefManager.instance.GetIsNight() == 0)
        {
            b_NightMode.image.color = Color.white;
        }
        else
        {
            b_NightMode.image.color = new Color32(58, 53, 53, 255);
        }
        FindObjectOfType<CameraPrefChecker>().CheckPrefs();
    }

    public void OnMuted(){
        if(PrefManager.instance.GetIsMuted() == 0){
            PrefManager.instance.SetIsMuted(1);
        }
        else {
            PrefManager.instance.SetIsMuted(0);
        }
        CheckPrefs();
    }

    public void OnNightMode(){
        if (PrefManager.instance.GetIsNight() == 0)
        {
            PrefManager.instance.SetIsNight(1);
        }
        else
        {
            PrefManager.instance.SetIsNight(0);
        }
        CheckPrefs();
    }
}
