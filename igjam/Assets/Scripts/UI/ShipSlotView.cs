using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShipSlotView : SelectableControl {
    public int SlotId;
    public Animator AnimationControl;
    private SignalBus _signalBus;

    SFX sfx;

    [Inject]
    void Init (SignalBus signalBus) {
        _signalBus = signalBus;
        _signalBus.Subscribe<SystemSignal.Ship.PartAttached> (CheckAttachedPart);
        sfx = GetComponent<SFX> ();
    }

    private void CheckAttachedPart (SystemSignal.Ship.PartAttached signal) {
        if (signal.SlotId == SlotId) {
            AnimationControl.SetTrigger ("Hide");
        }
    }

    public override void Select () {
        AnimationControl.SetTrigger ("Select");
        sfx.Play ();
    }

    public override void Deselect () {
        AnimationControl.SetTrigger ("Deselect");
    }

    public override void Activate () {

        _signalBus.Fire (new SystemSignal.Ship.SlotSelected (SlotId));
    }
}