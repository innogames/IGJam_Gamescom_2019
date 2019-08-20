using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPart : MonoBehaviour, IShipControl {

    public Vector2 POS { get { return transform.position; } set { transform.position = value; } }
    public float ROT { get { return transform.rotation.eulerAngles.z; } set { transform.rotation = Uhh.Rotation (Uhh.VectorFromAngle (value)); } }
    public Vector2 SCALE { get { return transform.localScale; } set { transform.localScale = value; } }
    public Vector2 LOOKDIR { get { return -Uhh.VectorFromAngle (ROT); } }

    public Rigidbody2D body;

    public string button = "A";

    void Awake () {
        body = GetComponentInParent<Rigidbody2D> ();
    }

    void Update () {
        Draw ();

        // debug stuff: 
        if (Input.GetButton (button)) Activate ();
        else Deactivate ();
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

        this.body = ship.body; 

        Vector2 pos = ship.transform.position;
        Vector2 offset = Uhh.RotatedVector (fixture.transform.localPosition, ship.transform.rotation.eulerAngles.z);
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