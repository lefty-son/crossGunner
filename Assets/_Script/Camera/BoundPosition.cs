using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundPosition : MonoBehaviour {

    public enum DIRECTION
    {
        TOP,
        LEFT,
        RIGHT,
        BOTTOM
    }   
    public DIRECTION direction;

    public void Awake()
    {
        if (direction == DIRECTION.TOP)
        {
            Vector3 top = Camera2D.ScreenTo2D(Camera.main.pixelWidth / 2, Camera.main.pixelHeight * 1.1f);
            transform.localScale = new Vector2(Camera.main.orthographicSize, 1);
            transform.position = top;
        }
        else if (direction == DIRECTION.LEFT)
        {
            Vector3 left = Camera2D.ScreenTo2D(- 0.2f * Camera.main.pixelWidth , Camera.main.pixelHeight / 2);
            transform.localScale = new Vector2(1, Camera.main.orthographicSize * 2);
            transform.position = left;
        }
        else if (direction == DIRECTION.RIGHT)
        {
            Vector3 right = Camera2D.ScreenTo2D(Camera.main.pixelWidth * 1.2f, Camera.main.pixelHeight / 2);
            transform.localScale = new Vector2(1, Camera.main.orthographicSize * 2);
            transform.position = right;
        }
        else if (direction == DIRECTION.BOTTOM)
        {
            Vector3 bottom = Camera2D.ScreenTo2D(Camera.main.pixelWidth / 2, Camera.main.pixelHeight * -0.1f);
            transform.localScale = new Vector2(Camera.main.orthographicSize, 1);
            transform.position = bottom;
        }

    }
}
