using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private SpriteRenderer sprr;

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

    private void Awake()
    {
        sprr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(GameManager.instance.IsStart && GameManager.instance.IsPlaying){
            float step = GameManager.instance.BulletSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, enemy[myDirection].position, step);
        }
    }

    public void Shoot(DIRECTION _direction, bool _isLeft)
    {
        // Set Object
        if (_isLeft)
        {
            sprr.color = ObjectHelper.instance._left.color;
            gameObject.tag = "LeftBullet";
        }
        else
        {
            sprr.color = ObjectHelper.instance._right.color;
            gameObject.tag = "RightBullet";
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
