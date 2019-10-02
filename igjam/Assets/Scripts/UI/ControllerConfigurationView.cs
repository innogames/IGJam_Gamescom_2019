using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ControllerConfigurationView : MonoBehaviour
{
	private enum ConfigurationState
	{
		SelectControlSlot,
		SelectButton
	}

	public ListUI ShipControls;

	private ConfigurationState _state;
	private SignalBus _signalBus;

	[Inject]
	void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
		_signalBus.Subscribe<SystemSignal.GameMode.ConfigureControls.Activate>(ActivateUI);
		_signalBus.Subscribe<SystemSignal.GameMode.ConfigureControls.Deactivate>(DeactivateUI);
		ActivateShipSlots();
		DeactivateUI();
	}

	private void OnDestroy()
	{
		if (_signalBus != null)
		{
			_signalBus.TryUnsubscribe<SystemSignal.GameMode.ConfigureControls.Activate>(ActivateUI);
			_signalBus.TryUnsubscribe<SystemSignal.GameMode.ConfigureControls.Deactivate>(DeactivateUI);
			
		}

	}

	private void DeactivateUI()
	{
		this.enabled = false;
		_signalBus.TryUnsubscribe<InputSignal.LeftButton>(SelectSlotForLeft);
		_signalBus.TryUnsubscribe<InputSignal.RightButton>(SelectSlotForRight);
	}

	private void ActivateUI()
	{
		this.enabled = true;
		ActivateShipSlots();
		_signalBus.Subscribe<InputSignal.LeftButton>(SelectSlotForLeft);
		_signalBus.Subscribe<InputSignal.RightButton>(SelectSlotForRight);
	}

	private void SelectSlotForRight()
	{
		ShipControls.ActivateSelectedSlot();
		switch (_state)
		{
			case ConfigurationState.SelectControlSlot:
				ActivateControlSelection();
				break;
			case ConfigurationState.SelectButton:
				_signalBus.Fire(new SystemSignal.Ship.ControlUpdated(ShipControls.CurrentSlotId, "B"));
				ActivateShipSlots();
				break;
		}
		
	}

	private void SelectSlotForLeft()
	{
		switch (_state)
		{
			case ConfigurationState.SelectControlSlot:
				ShipControls.SelectNextSlot();
				break;
			case ConfigurationState.SelectButton:
				_signalBus.Fire(new SystemSignal.Ship.ControlUpdated(ShipControls.CurrentSlotId, "A"));
				ActivateShipSlots();
				break;
		}
	}

	private void ActivateControlSelection()
	{
		ShipControls.Deactivate();
		_state = ConfigurationState.SelectButton;
	}

	private void ActivateShipSlots()
	{
		_state = ConfigurationState.SelectControlSlot;
		ShipControls.Activate();
	}
}