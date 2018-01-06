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
        _audio.PlayOneShot(destroy);
    }

    public void PlayItem(){
        _audio.PlayOneShot(item);
    }

    public void PlayDeath(){

        var r = Random.Range(0, 2);
        if(r == 0){
            _audio.PlayOneShot(deathOne);
        }
        else {
            _audio.PlayOneShot(deathTwo);

        }
    }
}
