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

	private void DeactivateUI()
	{
		this.enabled = false;
	}

	private void ActivateUI()
	{
		this.enabled = true;
		ActivateShipSlots();
	}

	void Update()
	{
		if (Input.GetButtonUp("A"))
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
		if (Input.GetButtonUp("B"))
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