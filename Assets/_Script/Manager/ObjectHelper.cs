using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHelper : MonoBehaviour {

    public static ObjectHelper instance;

    public ObjectSetting[] _object;

    public Color leftColor, rightColor, playerColor;

    public Left _left;
    public Right _right;

    private void Awake()
    {
        if (instance == null) instance = this;
        StartGame();
    }

    private void StartGame(){
        var r = Random.Range(0, _object.Length); 
        leftColor = _object[r].leftColor;
        rightColor = _object[r].rightColor;
        playerColor = _object[r].playerColor;

        _left = new Left(leftColor, "Left");
        _right = new Right(rightColor, "Right");
    }

    public Color GetRandomColorFromPreset()
    {
        var r = Random.Range(0, 100);
        if (r % 2 == 0)
        {
            return leftColor;
        }
        else
        {
            return rightColor;
        }
    }
}

public class Left{
    public Color color;
    public string tag;

    public Left(Color _c, string _t){
        color = _c;
        tag = _t;
    }
}

public class Right {
    public Color color;
    public string tag;

    public Right(Color _c, string _t)
    {
        color = _c;
        tag = _t;
    }
}