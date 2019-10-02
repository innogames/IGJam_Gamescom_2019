using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ModeSwitchButton : MonoBehaviour
{
	private SignalBus _signalBus;

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
}