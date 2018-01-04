using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager instance;

    private readonly int ENEMY_LENGTH = 15;
    [SerializeField]
    private int enemyIndex;
    public GameObject enemyObject;
    public List<GameObject> poolEnemy;

    private void Awake()
    {
        if (instance == null) instance = this;
        enemyIndex = 0;
        MakePool();
    }

    private void MakePool(){
        for (int i = 0; i < ENEMY_LENGTH; i++){
            poolEnemy.Add(Instantiate(enemyObject));
        }
        MoveToVoid();
    }

    private void MoveToVoid(){
        for (int i = 0; i < ENEMY_LENGTH; i++){
            poolEnemy[i].SetActive(false);
            poolEnemy[i].transform.position = Vector3.zero; 
        }
    }

    public GameObject PopEnemyFromPool(){
        var i = enemyIndex % ENEMY_LENGTH;
        if(poolEnemy[i].activeInHierarchy){
            enemyIndex++;
            PopEnemyFromPool();
        }
        return poolEnemy[enemyIndex % ENEMY_LENGTH];
    }
}
