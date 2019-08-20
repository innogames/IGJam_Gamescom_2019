using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPart : MonoBehaviour, IShipControl {

    public Vector2 POS { get { return transform.position; } set { transform.position = value; } }
    public float ROT { get { return transform.rotation.eulerAngles.z; } set { transform.rotation = Uhh.Rotation (Uhh.VectorFromAngle (value)); } }
    public Vector2 SCALE { get { return transform.localScale; } set { transform.localScale = value; } }
    public Vector2 LOOKDIR { get { return -Uhh.VectorFromAngle (ROT); } }

    public Ship ship;

    [HideInInspector ()]
    public Rigidbody2D body;
    CircleCollider2D col;

    public string button = "A";

    void Awake () {
        body = GetComponent<Rigidbody2D> ();
        col = GetComponent<CircleCollider2D> ();
    }

    void Update () {

        Draw ();

        if (ship == null) return;

        // debug stuff: 
        if (Input.GetButton (button)) Activate ();
        else Deactivate ();
    }

    public virtual void DisconnectFromShip () {
        body.simulated = true;
        col.enabled = true;
    }
    public virtual void ConnectToShip () {
        body.simulated = false;
        col.enabled = false;
    }

    public virtual void Draw () { }
    bool activated;
    bool selected;
    public virtual void Activate () {
        activated = true;
    }

    public void Deactivate () {
        activated = false;
    }

    public void Select () {
        selected = true;
    }

    public void TalkWithShip (Ship ship, PartFixture fixture) {

        this.ship = ship;

        // Vector2 pos = ship.transform.position;
        // Vector2 offset = Uhh.RotatedVector (fixture.transform.localPosition, ship.transform.rotation.eulerAngles.z);
        Vector2 pos = fixture.transform.position;
        pos -= LOOKDIR * .5f;
        Vector2 offset = Vector2.zero;
        Vector2 scale = Vector2.one * .7f;

        if (activated) {
            offset += LOOKDIR * .25f;
        }

        if (selected) {
            scale = Vector2.one;
        }

        POS = Vector2.Lerp (POS, pos + offset, .35f);
        ROT = Mathf.LerpAngle (ROT, fixture.transform.eulerAngles.z, .35f);
        SCALE = Vector2.Lerp (SCALE, scale, .35f);
        selected = false;
    }

}