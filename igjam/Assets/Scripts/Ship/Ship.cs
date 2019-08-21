using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Ship : MonoBehaviour {
    [HideInInspector ()] public Rigidbody2D body;

    [HideInInspector ()] public List<PartFixture> partFixtures = new List<PartFixture> ();

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
        }

        if (part != null) {
            part.ConnectToShip ();
            partFixtures[slotId].part = part;
        } else {
        
        }
    }

    public void RemovePart (int slotid) {
        if (partFixtures[slotid].part != null) {
            partFixtures[slotid].Pop ();
        }
    }

    public void SelectNextControl () { }
}