using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBase : MonoBehaviour {
 
    public bool SHOWING { get { return timer > 0; } }

    float duration = 0.25f;
    float timer;

    public void Show () {
        timer = duration;
    }
}