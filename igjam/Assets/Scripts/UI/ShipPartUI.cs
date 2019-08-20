using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
public class ShipPartUI : SelectableControl
{
	public ShipPart PrefabToInstantiate;
	private SpriteRenderer _connectedButton;
	private SignalBus _signalBus;
	private GameModel _gameModel;

	[Inject]
	void Init(SignalBus signalBus, GameModel model)
	{
		_signalBus = signalBus;
		_connectedButton = GetComponent<SpriteRenderer>();
		_gameModel = model;
	}

	public override void Select()
	{
		_connectedButton.color = Color.red;
	}

	public override void Deselect()
	{
		_connectedButton.color = Color.white;
	}

	public override void Activate()
	{
		_connectedButton.color = Color.green;
		_signalBus.Fire(new SystemSignal.Ship.PartAttached(GetObject(), _gameModel.SelectedAttachmentSlotId));
	}

	public ShipPart GetObject()
	{
		return Object.Instantiate(PrefabToInstantiate);
	}
}