using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float pushaway = 10;
    public float selfbounce = 50;
    public float wobblespeed = 100;

    Rigidbody2D body;
    Vector2 startpos;

    public SFX bounceSFX;
    public SFX shieldedSFX;

    float stuntimer;

    void Awake () {
        body = GetComponent<Rigidbody2D> ();
        startpos = transform.position;
        transform.rotation = Random.rotationUniform; 
    }

    void Update () {
        float spd = wobblespeed;
        if (stuntimer > 0) {
            stuntimer -= Time.deltaTime;
            spd *= 0.025f;
        }
        Vector2 p = transform.position;
        Vector2 tostart = startpos - p;
        if (tostart.magnitude > 3) tostart = tostart.normalized * 3;
        body.AddForce (tostart * spd);
    }

    void OnCollisionEnter2D (Collision2D col) {
        Rigidbody2D subject = col.collider.gameObject.GetComponent<Rigidbody2D> ();
        if (subject != null) {
            ContactPoint2D c = col.contacts[0];
            Vector2 away = (col.collider.gameObject.transform.position - transform.position).normalized;

            Ship s = subject.GetComponent<Ship> ();
            if (s != null) {
                // figure out if shielder is active on the ship, skip the collision if so. 
                if (s.IsShieldedTowards (c.normal)) {
                    body.AddForceAtPosition (-away * selfbounce, c.point, ForceMode2D.Impulse);
                    shieldedSFX.Play ();
                    stuntimer = 10f;
                    return;
                }
            }

            stuntimer = .75f;
            subject.AddForceAtPosition (away * pushaway, c.point, ForceMode2D.Impulse);
            body.AddForceAtPosition (-away * selfbounce, c.point, ForceMode2D.Impulse);
            bounceSFX.Play ();
        }
    }
}