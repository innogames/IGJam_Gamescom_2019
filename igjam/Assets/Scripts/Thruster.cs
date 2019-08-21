﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : ShipPart {

    public float force;

    public override void Draw () {

    }

    public override void Activate () {
        base.Activate ();
        Vector2 dir = -Uhh.VectorFromAngle (ROT);
        float stability = .5f;
        ship.body.AddForceAtPosition (LOOKDIR * force * (1 - stability), POS, ForceMode2D.Force);
        ship.body.AddForce (LOOKDIR * force * stability, ForceMode2D.Force);
        // body is null here !! 

    }

}