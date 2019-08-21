using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Ship : MonoBehaviour {

    public SFX assignAlienSFX;
    public SFX pushOutAlienSFX;

    [HideInInspector ()] public Rigidbody2D body;

    [HideInInspector ()] public List<PartFixture> partFixtures = new List<PartFixture> ();
    [HideInInspector ()] public List<ShipPartUI> aliens = new List<ShipPartUI> ();

    // already to the ship
    private SignalBus _signalBus;

    [Inject]
    void Init (SignalBus signalBus) {
        body = GetComponent<Rigidbody2D> ();
        partFixtures.Clear ();
        foreach (PartFixture slotFixture in GetComponentsInChildren<PartFixture> ()) {
            partFixtures.Add (slotFixture);
            if (slotFixture.part != null) {
                var viewSlot = slotFixture.gameObject.GetComponent<ShipSlotView> ();
                AddControl (slotFixture.part, viewSlot.SlotId);
            }
        }
        foreach (ShipPartUI alien in GetComponentsInChildren<ShipPartUI> ()) {
            alien.CreateActualAlien ();
            aliens.Add (alien);
        }

        _signalBus = signalBus;
        _signalBus.Subscribe<SystemSignal.Ship.PartAttached> (AttachNewPart);
        _signalBus.Subscribe<SystemSignal.Ship.ControlUpdated> (UpdateSlotControl);

    }

    private void UpdateSlotControl (SystemSignal.Ship.ControlUpdated signal) {
        var part = partFixtures[signal.SlotId].part;
        if (part != null) {
            part.AssignButton (signal.NewControlName);
        }
    }

    private void AttachNewPart (SystemSignal.Ship.PartAttached signal) {
        AddControl (signal.NewPart, signal.SlotId);
    }

    public void AddControl (ShipPart part, int slotId) {
        // part.body = body;
        // parts.Add (part);
        // parts[slotId].add(part); 

        if (partFixtures[slotId].part != null) {
            // SHOULD POP OUT THIS ALIEN YO !! 
            // Destroy(partFixtures[slotId].part.gameObject); 
            partFixtures[slotId].Pop ();
            pushOutAlienSFX.Play ();
        }

        if (part != null) {
            part.DisablePhysics ();
            partFixtures[slotId].part = part;
            assignAlienSFX.Play ();
        } else {

        }
    }

    public void RemovePart (int slotid) {
        if (partFixtures[slotid].part != null) {
            partFixtures[slotid].Pop ();
        }
    }

    public void SelectNextControl () { }

    public void PickUpPartFromSpace (ShipPart part) {
        // add part to aliens list ... 
        for (int i = 0; i < aliens.Count; i++) {
            if (aliens[i].IsEmpty ()) {
                aliens[i].InstantiatedShipPart = part;
                part.DisablePhysics ();
                return;
            }
        }
    }
}