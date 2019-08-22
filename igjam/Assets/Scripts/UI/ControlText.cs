using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ControlText : MonoBehaviour
{
	private Text _text;
	public string TextToShow;

	// Start is called before the first frame update
	[Inject]
	void Init(SignalBus signalBus)
	{
		_text = GetComponent<Text>();
		signalBus.Subscribe<SystemSignal.Ship.ConfigureControls>(() => _text.text = TextToShow);
		signalBus.Subscribe<SystemSignal.Ship.ConfigureSlots>(() => _text.text = "Select Door");
	}

	// Update is called once per frame
	void Update()
	{
	}
}