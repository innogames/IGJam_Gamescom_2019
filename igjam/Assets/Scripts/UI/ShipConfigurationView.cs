using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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