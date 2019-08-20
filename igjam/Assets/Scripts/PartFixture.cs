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
}