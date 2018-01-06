using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("LeftBullet") || collision.CompareTag("RightBullet")){
            var count = 0;

            if(PrefManager.instance.GetAchieve4() == 0){
                SocialManager.instance.UnlockAchievement(SocialManager.ACHIEVE.ACHIEVE_4);
            }

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
                count++;
                ParticleManager.instance.PutParticleOnEnemy(item.transform);
                GameManager.instance.GetScoreByEnemy();
                item.SetActive(false);
            }

            foreach (var item in GameObject.FindGameObjectsWithTag("Right"))
            {
                count++;
                ParticleManager.instance.PutParticleOnEnemy(item.transform);
                GameManager.instance.GetScoreByEnemy();
                item.SetActive(false);
            }

            foreach(var item in GameObject.FindGameObjectsWithTag("Item")){
                ParticleManager.instance.PutParticleOnEnemy(item.transform);
                item.SetActive(false);
            }

            if(count >= 10 && PrefManager.instance.GetAchieve6() == 0){
                SocialManager.instance.UnlockAchievement(SocialManager.ACHIEVE.ACHIEVE_6);
            }
            else if(count >= 5 && PrefManager.instance.GetAchieve5() == 0)
            {
                SocialManager.instance.UnlockAchievement(SocialManager.ACHIEVE.ACHIEVE_5);
            }


            GameManager.instance.ShakeOnKillBoss();

            // Destroy item;
            gameObject.SetActive(false);
        }
        else if(collision.CompareTag("Player")){
            GameManager.instance.GameOver();
        }
    }
}
