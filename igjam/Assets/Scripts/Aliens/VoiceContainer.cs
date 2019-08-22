using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceContainer : MonoBehaviour {

    public List<AlienVoice> voices = new List<AlienVoice> ();

    static VoiceContainer inst;

    int counter;

    void Awake () {
        inst = this;
        int n = voices.Count;
        // scramble
        for (int i = 0; i < n; i++) {
            int r = Random.Range (i, n);
            AlienVoice av = voices[r];
            voices[r] = voices[i];
            voices[i] = av;
        }
    }

    public static AlienVoice GetVoiceSetup () {
        int i = inst.counter;
        inst.counter++;
        return (Instantiate (inst.voices[i], Vector2.zero, Quaternion.identity).GetComponent<AlienVoice> ());
    }

}