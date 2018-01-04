using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn()
    {
        var enemy = SpawnManager.instance.PopEnemyFromPool();
        enemy.transform.position = transform.position;
        enemy.transform.rotation = Quaternion.identity;
        enemy.SetActive(true);
        //Instantiate(SpawnManager.instance.PopEnemyFromPool(), transform.position, Quaternion.identity);
    }

}
