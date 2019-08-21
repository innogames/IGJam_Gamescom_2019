using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXLoop : MonoBehaviour {

    // adjusts volumes of a looping source
    // islooping and sound clip needs to be set up in editor. 

    AudioSource source;
    float targetvolume;

    void Awake () {
        source = GetComponent<AudioSource> ();
    }

    void Update () {
        float volume = source.volume;
        volume = Mathf.Lerp (volume, targetvolume, .3f);
        source.volume = volume;
        targetvolume = Mathf.Lerp (targetvolume, 0, .125f);
    }

    public void Play () {
        targetvolume = 1;
    }
}