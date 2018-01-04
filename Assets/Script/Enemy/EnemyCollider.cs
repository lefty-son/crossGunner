using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet")){
            GameManger.instance.GetScoreByEnemy();
            gameObject.SetActive(false);
        }
    }

}
