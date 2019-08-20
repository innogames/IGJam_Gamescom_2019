using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipConfigurationUI : MonoBehaviour
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
	
	void Start()
	{
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
			switch (_state)
			{
				case ConfigurationState.SelectControlSlot:
					ActivateShipSlots();
					break; 
				case ConfigurationState.SelectItem:
					ActivatePartSelection();
					break;
			}

		}
	}

	private void ActivatePartSelection()
	{
		_activeListView.Deactivate();
		_state = ConfigurationState.SelectControlSlot;
		_activeListView = ShipControls;
		_activeListView.Activate();
	}

	private void ActivateShipSlots()
	{
		if (_activeListView!=null)
		{
			_activeListView.Deactivate();
		}
		_state = ConfigurationState.SelectItem;
		_activeListView = AvailableShipParts;
		_activeListView.ActivateSelectedSlot();
		_activeListView.Activate();
	}
}