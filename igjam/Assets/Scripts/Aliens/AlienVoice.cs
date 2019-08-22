using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienVoice : MonoBehaviour {

    public List<AudioClip> hoverOver = new List<AudioClip> ();
    public List<AudioClip> pickUp = new List<AudioClip> ();
    public List<AudioClip> popOut = new List<AudioClip> ();

    public List<AudioClip> assign = new List<AudioClip> ();
    public List<AudioClip> shield = new List<AudioClip> ();
    public List<AudioClip> thruster = new List<AudioClip> ();

    AudioSource src;

    void Awake () {
        cooldown = .1f;

        GameObject g = new GameObject ("voice");
        g.transform.SetParent (transform);
        g.transform.localPosition = Vector2.zero;
        src = g.AddComponent<AudioSource> ();

    }

    float cooldown;

    void Update () {
        if (cooldown > 0) {
            cooldown -= Time.deltaTime;
        }
    }

    // takes a random clip from l and plays it 
    public void Say (List<AudioClip> l) {
        if (cooldown > 0) return;
        ForceSay (l);
    }
    public void ForceSay (List<AudioClip> l) {
        int r = Random.Range (0, l.Count);
        src.clip = l[r];
        src.pitch = 1f + Random.Range (-1f, 1f) * .05f;
        src.Play ();
        cooldown = src.clip.length + Random.Range (.25f, 1f);
    }
}