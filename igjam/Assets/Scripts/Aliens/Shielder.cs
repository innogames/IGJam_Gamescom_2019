using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shielder : ShipPart {

    SFXLoop sfx;
    private SpriteRenderer _shownView;

    public Sprite PinkShielder;
    public Sprite BlueShielder;

    public bool ISSHIELDING { get { return shieldingtimer > 0; } }
    public float shieldingtimer;

    void Awake () {
        sfx = GetComponent<SFXLoop> ();
        _shownView = GetComponent<SpriteRenderer> ();
    }

    public override void Draw () {
        if (shieldingtimer > 0) {
            shieldingtimer -= Time.deltaTime;
            Debug.DrawRay (transform.position, Uhh.VectorFromAngle (transform.rotation.eulerAngles.z), Color.yellow);
        }
    }

    public override void Activate () {
        base.Activate ();
        sfx.Play ();
        // GROW !! 
        shieldingtimer = 0.25f;
        ShowEffects ();
        VOICE.Say (voice.shield);
    }

    public override void AssignButton (string newControlName) {
        base.AssignButton (newControlName);
        if (button == "A") {
            _shownView.sprite = BlueShielder;
        } else {
            _shownView.sprite = PinkShielder;
        }
    }
}