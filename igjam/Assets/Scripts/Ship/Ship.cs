using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
	private IShipControl _activeShipControl;

	public void AddControl(IShipControl control, int slotId)
	{
	}

	public void SelectNextControl()
	{
	}
}

