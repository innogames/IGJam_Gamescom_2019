using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListUI : MonoBehaviour
{
	protected int _currentSlotId;
	public SelectableControl[] Slots;

	protected virtual void DeactivateCurrentElement()
	{
		Slots[_currentSlotId].Deselect();
	}

	protected virtual void SelectCurrentElement()
	{
		Slots[_currentSlotId].Select();
	}

	public void SelectPreviousSlot()
	{
		DeactivateCurrentElement();

		_currentSlotId--;
		if(_currentSlotId < 0)
		{
			_currentSlotId = Slots.Length-1;
		}
		SelectCurrentElement();
	}

	public void SelectNextSlot()
	{
		DeactivateCurrentElement();
		_currentSlotId++;
		if(_currentSlotId >= Slots.Length)
		{
			_currentSlotId = 0;
		}
		SelectCurrentElement();
	}

	public void ActivateSelectedSlot()
	{
		Slots[_currentSlotId].Activate();
	}

	public void Deactivate()
	{
		DeactivateCurrentElement();
	}

	public void Activate()
	{
		SelectCurrentElement();
	}
}