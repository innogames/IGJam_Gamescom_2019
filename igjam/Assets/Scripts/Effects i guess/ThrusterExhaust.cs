using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterExhaust : EffectBase {

    Vector2 baseposition;

    void Start () {
        baseposition = transform.localPosition;
    }

    void Update () {
        if (SHOWING) {
            Vector2 r = Uhh.RandomVector ();
            transform.localPosition = baseposition + r;
            transform.localScale = Vector2.one;
        } else {
            transform.localScale = Vector2.zero;
        }
    }
}