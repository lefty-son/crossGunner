using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    public GameObject go;
    public static Vector2 ScreenTo2D(float x2, float y2)
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(x2, y2));
    }
}
