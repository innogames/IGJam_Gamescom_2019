using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartFixture : MonoBehaviour {

    public ShipPart part;

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
            part.DisconnectFromShip ();
            part.body.AddForce (Uhh.VectorFromAngle (transform.rotation.eulerAngles.z) * 5f, ForceMode2D.Impulse);
        }
        part = null;
    }
}