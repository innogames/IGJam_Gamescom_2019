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

	public float SlotCycleDelay = 0.2f;
	public float AlienCycleDelay = 0.5f;

	private ConfigurationState _state;
	private ListUI _activeListView;
	private SignalBus _signalBus;
	private bool _cycleAliens;
	private bool _cycleSlots;

	[Inject]
	void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
		_signalBus.Subscribe<SystemSignal.GameMode.ConfigureShip.Activate>(ActivateUI);
		_signalBus.Subscribe<SystemSignal.GameMode.ConfigureShip.Deactivate>(DeactivateUI);
		DeactivateUI();
		_state = ConfigurationState.SelectControlSlot;

	}

	private void DeactivateUI()
	{
		this.enabled = false;
		_cycleAliens = false;
		_cycleSlots = false;
		StopAllCoroutines();
	}

	private void ActivateUI()
	{
		this.enabled = true;
		StartSelectSlots();	
	}


	
	private IEnumerator CycleSlots()
	{
		float slotDelay = SlotCycleDelay;
		while (_cycleSlots)
		{
			yield return new WaitForSeconds(slotDelay);
			ShipControls.SelectNextSlot();
			yield return null;
		}
	}
	
	private IEnumerator CycleAliens()
	{
		float slotDelay = AlienCycleDelay;
		while (_cycleAliens)
		{
			yield return new WaitForSeconds(slotDelay);
			AvailableShipParts.SelectNextSlot();
			yield return null;
		}
	}

	void Update()
	{	 
		if (Input.GetButtonUp("A"))
		{
			if (_state == ConfigurationState.SelectControlSlot)
			{
				StartSelectAliens();
			}
			else
			{
				AvailableShipParts.ActivateSelectedSlot();
				_signalBus.Fire (new SystemSignal.Ship.ControlUpdated (ShipControls.CurrentSlotId, "A"));
				StartSelectSlots();
			}
			
		}
		if (Input.GetButtonUp("B"))
		{
			if (_state == ConfigurationState.SelectControlSlot)
			{
				StartSelectAliens();
			}
			else
			{
				AvailableShipParts.ActivateSelectedSlot();
				_signalBus.Fire(new SystemSignal.Ship.ControlUpdated(ShipControls.CurrentSlotId, "B"));
				StartSelectSlots();
			}
		}
		
		
	}

	private void StartSelectAliens()
	{
		StopAllCoroutines();
		_signalBus.Fire (new SystemSignal.Ship.ConfigureControls());
		ShipControls.ActivateSelectedSlot();
		_state = ConfigurationState.SelectItem;
		_cycleSlots = false;
		_cycleAliens = true;
		StartCoroutine(CycleAliens());
	}

	private void StartSelectSlots()
	{
		StopAllCoroutines();
		_signalBus.Fire (new SystemSignal.Ship.ConfigureSlots());
		_cycleAliens = true;
		_cycleSlots = true;
		_state = ConfigurationState.SelectControlSlot;
		StartCoroutine(CycleSlots());
	}
}