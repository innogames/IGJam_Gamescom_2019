using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : ShipPart
{
	SFXLoop sfx;
	public float force;
	private SpriteRenderer _shownView;

	public Sprite PinkThruster;
	public Sprite BlueThruster;

	void Awake()
	{
		sfx = GetComponent<SFXLoop>();
	}

	public override void Draw()
	{
	}

    public override void Activate () {
        base.Activate ();
        Vector2 dir = -Uhh.VectorFromAngle (ROT);
        float stability = .5f;
        ship.body.AddForceAtPosition (LOOKDIR * force * (1 - stability), POS, ForceMode2D.Force);
        ship.body.AddForce (LOOKDIR * force * stability, ForceMode2D.Force);
        sfx.Play ();
    }

	public override void AssignButton(string newControlName)
	{
		base.AssignButton(newControlName);
		if (button == "A")
		{
			_shownView.sprite = BlueThruster;
		}
		else
		{
			_shownView.sprite = PinkThruster;
		}
	}
}