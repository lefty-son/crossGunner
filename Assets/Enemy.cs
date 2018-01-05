using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private SpriteRenderer sprr;

    private void Awake()
    {
        sprr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        var r = Random.Range(0, 100);
        if (r % 2 == 0)
        {
            sprr.color = ObjectHelper.instance._left.color;
            gameObject.tag = ObjectHelper.instance._left.tag;
        }
        else
        {
            sprr.color = ObjectHelper.instance._right.color;
            gameObject.tag = ObjectHelper.instance._right.tag;
        }
    }
}
