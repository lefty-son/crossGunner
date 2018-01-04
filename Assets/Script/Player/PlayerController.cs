using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public enum DIRECTION {
        TOP,
        LEFT,
        RIGHT,
        BOTTOM
    }

    public DIRECTION direction;

    private readonly int BULLET_COUNT = 20;
    public float fireRate;
    private bool isReadyToFire;

    private int bulletIndex;
    public GameObject bulletObject;
    private List<Bullet> bulletPool;

    private void Awake()
    {
        if (instance == null) instance = this;
        Init();
    }

    private void FixedUpdate()
    {
        fireRate -= Time.deltaTime;
        if(fireRate <= 0f){
            isReadyToFire = true;
        }
    }

    private void Init(){
        isReadyToFire = true;
        direction = DIRECTION.TOP;
        bulletPool = new List<Bullet>();
        MakePool();
    }

    // Call this from GameManger ONLY!
    public void StartGame(){
        bulletIndex = 0;
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
        if(isReadyToFire){
            Shoot(direction);
            fireRate = GameManger.instance.FireRate;
            isReadyToFire = false;
        }
        else {
            Debug.Log("NOT READY TO SHOOT");
            return;
        }

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
            bulletPool[index].Shoot(Bullet.DIRECTION.TOP);
        }
        else if(_direction == DIRECTION.LEFT){
            bulletPool[index].Shoot(Bullet.DIRECTION.LEFT);
        }
        else if (_direction == DIRECTION.RIGHT)
        {
            bulletPool[index].Shoot(Bullet.DIRECTION.RIGHT);
        }
        else if (_direction == DIRECTION.BOTTOM)
        {
            bulletPool[index].Shoot(Bullet.DIRECTION.BOTTOM);
        }
        bulletIndex++;
    }
}
