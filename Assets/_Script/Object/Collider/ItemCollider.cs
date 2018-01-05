using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("LeftBullet") || collision.CompareTag("RightBullet")){
            // Particle item;
            ParticleManager.instance.PutParticleOnEnemy(transform);

            foreach (var item in GameObject.FindGameObjectsWithTag("LeftBullet"))
            {
                item.SetActive(false);
            }

            foreach (var item in GameObject.FindGameObjectsWithTag("RightBullet"))
            {
                item.SetActive(false);
            }

            foreach (var item in GameObject.FindGameObjectsWithTag("Left"))
            {
                ParticleManager.instance.PutParticleOnEnemy(item.transform);
                GameManager.instance.GetScoreByEnemy();
                item.SetActive(false);
            }

            foreach (var item in GameObject.FindGameObjectsWithTag("Right"))
            {
                ParticleManager.instance.PutParticleOnEnemy(item.transform);
                GameManager.instance.GetScoreByEnemy();
                item.SetActive(false);
            }



            GameManager.instance.ShakeOnKillBoss();

            // Destroy item;
            gameObject.SetActive(false);
        }
    }
}
