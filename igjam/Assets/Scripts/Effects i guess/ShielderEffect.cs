using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShielderEffect : EffectBase {

    Vector2 baseposition;

    void Start () {
        baseposition = transform.localPosition;
    }

    public override void Update () {

        float lerpspeed = 0.3f;

        base.Update ();
        Vector2 targetpos = Vector2.zero;
        Vector2 targetscale = Vector2.one * Random.Range (.9f, 1.1f);
        if (SHOWING) {
            Vector2 r = Uhh.RandomVector ();
            r += new Vector2 (transform.up.x, transform.up.y);
            targetpos = baseposition + r;
        } else {
            targetscale = Vector2.zero;
            targetpos = Vector2.zero;
        }
        transform.localScale = Vector2.Lerp (transform.localScale, targetscale, lerpspeed);
        transform.localPosition = Vector2.Lerp (transform.localPosition, targetpos, lerpspeed);

    }
}