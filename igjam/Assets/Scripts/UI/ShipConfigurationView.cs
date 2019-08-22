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
		_cycleAliens = true;
		_cycleSlots = true;
		StartCoroutine(CycleAliens());
		StartCoroutine(CycleSlots());
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
			ShipControls.ActivateSelectedSlot();
			AvailableShipParts.ActivateSelectedSlot();
			_signalBus.Fire (new SystemSignal.Ship.ControlUpdated (ShipControls.CurrentSlotId, "A"));
			
		}
		if (Input.GetButtonUp("B"))
		{
			ShipControls.ActivateSelectedSlot();
			AvailableShipParts.ActivateSelectedSlot();
			_signalBus.Fire (new SystemSignal.Ship.ControlUpdated (ShipControls.CurrentSlotId, "B"));
		}
	}

	
}