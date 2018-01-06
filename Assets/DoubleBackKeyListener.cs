using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBackKeyListener : MonoBehaviour
{
    public GameObject t_QuitWarn;

    [SerializeField]
    private bool isTryingToQuit = false;

    private void Update()
    {
#if UNITY_ANDROID
        if (Input.GetKeyDown(KeyCode.Escape) && !isTryingToQuit)
        {
            StartCoroutine(Wait());
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isTryingToQuit)
        {
            Application.Quit();
        }
#endif
    }

    IEnumerator Wait()
    {
        t_QuitWarn.SetActive(true);
        isTryingToQuit = true;
        yield return new WaitForSeconds(2f);
        t_QuitWarn.SetActive(false);
        isTryingToQuit = false;
    }
}
