using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private readonly int DECK_SIZE = 12;
    private readonly int ENEMY = 0;
    private readonly int ITEM = 1;

    private int[] deck;

    private void Awake()
    {
        deck = new int[] 
        {
			0,0,0,0,0,
			0,0,0,0,0,0,1
        };
    }

    public void Spawn()
    {
        if(GameManager.instance.IsStart && GameManager.instance.IsPlaying){
            var r = deck[Random.Range(0, DECK_SIZE)];
            GameObject enemy;
            if (r == ENEMY)
            {
                enemy = SpawnManager.instance.PopEnemyFromPool();
            }
            else if (r == ITEM)
            {
                enemy = SpawnManager.instance.PopItemFromPool();
            }
            else
            {
                enemy = SpawnManager.instance.PopEnemyFromPool();
            }
            enemy.transform.position = transform.position;
            enemy.transform.rotation = Quaternion.identity;
            enemy.SetActive(true);
        }
    }
}
