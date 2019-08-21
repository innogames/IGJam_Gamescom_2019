using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameModel
{
	private readonly SignalBus _signalBus;

	public int SelectedAttachmentSlotId { get; private set; }
	public GameObject ActivePartPrefab;
	public Type ActiveState;
	
	public GameModel(SignalBus signalBus)
	{
		_signalBus = signalBus;
		_signalBus.Subscribe<SystemSignal.Ship.SlotSelected>( UpdateSelectedSlot);
		_signalBus.Subscribe<SystemSignal.GameMode.FlyMode.Activate>(() => ActiveState = typeof(FlyState) );
		_signalBus.Subscribe<SystemSignal.GameMode.ConfigureControls.Activate>(() => ActiveState = typeof(ConfigureControlsState) );
		_signalBus.Subscribe<SystemSignal.GameMode.ConfigureShip.Activate>(() => ActiveState = typeof(ConfigureShipState) );
	}

	private void UpdateSelectedSlot(SystemSignal.Ship.SlotSelected signal)
	{
		SelectedAttachmentSlotId = signal.SlotId;
	}

}