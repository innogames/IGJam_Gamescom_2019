using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShipConfigurationView : MonoBehaviour
{
	private enum ConfigurationState
	{
		SelectControlSlot, 
		SelectItem
	}

	public ListUI ShipControls;
	public ListUI AvailableShipParts;

	private ConfigurationState _state;
	private ListUI _activeListView;
	private SignalBus _signalBus;

	[Inject]
	void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
		_signalBus.Subscribe<SystemSignal.GameMode.ConfigureShip.Activate>(ActivateUI);
		_signalBus.Subscribe<SystemSignal.GameMode.ConfigureShip.Deactivate>(DeactivateUI);
		ActivateShipSlots();
		//DeactivateUI();
		
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
		if (_activeListView == null)
		{
			return;
		}

		 
		if (Input.GetButtonUp("A"))
		{
			_activeListView.SelectNextSlot();
		}
		if (Input.GetButtonUp("B"))
		{
			_activeListView.ActivateSelectedSlot();
			switch (_state)
			{
				case ConfigurationState.SelectControlSlot:
					ActivatePartSelection();
					break; 
				case ConfigurationState.SelectItem:
					ActivateShipSlots();
					break;
			}

		}
	}

	private void ActivatePartSelection()
	{
		if (_activeListView!=null)
		{
			_activeListView.Deactivate();
		}
		_state = ConfigurationState.SelectItem;
		_activeListView = AvailableShipParts;
		_activeListView.Activate();
	}

	private void ActivateShipSlots()
	{
		if (_activeListView!=null)
		{
			_activeListView.Deactivate();
		}
		
		_state = ConfigurationState.SelectControlSlot;
		_activeListView = ShipControls;
		_activeListView.Activate();
		
	}
}