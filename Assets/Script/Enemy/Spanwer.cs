using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanwer : MonoBehaviour {
    public GameObject enemyObject;

    public void Spawn(){
        Instantiate(enemyObject, transform.position, Quaternion.identity);
    }

}
