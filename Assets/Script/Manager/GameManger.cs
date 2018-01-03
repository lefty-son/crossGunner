using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour {

    public static GameManger instance;

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

    public Spanwer[] spawner;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        StartGame();
        PlayerController.instance.StartGame();
    }

    public void StartGame(){
        IsStart = true;
        IsPlaying = true;

        foreach(Spanwer _sp in spawner){
            _sp.Spawn();
        }
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




}
