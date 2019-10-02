using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameModeController : ListUI
{
	private SignalBus _signalBus;

	[Inject]
	public void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
		_signalBus.Subscribe<InputSignal.ModeSwitch>(SelectNextSlot);
		SelectNextSlot();
		
	}
}

public class GameState : SelectableControl
{
	public override void Select()
	{
		Activate();
	}

	public override void Deselect()
	{
		gameObject.SetActive(false);
	}

	public override void Activate()
	{
		gameObject.SetActive(true);
	}
}




