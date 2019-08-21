using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    float pushaway = 10;
    float selfbounce = 50;
    float wobblespeed = 100;

    Rigidbody2D body;
    Vector2 startpos;

    SFX bounceSFX;

    void Awake () {
        body = GetComponent<Rigidbody2D> ();
        startpos = transform.position;
        bounceSFX = GetComponent<SFX> ();
    }

    void Update () {
        Vector2 p = transform.position;
        Vector2 tostart = startpos - p;
        body.AddForce (tostart * wobblespeed);
    }

    void OnCollisionEnter2D (Collision2D col) {
        Rigidbody2D subject = col.collider.gameObject.GetComponent<Rigidbody2D> ();
        if (subject != null) {
            ContactPoint2D c = col.contacts[0];
            Vector2 away = (col.collider.gameObject.transform.position - transform.position).normalized;
            subject.AddForceAtPosition (away * pushaway, c.point, ForceMode2D.Impulse);
            body.AddForceAtPosition (-away * selfbounce, c.point, ForceMode2D.Impulse);
            bounceSFX.Play ();
        }
    }
}