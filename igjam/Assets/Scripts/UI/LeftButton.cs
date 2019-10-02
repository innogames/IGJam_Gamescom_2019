using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class LeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private SignalBus _signalBus;
	private bool _isPressed;

	[Inject]
	public void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_isPressed = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_isPressed = false;
		_signalBus.Fire<InputSignal.LeftButton>();
	}

	private void Update()
	{
		if (_isPressed)
		{
			_signalBus.Fire<InputSignal.UnbufferedLeftButton>();
		}

	}
}