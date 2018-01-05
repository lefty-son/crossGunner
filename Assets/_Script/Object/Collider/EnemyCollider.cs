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
                GameManager.instance.GetScoreByEnemy();
                GameManager.instance.ShakeOnKillEnemy();

                gameObject.SetActive(false);
            }
            else {
                GameManager.instance.GameOver();
            }
        }

        // Right
        else {
            ParticleManager.instance.PutParticleOnEnemy(transform);
            if (collision.CompareTag("RightBullet"))
            {
                GameManager.instance.GetScoreByEnemy();
                GameManager.instance.ShakeOnKillEnemy();

                gameObject.SetActive(false);
            }
            else
            {
                GameManager.instance.GameOver();
            }
        }

    }

}
