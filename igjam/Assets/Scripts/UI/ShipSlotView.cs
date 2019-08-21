using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class ShipSlotView :  SelectableControl
{
	public int SlotId;
	public Animator AnimationControl;
	private SignalBus _signalBus;

	[Inject]
	void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	public override void Select()
	{
		AnimationControl.SetTrigger("Select");
	}

	public override void Deselect()
	{
		AnimationControl.SetTrigger("Deselect");
	}

	public override void Activate()
	{
		AnimationControl.SetTrigger("Hide");
		_signalBus.Fire(new SystemSignal.Ship.SlotSelected(SlotId));
	}
}