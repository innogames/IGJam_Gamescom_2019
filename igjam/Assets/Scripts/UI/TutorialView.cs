using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TutorialView : MonoBehaviour
{
	public GameObject InputControlView;
	public GameObject GameControlSwitch;
	public GameObject[] TutorialObjects;

	private int _currentIndex = -1;
	
	private SignalBus _signalBus;
	

	[Inject]
	public void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
		_signalBus.Subscribe<InputSignal.AnyButton>(TriggerNextStep);
		TriggerNextStep();
		TutorialObjects[0].SetActive(true);
	}

	private void DeactivateAll()
	{
		foreach (var tutorialObject in TutorialObjects)
		{
			tutorialObject.SetActive(false);
		}
	}

	private void TriggerNextStep()
	{
		DeactivateAll();
		_currentIndex++;
		if (TutorialObjects.Length > _currentIndex)
		{
			TutorialObjects[_currentIndex].SetActive(true);
		}
		else
		{
#if UNITY_ANDROID || UNITY_IOS			
		GameControlSwitch.SetActive(true);
#else
		InputControlView.SetActive(true);
#endif
			_signalBus.Fire<SystemSignal.GameMode.ConfigureInput>();
			_signalBus.TryUnsubscribe<InputSignal.AnyButton>(TriggerNextStep);
			gameObject.SetActive(false);
		}

	}

	
}