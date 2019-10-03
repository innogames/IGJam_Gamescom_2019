using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ModeSwitchButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private SignalBus _signalBus;
	private bool _isPressed;
	private float _downTime;

	[Inject]
	public void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	public void SwitchMode()
	{
		_signalBus.Fire<InputSignal.ModeSwitch>();
		_signalBus.Fire<InputSignal.AnyButton>();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		_isPressed = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_isPressed = false;
	}

	private void Update()
	{
		if (_isPressed)
		{
			_downTime += Time.deltaTime;
		}

		if (_downTime > 3)
		{
			_isPressed = false;
			_downTime = 0;
			_signalBus.Fire<SystemSignal.RestartGame>();
		}
	}
}