using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent (typeof (SpriteRenderer))]
public class ShipPartUI : SelectableControl {
    public ShipPart PrefabToInstantiate;
    private SpriteRenderer _connectedButton;
    private SignalBus _signalBus;
    private GameModel _gameModel;
    private DiContainer _container;

    [Inject]
    void Init (SignalBus signalBus, GameModel model, DiContainer container) {
        _signalBus = signalBus;
        _connectedButton = GetComponent<SpriteRenderer> ();
        _gameModel = model;
        _container = container;
    }

    public override void Select () {
        _connectedButton.color = Color.red;
    }

    public override void Deselect () {
        _connectedButton.color = Color.white;
    }

    public override void Activate () {
        _connectedButton.color = Color.green;
        _signalBus.Fire (new SystemSignal.Ship.PartAttached (GetObject (), _gameModel.SelectedAttachmentSlotId));
    }

    public ShipPart GetObject () {
        if (PrefabToInstantiate == null) return null;
        return _container.InstantiatePrefabForComponent<ShipPart> (PrefabToInstantiate);
    }
}