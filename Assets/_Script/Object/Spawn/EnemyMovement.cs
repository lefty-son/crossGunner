using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform target;
    private float speed;

    private void Awake()
    {
        target = GameObject.FindWithTag("Target").transform;
    }

    private void OnEnable()
    {
        SetSpeedFromGameManager();
    }

    // Update is called once per frame
    void Update () {
        if(GameManager.instance.IsStart && GameManager.instance.IsPlaying){
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
	}

    private void SetSpeedFromGameManager(){
        if (GameManager.instance.IsStart && GameManager.instance.IsPlaying)
        {
            speed = GameManager.instance.EnemySpeed;
        }
    }


}
