using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform target;
    public float speed;

    private void Awake()
    {
        target = GameObject.FindWithTag("Target").transform;
    }

    // Update is called once per frame
    void Update () {
        if(GameManger.instance.IsStart && GameManger.instance.IsPlaying){
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
	}
}
