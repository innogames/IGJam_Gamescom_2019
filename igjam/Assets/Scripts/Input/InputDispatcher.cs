using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class InputDispatcher : ITickable
{
	private enum State
	{
		NotConfigured,
		WaitingForConfiguration,
		ModeConfigured,
		LeftConfigured,
		RightConfigured,
		FullConfigured
	}

	private readonly SignalBus _signalBus;
	private State _currentState;
	private IEnumerable<KeyCode> _keyCodes;

	private KeyCode _modeSwitchKey;
	private KeyCode _leftKey;
	private KeyCode _rightKey;

	public InputDispatcher(SignalBus signalBus)
	{
		_signalBus = signalBus;
		_currentState = State.NotConfigured;
		_keyCodes = Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>();
		
		_signalBus.Subscribe<SystemSignal.GameMode.ConfigureInput>(SwitchToConfigureMode);
	}

	private void SwitchToConfigureMode()
	{
		_currentState = State.WaitingForConfiguration;
		_signalBus.TryUnsubscribe<SystemSignal.GameMode.ConfigureInput>(SwitchToConfigureMode);
		_signalBus.Fire<SystemSignal.GameMode.ConfigureInput.ConfigureMode>();
	}

	public void Tick()
	{
		switch (_currentState)
		{
			case State.NotConfigured:
				DispatchAnyInput();
				break;
			case State.WaitingForConfiguration:
				ConfigureMode();
				break;
			case State.ModeConfigured: 
				ConfigureLeft();
				break;
			case State.LeftConfigured:
				ConfigureRight();
				break;
			case State.FullConfigured:
				DispatchInput();
				break;
		}

	}

	private void DispatchAnyInput()
	{
		KeyCode pressedKey;
		if (GetAnyInput(out pressedKey))
		{
			_signalBus.Fire<InputSignal.AnyButton>();
		}
	}

	private void ConfigureMode()
	{
		KeyCode key; 
		
		if (GetAnyInput(out key))
		{
			_modeSwitchKey = key;
			_currentState = State.ModeConfigured;
			_signalBus.Fire<SystemSignal.GameMode.ConfigureInput.ConfigureLeft>();
		}
	}
	
	private void ConfigureLeft()
	{
		KeyCode key; 
		
		if (GetAnyInput(out key))
		{
			_leftKey = key;
			_currentState = State.LeftConfigured;
			_signalBus.Fire<SystemSignal.GameMode.ConfigureInput.ConfigureRight>();
		}
	}
	
	private void ConfigureRight()
	{
		
		KeyCode key; 
		
		if (GetAnyInput(out key))
		{
			_rightKey = key;
			_currentState = State.FullConfigured;
			_signalBus.Fire<SystemSignal.GameMode.ConfigureInput.FullConfigured>();
		}
	}

	private bool GetAnyInput(out KeyCode code)
	{
		code = KeyCode.A;
		foreach (var keyCode in _keyCodes)
		{
			if (Input.GetKeyDown(keyCode) && keyCode != KeyCode.Mouse0)
			{
				code = keyCode;
				return true;
			}
		}
		
		return false;
	}

	private void DispatchInput()
	{
		if (ModeActivated())
		{
			_signalBus.Fire<InputSignal.ModeSwitch>();
		}

		if (LeftActivated())
		{
			_signalBus.Fire<InputSignal.LeftButton>();
		}

		if (RightActivated())
		{
			_signalBus.Fire<InputSignal.RightButton>();
		}

		if (LeftUnbufferedActivated())
		{
			_signalBus.Fire<InputSignal.UnbufferedLeftButton>();
		}

		if (RightUnbufferedActivated())
		{
			_signalBus.Fire<InputSignal.UnbufferedRightButton>();
		}
	}

	private  bool ModeActivated()
	{
		if (_modeSwitchKey == null)
		{
			return false;
		}
		return Input.GetKeyUp(_modeSwitchKey);
	}
	
	private  bool LeftActivated()
	{
		if (_leftKey == null)
		{
			return false;
		}
		return Input.GetKeyUp(_leftKey);
	}
	
	private  bool LeftUnbufferedActivated()
	{
		if (_leftKey == null)
		{
			return false;
		}
		return Input.GetKey(_leftKey);
	}
	
	private  bool RightActivated()
	{
		if (_rightKey == null)
		{
			return false;
		}
		return Input.GetKeyUp(_rightKey);
	}
	private  bool RightUnbufferedActivated()
	{
		if (_rightKey == null)
		{
			return false;
		}
		return Input.GetKey(_rightKey);
	}
}