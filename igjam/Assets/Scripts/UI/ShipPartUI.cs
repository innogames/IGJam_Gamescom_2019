using UnityEngine;
using Zenject;

[RequireComponent (typeof (SpriteRenderer))]
public class ShipPartUI : SelectableControl {

    public ShipPart InstantiatedShipPart;
    public ShipPart PrefabToInstantiate;
    private SpriteRenderer _shownSprite;
    private SignalBus _signalBus;
    private GameModel _gameModel;
    private DiContainer _container;

    Color deselectedColor;
    Color selectedColor;

    SFX sfx;

    [Inject]
    void Init (SignalBus signalBus, GameModel model, DiContainer container) {
        _signalBus = signalBus;
        _shownSprite = GetComponent<SpriteRenderer> ();
        _gameModel = model;
        _container = container;
        sfx = GetComponent<SFX> ();
        selectedColor = Color.white;
        deselectedColor = Camera.main.backgroundColor;
        _shownSprite.color = deselectedColor;
    }

    void Update () {
        if (InstantiatedShipPart != null) {
            InstantiatedShipPart.POS = transform.position;
        }
    }

    public override void Select () {
        _shownSprite.color = selectedColor;
        sfx.Play ();
    }

    public override void Deselect () {
        _shownSprite.color = deselectedColor;
    }

    public override void Activate () {
        _shownSprite.color = deselectedColor;
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
            InstantiatedShipPart.DisablePhysics ();
        }
    }
    public bool IsEmpty () {
        if (PrefabToInstantiate != null) return false;
        if (InstantiatedShipPart != null) return false;
        return true;
    }
}