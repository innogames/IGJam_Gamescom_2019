using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    Rigidbody2D body;

    public List<Transform> partFixtures = new List<Transform> ();

    public List<ShipPart> parts = new List<ShipPart> ();

    void Awake () {
        body = GetComponent<Rigidbody2D> ();
    }

    void Update () {
        HandleParts ();
    }

    public void AddControl (ShipPart part, int slotId) {

        part.fixtureId = slotId;
        part.body = body;
        parts.Add (part);
    }

    public void SelectNextControl () { }

    void HandleParts () {
        // roll thtorugh list and update their position and rotation and such 
        foreach (ShipPart part in parts) {            
            part.TalkWithShip (this);
        }

    }
}