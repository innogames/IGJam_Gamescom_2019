using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : ShipPart {

    public float force;

    public override void Draw () {

    }

    public override void Activate () {
        base.Activate ();
        Vector2 dir = -Uhh.VectorFromAngle (ROT);
        ship.body.AddForceAtPosition (LOOKDIR * force, POS, ForceMode2D.Force);
        // body is null here !! 
        
        Debug.DrawRay (POS, LOOKDIR, Color.red, .1f);

    }

}