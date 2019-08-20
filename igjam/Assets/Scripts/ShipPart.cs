using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPart : MonoBehaviour, IShipControl {

    public Vector2 POS { get { return transform.position; } set { transform.position = value; } }
    public float ROT { get { return transform.rotation.eulerAngles.z; } set { transform.rotation = Uhh.Rotation (Uhh.VectorFromAngle (value)); } }
    public Vector2 LOOKDIR { get { return -Uhh.VectorFromAngle (ROT); } }

    public Rigidbody2D body;

    public int fixtureId = -1;

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
    public virtual void Activate () {
        activated = true;
    }

    public void Deactivate () {
        activated = false;
    }

    public void TalkWithShip (Ship ship) {

        Transform fixture = ship.partFixtures[fixtureId];
        ROT = fixture.eulerAngles.z;
        Vector2 pos = ship.transform.position;
        Vector2 offset = Uhh.RotatedVector (fixture.localPosition, ship.transform.rotation.eulerAngles.z);

        if (activated) offset += LOOKDIR * .25f;

        POS = Vector2.Lerp(POS, pos + offset, .35f);
        ROT = Mathf.LerpAngle(ROT, fixture.eulerAngles.z, .35f); 
    }

}