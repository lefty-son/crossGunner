using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefManager : MonoBehaviour {
    public static PrefManager instance;

    private readonly string IS_FIRST = "IS_FIRST";
    private readonly string TOP_SCORE = "TOP_SCORE";

    private void Awake()
    {
        if (instance == null) instance = this;
        CheckPrefs();
    }

    private void CheckPrefs(){
        if(PlayerPrefs.HasKey(IS_FIRST)){
            
        }
        else {
            // Welcome!
            PlayerPrefs.SetInt(IS_FIRST, 0);
            PlayerPrefs.SetInt(TOP_SCORE, 0);
        }
    }

    public int GetTopScore(){
        return PlayerPrefs.GetInt(TOP_SCORE);
    }

    public void SetTopScore(int _value){
        Debug.Log("Setting new score");
        PlayerPrefs.SetInt(TOP_SCORE, _value);
    }

    public void DBG_DeleteAll(){
        PlayerPrefs.DeleteAll();
    }

}
