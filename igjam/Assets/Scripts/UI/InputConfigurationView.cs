using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class InputConfigurationView : MonoBehaviour
{
	private SignalBus _signalBus;

	public GameObject ConfigureModeUI;
	public GameObject ConfigureLeftUI;
	public GameObject ConfigureRightUI;
	public Text ConfigureText;
	public GameObject GameModeSwitch;
	
	[Inject]
	public void Init(SignalBus signalBus)
	{
		_signalBus = signalBus;
		_signalBus.Subscribe<SystemSignal.GameMode.ConfigureInput.ConfigureLeft>(ShowConfigureLeft);
		_signalBus.Subscribe<SystemSignal.GameMode.ConfigureInput.ConfigureRight>(ShowConfigureRight);
		_signalBus.Subscribe<SystemSignal.GameMode.ConfigureInput.ConfigureMode>(ShowConfigureMode);
		_signalBus.Subscribe<SystemSignal.GameMode.ConfigureInput.FullConfigured>(DeactivateUI);
		ShowConfigureMode();
	}

	private void ShowConfigureMode()
	{
		ConfigureText.text = "Please press the Mode Switch Button";
		ConfigureModeUI.SetActive(true);
		ConfigureRightUI.SetActive(false);
		ConfigureLeftUI.SetActive(false);
		
	}

	private void ShowConfigureRight()
	{
		ConfigureText.text = "Please press the Right Button";
		ConfigureModeUI.SetActive(false);
		ConfigureRightUI.SetActive(true);
		ConfigureLeftUI.SetActive(false);
	}

	private void ShowConfigureLeft()
	{
		ConfigureText.text = "Please press the Left Button";
		ConfigureModeUI.SetActive(false);
		ConfigureRightUI.SetActive(false);
		ConfigureLeftUI.SetActive(true);
	}

	private void DeactivateUI()
	{
		gameObject.SetActive(false);
		GameModeSwitch.SetActive(true);
	}

}