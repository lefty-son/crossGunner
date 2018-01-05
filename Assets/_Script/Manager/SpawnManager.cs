using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public static SpawnManager instance;

    private readonly int ENEMY_LENGTH = 15;
    private readonly int HOSTAGE_LENGTH = 5;

    [SerializeField]
    private int enemyIndex, hostageIndex;
    public GameObject enemyObject, hostageObject;
    public List<GameObject> poolEnemy, poolHostage;

    private void Awake()
    {
        if (instance == null) instance = this;

        enemyIndex = 0;
        hostageIndex = 0;
        poolEnemy = new List<GameObject>();
        poolHostage = new List<GameObject>();

        MakePool();
    }

    public void CleanUp(){
        MoveToVoid();
    }

    private void MakePool(){
        for (int i = 0; i < ENEMY_LENGTH; i++){
            poolEnemy.Add(Instantiate(enemyObject));
        }
        //for (int i = 0; i < HOSTAGE_LENGTH; i++){
        //    poolHostage.Add(Instantiate(hostageObject));
        //}
        MoveToVoid();
    }

    private void MoveToVoid(){
        for (int i = 0; i < ENEMY_LENGTH; i++){
            poolEnemy[i].SetActive(false);
            poolEnemy[i].transform.position = Vector3.zero; 
        }
        //for (int i = 0; i < HOSTAGE_LENGTH; i++){
        //    poolHostage[i].SetActive(false);
        //    poolHostage[i].transform.position = Vector3.zero; 
        //}
    }

    public GameObject PopEnemyFromPool(){
        var i = enemyIndex % ENEMY_LENGTH;
        if(poolEnemy[i].activeInHierarchy){
            enemyIndex++;
            PopEnemyFromPool();
        }
        return poolEnemy[enemyIndex % ENEMY_LENGTH];
    }

    //public GameObject PopHostageFromPool(){
    //    var i = hostageIndex % HOSTAGE_LENGTH;
    //    if (poolHostage[i].activeInHierarchy)
    //    {
    //        hostageIndex++;
    //        PopHostageFromPool();
    //    }
    //    return poolHostage[hostageIndex % HOSTAGE_LENGTH];
    //}
}
