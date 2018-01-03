using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    private readonly int TOP         = 0;
    private readonly int LEFT        = 1;
    private readonly int RIGHT       = 2;
    private readonly int BOTTOM      = 3;

    public enum DIRECTION {
        TOP,
        LEFT,
        RIGHT,
        BOTTOM
    }
    public Transform[] enemy; //0: TOP, 1: LEFT, 2: RIGHT, 3: BOTTOM;
    public DIRECTION direction;
    [SerializeField]
    private int myDirection;

    public void Shoot(DIRECTION _direction){
        transform.position = Vector3.zero;
        gameObject.SetActive(true);
        if (_direction == DIRECTION.TOP)
        {
            myDirection = TOP;
        }
        else if (_direction == DIRECTION.LEFT)
        {
            myDirection = LEFT;
        }
        else if (_direction == DIRECTION.RIGHT)
        {
            myDirection = RIGHT;
        }
        else if (_direction == DIRECTION.BOTTOM)
        {
            myDirection = BOTTOM;
        }
    }
    private void Update()
    {
        if(GameManger.instance.IsStart && GameManger.instance.IsPlaying){
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, enemy[myDirection].position, step);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
