using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


[RequireComponent(typeof(Button))]
public class ShipSlotUI :  SelectableControl
{
	public int SlotId;
	private Button _connectedButton;
	private SignalBus _signalBus;


	[Inject]
	void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
		_connectedButton = GetComponent<Button>();
	}

	public override void Select()
	{
		_connectedButton.image.color = Color.red;
	}

	public override void Deselect()
	{
		_connectedButton.image.color = Color.white;
	}

	public override void Activate()
	{
		_connectedButton.image.color = Color.green;
		_signalBus.Fire(new SystemSignal.Ship.SlotSelected(SlotId));
	}
}