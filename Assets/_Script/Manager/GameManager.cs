using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private int adsMeter;
    private readonly int adsLimit = 5;

    public static GameManager instance;

    private readonly int SPAWNER_LENGTH = 4;

    public Spawner[] spawner;

    #region CONFIG

    public float[] spawnTimes;
    public float[] enemySpeeds;
    public float[] bulletSpeeds;    // [1..2]

    #endregion

    #region PROPERTY

    [SerializeField]
    private float bulletSpeed;
    public float BulletSpeed
    {
        get
        {
            return bulletSpeed;
        }
        set {
            bulletSpeed = value;
        }
    }

    [SerializeField]
    private float enemySpeed;
    public float EnemySpeed
    {
        get
        {
            return enemySpeed;
        }
        set 
        {
            enemySpeed = value;
        }
    }

    [SerializeField]
    private float spawnTime;
    public float SpawnTime
    {
        get
        {
            return spawnTime;
        }
        set {
            spawnTime = value;
        }
    }

    [SerializeField]
    private float fireRate;
    public float FireRate {
        get {
            return fireRate;
        }
        set {
            fireRate = value;
        }
    }

    [SerializeField]
    private int score;
    public int Score {
        get {
            return score;
        }
        set {
            score = value;
            if(IsStart && IsPlaying){
                UIManager.instance.SetScore();

            }
            if(score >= 30)
            {
                Level = 5;
            }
            else if(score >= 20)
            {
                Level = 4;
            }
            else if(score >= 15)
            {
                Level = 3;
            }
            else if (score >= 10)
            {
                Level = 2;
            }
            else if(score >= 5)
            {
                Level = 1;
            }
            else {
                Level = 0;
            }
        }
    }

    [SerializeField]
    private int level;
    public int Level {
        get {
            return level;
        }
        set {
            level = value;
            SetConfig();
        }
    }

    [SerializeField]
    private bool isStart;
    public bool IsStart {
        get {
            return isStart;
        }
        set {
            isStart = value;
        }
    }

    [SerializeField]
    private bool isPlaying;
    public bool IsPlaying {
        get {
            return isPlaying;
        }
        set {
            isPlaying = value;

            if(!IsPlaying && IsStart){
                // TODO: Pause game;
            }
        }
    }

#endregion

    private void Awake()
    {
        if (instance == null) instance = this;
        IsStart = false;
        IsPlaying = false;
        adsMeter = 0;
    }

    private void CleanUp(){
        Score = 0;
        Level = 0;
        ObjectHelper.instance.StartGame();
        SpawnManager.instance.CleanUp();
    }

    public void StartGame()
    {
        IsStart = true;
        IsPlaying = true;

        // Set Config
        CleanUp();

        UIManager.instance.OnGamePanel();
        PlayerController.instance.StartGame();
        StartCoroutine(SpawnInterval());
    }

    private void SetConfig()
    {
        SpawnTime = spawnTimes[Level];
        EnemySpeed = enemySpeeds[Level];
        BulletSpeed = bulletSpeeds[Level];
    }

    public void GameOver()
    {
        IsStart = false;
        IsPlaying = false;
        ShakeOnGameOver();
        CheckTopScore(Score);
        UIManager.instance.OnHomePanel();
        SoundManager.instance.PlayDeath();
        adsMeter += Score;
        if(adsMeter >= adsLimit){
            AdsManager.instance.ShowResi();
        }
    }

    public void InitAdsMeter(){
        adsMeter = 0;
    }

    public void ResumeGame(){
        IsPlaying = true;
    }

    public void PauseGame(){
        IsPlaying = false;
    }

    IEnumerator SpawnInterval(){
        while(IsStart && IsPlaying){
            yield return new WaitForSeconds(spawnTime);
            var r = Random.Range(0, SPAWNER_LENGTH);
            spawner[r].Spawn();
        }
    }

    public void GetScoreByEnemy(){
        if(IsStart && IsPlaying){
            Score++;
        }
    }

    public void ShakeOnGameOver(){
        EZCameraShake.CameraShaker.Instance.ShakeOnce(1, 10, 0f, 4f);
    }

    public void ShakeOnKillBoss()
    {
        EZCameraShake.CameraShaker.Instance.ShakeOnce(3f, 20, 0f, 2f);
    }

    public void ShakeOnKillEnemy(){
        EZCameraShake.CameraShaker.Instance.ShakeOnce(0.75f, 20, 0f, .35f);
    }

    private void CheckTopScore(int _value){
        if(_value > PrefManager.instance.GetTopScore()){
            PrefManager.instance.SetTopScore(_value);
        }
        if (_value >= 100 && PrefManager.instance.GetAchieve1() == 0)
        {
            SocialManager.instance.UnlockAchievement(SocialManager.ACHIEVE.ACHIEVE_3);
            return;
        }
        else if (_value >= 50 && PrefManager.instance.GetAchieve2() == 0)
        {
            SocialManager.instance.UnlockAchievement(SocialManager.ACHIEVE.ACHIEVE_2);
            return;
        }
        else if (_value >= 10 && PrefManager.instance.GetAchieve3() == 0)
        {
            SocialManager.instance.UnlockAchievement(SocialManager.ACHIEVE.ACHIEVE_1);
            return;
        }
    }
}
