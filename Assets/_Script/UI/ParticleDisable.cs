using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDisable : MonoBehaviour {
    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    private IEnumerator Disable(){
        yield return new WaitForSeconds(0.7f);
        gameObject.SetActive(false);
    }
}
