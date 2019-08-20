using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class ShipPartUI : SelectableControl
{
	public ShipPart PrefabToInstantiate;
	private Button _connectedButton;
	private SignalBus _signalBus;
	private GameModel _gameModel;

	[Inject]
	void Init(SignalBus signalBus, GameModel model)
	{
		_signalBus = signalBus;
		_connectedButton = GetComponent<Button>();
		_gameModel = model;
	}

	public override void Select()
	{
		_connectedButton.image.color = Color.red;
	}

	public override void Deselect()
	{
		_connectedButton.image.color = Color.white;
	}

	public override void Activate()
	{
		_connectedButton.image.color = Color.green;
		_signalBus.Fire(new SystemSignal.Ship.PartAttached(GetObject(), _gameModel.SelectedAttachmentSlotId));
	}

	public ShipPart GetObject()
	{
		return Object.Instantiate(PrefabToInstantiate);
	}
}