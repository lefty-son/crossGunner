using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blur : MonoBehaviour {

    [SerializeField]
    private Material rend;

    private void Awake()
    {
        rend = GetComponent<Image>().material;
        rend.shader = Shader.Find("Custom/BLUR");
    }
 

    IEnumerator BlurIn(){
        var t = 0f;
        while(t <= 0.2f){
            t += Time.deltaTime;
            yield return null;
            rend.SetFloat("_Size", Mathf.Lerp(0f, 2f, t / 0.2f));
        }
    }

    IEnumerator BlurOut(){
        var t = 0f;
        while (t <= 0.2f)
        {
            t += Time.deltaTime;
            yield return null;
            rend.SetFloat("_Size", Mathf.Lerp(2f, 0f, t / 0.2f));
        }
    }

    private void OnEnable()
    {
        StartCoroutine(BlurIn());
    }


}
