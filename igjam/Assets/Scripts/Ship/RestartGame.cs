using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class RestartGame : MonoBehaviour
{
	private SignalBus _signalBus;

	[Inject]
	public void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
		_signalBus.Subscribe<SystemSignal.RestartGame>(Restart);
	}

	private void Restart()
	{
		SceneManager.LoadScene(0);
	}
}