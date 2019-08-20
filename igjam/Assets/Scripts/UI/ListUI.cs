using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListUI : MonoBehaviour
{
	public int CurrentSlotId { get; protected set; }
	public SelectableControl[] Slots;

	protected virtual void DeactivateCurrentElement()
	{
		Slots[CurrentSlotId].Deselect();
	}

	protected virtual void SelectCurrentElement()
	{
		Slots[CurrentSlotId].Select();
	}

	public void SelectPreviousSlot()
	{
		DeactivateCurrentElement();

		CurrentSlotId--;
		if(CurrentSlotId < 0)
		{
			CurrentSlotId = Slots.Length-1;
		}
		SelectCurrentElement();
	}

	public void SelectNextSlot()
	{
		DeactivateCurrentElement();
		CurrentSlotId++;
		if(CurrentSlotId >= Slots.Length)
		{
			CurrentSlotId = 0;
		}
		SelectCurrentElement();
	}

	public void ActivateSelectedSlot()
	{
		Slots[CurrentSlotId].Activate();
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