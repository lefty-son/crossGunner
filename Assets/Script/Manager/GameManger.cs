using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour {

    public static GameManger instance;
    private readonly int SPAWNER_LENGTH = 4;

    public float[] fireRates;

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
            if(score == 3){
                Level++;
            }
            else if(score == 6){
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

    public Spawner[] spawner;

    private void Awake()
    {
        if (instance == null) instance = this;
        IsStart = false;
        IsPlaying = false;
    }

    //private void Start()
    //{
    //    StartGame();
    //}

    private void SetConfig(){
        FireRate = fireRates[Level];
    }

    public void StartGame()
    {
        Debug.Log("Start");
        IsStart = true;
        IsPlaying = true;
        Level = 0;

        UIManager.instance.OnGamePanel();
        PlayerController.instance.StartGame();
        StartCoroutine(SpawnInterval());
    }

    public void GameOver()
    {
        IsStart = false;
        IsPlaying = false;
    }

    public void ResumeGame(){
        IsPlaying = true;
    }

    public void PauseGame(){
        IsPlaying = false;
    }

    IEnumerator SpawnInterval(){
        while(IsStart && IsPlaying){
            yield return new WaitForSeconds(1.5f);
            var r = Random.Range(0, SPAWNER_LENGTH);
            spawner[r].Spawn();
        }
    }

    public void GetScoreByEnemy(){
        if(IsStart && IsPlaying){
            Score++;
        }
    }


}
