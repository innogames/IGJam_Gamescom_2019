using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


[RequireComponent(typeof(SpriteRenderer))]
public class ShipSlotView :  SelectableControl
{
	public int SlotId;
	private SpriteRenderer _connectedButton;
	private SignalBus _signalBus;


	[Inject]
	void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
		_connectedButton = GetComponent<SpriteRenderer>();
	}

	public override void Select()
	{
		_connectedButton.color = Color.red;
	}

	public override void Deselect()
	{
		_connectedButton.color = Color.white;
	}

	public override void Activate()
	{
		_connectedButton.color = Color.green;
		_signalBus.Fire(new SystemSignal.Ship.SlotSelected(SlotId));
	}
}