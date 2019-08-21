using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : ShipPart
{
	SFXLoop sfx;
	public float force;
	private SpriteRenderer _shownView;


	public float Stablity = 0.5f;

	public Sprite PinkThruster;
	public Sprite BlueThruster;

	void Awake()
	{
		sfx = GetComponent<SFXLoop>();
		_shownView = GetComponent<SpriteRenderer>();
	}

	public override void Draw()
	{
	}

    public override void Activate () {
        base.Activate ();
        Vector2 dir = -Uhh.VectorFromAngle (ROT);
        ship.body.AddForceAtPosition (LOOKDIR * force * (1 - Stablity), POS, ForceMode2D.Force);
        ship.body.AddForce (LOOKDIR * force * Stablity, ForceMode2D.Force);
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