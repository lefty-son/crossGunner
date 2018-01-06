using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefManager : MonoBehaviour {
    public static PrefManager instance;

    private readonly string IS_FIRST = "IS_FIRST";
    private readonly string TOP_SCORE = "TOP_SCORE";
    private readonly string ADS_REMOVED = "ADS_REMOVED";
    private readonly string IS_MUTED = "IS_MUTED";
    private readonly string IS_NIGHT = "IS_NITGHT";
    private readonly string ACHIEVE_1 = "ACHIEVE_1";
    private readonly string ACHIEVE_2 = "ACHIEVE_2";
    private readonly string ACHIEVE_3 = "ACHIEVE_3";
    private readonly string ACHIEVE_4 = "ACHIEVE_4";
    private readonly string ACHIEVE_5 = "ACHIEVE_5";
    private readonly string ACHIEVE_6 = "ACHIEVE_6";

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

            PlayerPrefs.SetInt(ACHIEVE_1, 0);
            PlayerPrefs.SetInt(ACHIEVE_2, 0);
            PlayerPrefs.SetInt(ACHIEVE_3, 0);
            PlayerPrefs.SetInt(ACHIEVE_4, 0);
            PlayerPrefs.SetInt(ACHIEVE_5, 0);
            PlayerPrefs.SetInt(ACHIEVE_6, 0);

            PlayerPrefs.SetInt(ADS_REMOVED, 0);

            PlayerPrefs.SetInt(IS_MUTED, 0);
            PlayerPrefs.SetInt(IS_NIGHT, 0);
        }
    }

    public int GetIsMuted(){
        return PlayerPrefs.GetInt(IS_MUTED);
    }

    public void SetIsMuted(int _value){
        PlayerPrefs.SetInt(IS_MUTED, _value);
    }

    public int GetIsNight(){
        return PlayerPrefs.GetInt(IS_NIGHT);
    }

    public void SetIsNight(int _value){
        PlayerPrefs.SetInt(IS_NIGHT, _value);
    }

    public int GetAdsRemoved(){
        return PlayerPrefs.GetInt(ADS_REMOVED);
    }

    public void SetAdsRemoved(){
        PlayerPrefs.SetInt(ADS_REMOVED, 1);
    }

    public int GetTopScore(){
        return PlayerPrefs.GetInt(TOP_SCORE);
    }

    public void SetTopScore(int _value){
        PlayerPrefs.SetInt(TOP_SCORE, _value);
        SocialManager.instance.OnRecordLeaderboard();
    }

    public int GetAchieve1(){
        return PlayerPrefs.GetInt(ACHIEVE_1);
    }
    public int GetAchieve2()
    {
        return PlayerPrefs.GetInt(ACHIEVE_2);
    }
    public int GetAchieve3()
    {
        return PlayerPrefs.GetInt(ACHIEVE_3);
    }
    public int GetAchieve4()
    {
        return PlayerPrefs.GetInt(ACHIEVE_4);
    }
    public int GetAchieve5()
    {
        return PlayerPrefs.GetInt(ACHIEVE_5);
    }
    public int GetAchieve6()
    {
        return PlayerPrefs.GetInt(ACHIEVE_6);
    }

    public void SetAchieve1(){
        PlayerPrefs.SetInt(ACHIEVE_1, 1);
    }
    public void SetAchieve2()
    {
        PlayerPrefs.SetInt(ACHIEVE_2, 1);
    }
    public void SetAchieve3()
    {
        PlayerPrefs.SetInt(ACHIEVE_3, 1);
    }
    public void SetAchieve4()
    {
        PlayerPrefs.SetInt(ACHIEVE_4, 1);
    }
    public void SetAchieve5()
    {
        PlayerPrefs.SetInt(ACHIEVE_5, 1);
    }
    public void SetAchieve6()
    {
        PlayerPrefs.SetInt(ACHIEVE_6, 1);
    }

    public void DBG_DeleteAll(){
        PlayerPrefs.DeleteAll();
    }

}
