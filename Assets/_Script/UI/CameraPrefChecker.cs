using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPrefChecker : MonoBehaviour {
    //28 25 25

    private void OnEnable()
    {
        CheckPrefs();   
    }

    public void CheckPrefs(){
        if(PrefManager.instance.GetIsNight() == 1){
            Camera.main.backgroundColor = new Color32(28, 25, 25, 255);
        }
        else {
            Camera.main.backgroundColor = Color.white;
        }
    }
}
