using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnShipPartButton : MonoBehaviour
{
	public string Button = "A";
	private ShipPart _internalConnectedPart;

	private ShipPart ConnectedPart
	{
		get
		{
			if (_internalConnectedPart == null)
			{
				_internalConnectedPart = GetComponentInParent<ShipPart>();
			}

			return _internalConnectedPart;
		}
	}

	private void OnEnable()
	{
		if (ConnectedPart != null)
		{
			gameObject.SetActive(Button == ConnectedPart.button);
		}
	}

	// Update is called once per frame
	void Update()
	{
	}
}