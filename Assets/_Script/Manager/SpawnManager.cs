using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager instance;

    private readonly int ENEMY_LENGTH = 15;
    private readonly int ITEM_LENGTH = 5;

    [SerializeField]
    private int enemyIndex, hostageIndex;
    public GameObject enemyObject, hostageObject;
    public List<GameObject> poolEnemy, poolItem;

    private void Awake()
    {
        if (instance == null) instance = this;

        enemyIndex = 0;
        hostageIndex = 0;
        poolEnemy = new List<GameObject>();
        poolItem = new List<GameObject>();

        MakePool();
    }

    public void CleanUp(){
        MoveToVoid();
    }

    private void MakePool(){
        for (int i = 0; i < ENEMY_LENGTH; i++){
            poolEnemy.Add(Instantiate(enemyObject));
        }
        for (int i = 0; i < ITEM_LENGTH; i++){
            poolItem.Add(Instantiate(hostageObject));
        }
        MoveToVoid();
    }

    private void MoveToVoid(){
        for (int i = 0; i < ENEMY_LENGTH; i++){
            poolEnemy[i].SetActive(false);
            poolEnemy[i].transform.position = Vector3.zero; 
        }
        for (int i = 0; i < ITEM_LENGTH; i++){
            poolItem[i].SetActive(false);
            poolItem[i].transform.position = Vector3.zero; 
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

    public GameObject PopItemFromPool(){
        var i = hostageIndex % ITEM_LENGTH;
        if (poolItem[i].activeInHierarchy)
        {
            hostageIndex++;
            PopItemFromPool();
        }
        return poolItem[hostageIndex % ITEM_LENGTH];
    }
}
