using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Ship : MonoBehaviour
{
	[HideInInspector()] public Rigidbody2D body;

	[HideInInspector()] public List<PartFixture> partFixtures = new List<PartFixture>();

	// already to the ship
	public List<ShipPart> parts = new List<ShipPart>();
	private SignalBus _signalBus;

	[Inject]
	void Init(SignalBus signalBus)
	{
		body = GetComponent<Rigidbody2D>();
		partFixtures.Clear();
		foreach (PartFixture f in GetComponentsInChildren<PartFixture>())
		{
			partFixtures.Add(f);
		}

		_signalBus = signalBus;
		_signalBus.Subscribe<SystemSignal.Ship.PartAttached>(AttachNewPart);
	}

	private void AttachNewPart(SystemSignal.Ship.PartAttached signal)
	{
		AddControl(signal.NewPart, signal.SlotId);
	}

	void Update()
	{
		HandleParts();
	}

	public void AddControl(ShipPart part, int slotId)
	{
		// part.body = body;
		// parts.Add (part);
		// parts[slotId].add(part); 

		partFixtures[slotId].part = part;
	}

	public void SelectNextControl()
	{
	}

	void HandleParts()
	{
		// roll thtorugh list and update their position and rotation and such 
		int i = 0;
		foreach (ShipPart part in parts)
		{
			// if (currentpart == i) {
			//     part.Activate ();
			// } else part.Deactivate ();
			// part.TalkWithShip (this);
			// i++;
		}
	}
}