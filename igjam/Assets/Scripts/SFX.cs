using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour {

    // plays a oneshot sound effect 
    // can randomize which file to use
    // w pitch shifting

    public float pitchShifting = 0;
    public List<AudioClip> sounds = new List<AudioClip> ();

    AudioSource source;

    void Awake () {
        source = GetComponent<AudioSource> ();

    }

    void Update () {

    }

    public void Play () {
        if (sounds.Count == 0) return;
        if (source == null) return;

        if (source.isPlaying) source.Stop ();

        int r = Random.Range (0, sounds.Count);
        source.clip = sounds[r];
        if (pitchShifting > 0) {
            source.pitch = 1f + Random.Range (-pitchShifting, pitchShifting);
        }
        source.Play ();
    }
}