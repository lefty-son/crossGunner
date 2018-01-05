using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Left
        if(CompareTag("Left")){
            ParticleManager.instance.PutParticleOnEnemy(transform);
            if (collision.CompareTag("LeftBullet"))
            {
                GameManger.instance.GetScoreByEnemy();
                GameManger.instance.ShakeOnKillEnemy();

                gameObject.SetActive(false);
            }
            else {
                GameManger.instance.GameOver();
            }
        }

        // Right
        else {
            ParticleManager.instance.PutParticleOnEnemy(transform);
            if (collision.CompareTag("RightBullet"))
            {
                GameManger.instance.GetScoreByEnemy();
                GameManger.instance.ShakeOnKillEnemy();

                gameObject.SetActive(false);
            }
            else
            {
                GameManger.instance.GameOver();
            }
        }

    }

}
