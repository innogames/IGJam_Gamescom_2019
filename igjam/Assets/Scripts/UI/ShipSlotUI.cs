using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class ShipSlotUI :  SelectableControl
{
	private Button _connectedButton;

	void Start()
	{
		_connectedButton = GetComponent<Button>();
	}

	public override void Select()
	{
		_connectedButton.image.color = Color.red;
	}

	public override void Deselect()
	{
		_connectedButton.image.color = Color.white;
	}

	public override void Activate()
	{
		_connectedButton.image.color = Color.green;
	}
}