using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditBackKeyListener : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.instance.OffCreditPanel();
        }
    }
}
