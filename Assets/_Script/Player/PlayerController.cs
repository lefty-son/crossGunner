using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;
    private SpriteRenderer sprr;
    public enum DIRECTION {
        TOP,
        LEFT,
        RIGHT,
        BOTTOM
    }

    private bool isLeft = false;

    public DIRECTION direction;

    private readonly int BULLET_COUNT = 20;

    private int bulletIndex;
    public GameObject bulletObject;
    private List<Bullet> bulletPool;

    private void Awake()
    {
        if (instance == null) instance = this;
        Init();
    }

    private void Init(){
        sprr = GetComponent<SpriteRenderer>();
        direction = DIRECTION.TOP;
        bulletPool = new List<Bullet>();
        MakePool();
    }

    // Call this from GameManger ONLY!
    public void StartGame(){
        bulletIndex = 0;
        sprr.color = ObjectHelper.instance.playerColor;
        MoveToVoid();
    }

    private void MakePool(){
        for (int i = 0; i < BULLET_COUNT; i++){
            bulletPool.Add(Instantiate(bulletObject, transform.position, Quaternion.identity).GetComponent<Bullet>());
        }
        MoveToVoid();
    }

    private void MoveToVoid(){
        for (int i = 0; i < BULLET_COUNT; i++){
            bulletPool[i].gameObject.SetActive(false);
            bulletPool[i].transform.position = Vector3.zero;
        }
    }

    public void ShootLeft(){
        isLeft = true;
    }

    public void ShootRight()
    {
        isLeft = false;
    }

    public void ChangeDirection(int _direction){
        if(_direction == 0){
            direction = DIRECTION.TOP;
        }
        else if(_direction == 1){
            direction = DIRECTION.LEFT;
        }
        else if (_direction == 2)
        {
            direction = DIRECTION.RIGHT;
        }
        else if (_direction == 3)
        {
            direction = DIRECTION.BOTTOM;
        }

        Rotate(direction);
        Shoot(direction);

    }

    private void Rotate(DIRECTION _direction){
        if (_direction == DIRECTION.TOP)
        {
            transform.eulerAngles = Vector3.forward * 0;
        }
        else if (_direction == DIRECTION.LEFT)
        {
            transform.eulerAngles = Vector3.forward * 90;
        }
        else if (_direction == DIRECTION.RIGHT)
        {
            transform.eulerAngles = Vector3.forward * -90;
        }
        else if (_direction == DIRECTION.BOTTOM)
        {
            transform.eulerAngles = Vector3.forward * 180;
        }
    }

    public void Shoot(DIRECTION _direction){
        var index = bulletIndex % BULLET_COUNT;
        if(_direction == DIRECTION.TOP){
            bulletPool[index].Shoot(Bullet.DIRECTION.TOP, isLeft);
        }
        else if(_direction == DIRECTION.LEFT){
            bulletPool[index].Shoot(Bullet.DIRECTION.LEFT, isLeft);
        }
        else if (_direction == DIRECTION.RIGHT)
        {
            bulletPool[index].Shoot(Bullet.DIRECTION.RIGHT, isLeft);
        }
        else if (_direction == DIRECTION.BOTTOM)
        {
            bulletPool[index].Shoot(Bullet.DIRECTION.BOTTOM, isLeft);
        }
        bulletIndex++;
    }
}
