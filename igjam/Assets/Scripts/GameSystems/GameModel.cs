using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameModel
{
	private readonly SignalBus _signalBus;

	public int SelectedAttachmentSlotId { get; private set; }
	public GameObject ActivePartPrefab;
	
	public GameModel(SignalBus signalBus)
	{
		_signalBus = signalBus;
		_signalBus.Subscribe<SystemSignal.Ship.SlotSelected>( UpdateSelectedSlot);
	}

	private void UpdateSelectedSlot(SystemSignal.Ship.SlotSelected signal)
	{
		SelectedAttachmentSlotId = signal.SlotId;
	}

}