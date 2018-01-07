using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;
    private AudioSource _audio;

    public AudioClip destroy, item, deathOne, deathTwo;
    private void Awake()
    {
        if (instance == null) instance = this;
        _audio = GetComponent<AudioSource>();
    }

    public void PlayDestroy(){
        if(PrefManager.instance.GetIsMuted() == 1){
            return;
        }
        _audio.PlayOneShot(destroy);
    }

    public void PlayItem(){
        if (PrefManager.instance.GetIsMuted() == 1)
        {
            return;
        }
        _audio.PlayOneShot(item);
    }

    public void PlayDeath(){
        if (PrefManager.instance.GetIsMuted() == 1)
        {
            return;
        }
        var r = Random.Range(0, 2);
        if(r == 0){
            _audio.PlayOneShot(deathOne);
        }
        else {
            _audio.PlayOneShot(deathTwo);
        }
    }
}
