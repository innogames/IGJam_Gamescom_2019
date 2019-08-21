using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterExhaust : EffectBase {

    Vector2 baseposition;

    void Start () {
        baseposition = transform.localPosition;
    }

    public override void Update () {
        base.Update ();
        Vector2 targetscale = Vector2.one * Random.Range (.9f, 1.1f);
        if (SHOWING) {
            Vector2 r = Uhh.RandomVector ();
            transform.localPosition = baseposition + r;
        } else {
            targetscale = Vector2.zero;
        }
        transform.localScale = Vector2.Lerp (transform.localScale, targetscale, .3f);
    }
}