using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsBackKeyListener : MonoBehaviour {

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.instance.OffSettingsPanel();
        }
    }
}
