using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shielder : ShipPart {
    
    SFXLoop sfx;
    private SpriteRenderer _shownView;

    public Sprite PinkShielder;
    public Sprite BlueShielder;

    void Awake () {
        sfx = GetComponent<SFXLoop> ();
        _shownView = GetComponent<SpriteRenderer> ();
    }

    public override void Draw () { }

    public override void Activate () {
        base.Activate ();
        sfx.Play ();
        // GROW !! 
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