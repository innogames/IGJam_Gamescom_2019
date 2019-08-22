using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartFixture : MonoBehaviour {

    public ShipPart part;

    public Vector2 LOOKDIR { get { return Uhh.VectorFromAngle (transform.rotation.eulerAngles.z); } }

    public float thrusterstability = 1;

    Ship ship;

    void Start () {
        ship = GetComponentInParent<Ship> ();
    }

    void Update () {
        bool haspart = part != null;
        if (haspart) {
            part.TalkWithShip (ship, this);
        }
    }

    public void Pop () {
        // if have part : pop it 

        if (part != null) {
            part.EnablePhysics ();
            part.body.AddForce (LOOKDIR * 5f, ForceMode2D.Impulse);
            part.VOICE.Say (part.VOICE.popOut);
        }
        part = null;
    }
}