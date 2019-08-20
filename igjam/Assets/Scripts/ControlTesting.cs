using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTesting : MonoBehaviour {

    void Start () {

    }

    void Update () {
        Vector2 scale = Vector2.one;
        if (Input.GetButton ("A")) {
            scale += Vector2.one * .3f;
        }
        if (Input.GetButton ("B")) {
            scale -= Vector2.one * .3f;
        }
        transform.localScale = Vector3.Lerp (transform.localScale, scale, .2f);
    }
}