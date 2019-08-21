using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Ship : MonoBehaviour {

    public SFX assignAlienSFX;
    public SFX pushOutAlienSFX;
    public SFX openHatchSFX;
    public SFX assignEmptySFX;
    public SFX moveAlienSelectionSFX;

    [HideInInspector ()] public Rigidbody2D body;

    [HideInInspector ()] public List<PartFixture> partFixtures = new List<PartFixture> ();
    [HideInInspector ()] public List<ShipPartUI> aliens = new List<ShipPartUI> ();

    // already to the ship
    private SignalBus _signalBus;

    void Awake() {
        
    }

    [Inject]
    void Init (SignalBus signalBus) {
        body = GetComponent<Rigidbody2D> ();
        partFixtures.Clear ();
       

        _signalBus = signalBus;
        _signalBus.Subscribe<SystemSignal.Ship.PartAttached> (AttachNewPart);
        _signalBus.Subscribe<SystemSignal.Ship.ControlUpdated> (UpdateSlotControl);

    }

    void Start()
    {
        foreach (PartFixture slotFixture in GetComponentsInChildren<PartFixture> ()) {
            partFixtures.Add (slotFixture);
            if (slotFixture.part != null) {
                var viewSlot = slotFixture.gameObject.GetComponent<ShipSlotView> ();
                JustAddControl (slotFixture.part, viewSlot.SlotId);
            }
        }
        foreach (ShipPartUI alien in GetComponentsInChildren<ShipPartUI> ()) {
            alien.CreateActualAlien ();
            aliens.Add (alien);
        }
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
            partFixtures[slotId].part.ShowBubble ();
        }
        JustAddControl (part, slotId);
    }

    void JustAddControl (ShipPart part, int slotId) {

        if (part != null) {
            part.DisablePhysics ();
            partFixtures[slotId].part = part;
            assignAlienSFX.Play ();
            part.ShowBubble ();
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

    public bool IsShieldedTowards (Vector2 dir) {
        print ("looking for shield");
        for (int i = 0; i < partFixtures.Count; i++) {
            if (partFixtures[i].part != null) {
                Shielder s = partFixtures[i].part.GetComponent<Shielder> ();
                if (s != null) {
                    print ("found a shielder");
                    Debug.DrawRay (partFixtures[i].transform.position, partFixtures[i].LOOKDIR, Color.red);
                    if (s.ISSHIELDING) {
                        bool indirection = Vector2.Dot (dir, partFixtures[i].LOOKDIR) > 0;
                        if (indirection) {
                            print ("actually shielding!!!");
                            Debug.DrawRay (partFixtures[i].transform.position, partFixtures[i].LOOKDIR, Color.green);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}