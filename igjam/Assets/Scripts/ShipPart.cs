using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPart : MonoBehaviour, IShipControl {

    public Vector2 POS { get { return transform.position; } }
    public float ROT { get { return transform.rotation.eulerAngles.z; } }
    public Vector2 LOOKDIR { get { return -Uhh.VectorFromAngle (ROT); } }

    protected Rigidbody2D body;

    public string button = "A";

    void Awake () {
        body = GetComponentInParent<Rigidbody2D> ();
    }

    void OnConnect () { }

    void Update () {
        Draw ();
        if (Input.GetButton (button)) Activate ();
        if (activated) transform.localScale = Vector2.one * .75f;
        else transform.localScale = Vector2.one * .5f;
        Deactivate();
    }

    public virtual void Draw () { }
    bool activated;
    public virtual void Activate () {
        activated = true;
    }

    public void Deactivate()
    {
        activated = false;
    }
}