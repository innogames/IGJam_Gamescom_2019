using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : ShipPart {

    public float force;

    public override void Draw () {
        Debug.DrawRay (POS, LOOKDIR, Color.red, .1f);

    }

    public override void Activated () {
        base.Activated(); 
        Vector2 dir = -Uhh.VectorFromAngle (ROT);
        body.AddForceAtPosition (LOOKDIR * force, POS, ForceMode2D.Force);
    }

}