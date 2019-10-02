using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputDispatcher : ITickable
{
	private readonly SignalBus _signalBus;

	public InputDispatcher(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	public void Tick()
	{
		if (Input.GetKeyUp(KeyCode.M))
		{
			_signalBus.Fire<InputSignal.ModeSwitch>();
		}
		
		

		if (Input.GetKeyUp(KeyCode.L))
		{
			_signalBus.Fire<InputSignal.LeftButton>();
		}

		if (Input.GetKeyUp(KeyCode.R))
		{
			_signalBus.Fire<InputSignal.RightButton>();
		}

		if (Input.GetKey(KeyCode.L))
		{
			_signalBus.Fire <InputSignal.UnbufferedLeftButton>();
		}
		
		if (Input.GetKey(KeyCode.R))
		{
			_signalBus.Fire <InputSignal.UnbufferedRightButton>();
		}
	}
}