using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    private readonly int SPAWNER_LENGTH = 4;

    public Spawner[] spawner;

    #region CONFIG

    public float[] spawnTimes;
    public float[] fireRates;
    public float[] enemySpeeds;

    #endregion

    #region PROPERTY

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
            if(score == 5){
                Level++;
            }
            else if(score == 10){
                Level++;
            }
            else if (score == 15)
            {
                Level++;
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
        FireRate = fireRates[Level];
        SpawnTime = spawnTimes[Level];
        EnemySpeed = enemySpeeds[Level];
    }

    public void GameOver()
    {
        IsStart = false;
        IsPlaying = false;
        ShakeOnGameOver();
        UIManager.instance.OnHomePanel();
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
        EZCameraShake.CameraShaker.Instance.ShakeOnce(1.5f, 20, 0f, .5f);
    }

    public void ShakeOnKillEnemy(){
        EZCameraShake.CameraShaker.Instance.ShakeOnce(0.75f, 20, 0f, .35f);
    }
}
