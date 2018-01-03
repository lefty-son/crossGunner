using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    public enum DIRECTION
    {
        TOP,
        LEFT,
        RIGHT,
        BOTTOM,
        TARGET
    }

    public DIRECTION dir;

    void Awake()
    {
        if (dir == DIRECTION.TOP)
        {
            Vector3 top = Camera2D.ScreenTo2D(Camera.main.pixelWidth / 2, Camera.main.pixelHeight);
            transform.position = top;
        }
        else if (dir == DIRECTION.LEFT)
        {
            Vector3 left = Camera2D.ScreenTo2D(0, Camera.main.pixelHeight / 2);
            transform.position = left;
        }
        else if (dir == DIRECTION.RIGHT)
        {
            Vector3 right = Camera2D.ScreenTo2D(Camera.main.pixelWidth, Camera.main.pixelHeight / 2);
            transform.position = right;
        }
        else if (dir == DIRECTION.BOTTOM)
        {
            Vector3 bottom = Camera2D.ScreenTo2D(Camera.main.pixelWidth / 2, 0);
            transform.position = bottom;
        }
        else
        {
            Vector3 target = Camera2D.ScreenTo2D(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
            transform.position = target;
        }

    }
}
