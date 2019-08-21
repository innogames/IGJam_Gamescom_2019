using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent (typeof (SpriteRenderer))]
public class ShipPartUI : SelectableControl {

    public ShipPart InstantiatedShipPart;
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

    void Update () {
        if (InstantiatedShipPart != null) {
            InstantiatedShipPart.POS = transform.position;
        }
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
        if (InstantiatedShipPart != null) InstantiatedShipPart = null;
        else if (PrefabToInstantiate != null) PrefabToInstantiate = null;

    }

    public ShipPart GetObject () {
        if (PrefabToInstantiate == null && InstantiatedShipPart == null) return null;
        if (InstantiatedShipPart != null) return InstantiatedShipPart;
        return _container.InstantiatePrefabForComponent<ShipPart> (PrefabToInstantiate);
    }

    public void CreateActualAlien () {
        if (PrefabToInstantiate != null) {
            InstantiatedShipPart = _container.InstantiatePrefabForComponent<ShipPart> (PrefabToInstantiate);
            PrefabToInstantiate = null;
            InstantiatedShipPart.DisablePhysics(); 
        }
    }
    public bool IsEmpty () {
        if (PrefabToInstantiate != null) return false;
        if (InstantiatedShipPart != null) return false;
        return true;
    }
}