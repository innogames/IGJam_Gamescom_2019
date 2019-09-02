using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShipPart : MonoBehaviour, IShipControl {
    public Vector2 POS {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public float ROT {
        get { return transform.rotation.eulerAngles.z; }
        set { transform.rotation = Uhh.Rotation (Uhh.VectorFromAngle (value)); }
    }

    public Vector2 SCALE {
        get { return transform.localScale; }
        set { transform.localScale = value; }
    }

    public Vector2 LOOKDIR {
        get { return -Uhh.VectorFromAngle (ROT); }
    }

    public Ship ship;
    protected PartFixture fixture;
    public Animator SpeechBubble;

    private SignalBus _signalBus;

    [HideInInspector ()] public Rigidbody2D body;
    CircleCollider2D col;

    public string button = "A";
    public AlienGenerator Generator;

    public AlienVoice voice;
    public AlienVoice VOICE { get { if (voice == null) voice = VoiceContainer.GetVoiceSetup (); return voice; } }

    [Inject]
    void Init (SignalBus signalBus, GameModel model) {
        body = GetComponent<Rigidbody2D> ();
        col = GetComponent<CircleCollider2D> ();
        _signalBus = signalBus;
        _signalBus.Subscribe<SystemSignal.GameMode.FlyMode.Activate> (EnableObject);
        _signalBus.Subscribe<SystemSignal.GameMode.FlyMode.Deactivate> (DisableObject);
        if (model.ActiveState != typeof (FlyState)) {
            enabled = false;
        }

        foreach (EffectBase e in GetComponentsInChildren<EffectBase> ()) {
            effects.Add (e);
        }

    }

    private void EnableObject () {
        enabled = true;
    }

    private void DisableObject () {
        enabled = false;
    }

    private void OnDestroy () {
        _signalBus.TryUnsubscribe<SystemSignal.GameMode.FlyMode.Activate> (EnableObject);
        _signalBus.TryUnsubscribe<SystemSignal.GameMode.FlyMode.Deactivate> (DisableObject);
    }

    void Update () {
        Draw ();

        if (ship == null) return;

        // debug stuff: 
        if (Input.GetButton (button)) Activate ();
        else Deactivate ();

        if (!CANBEPICKEDUP) pickupcooldown -= Time.deltaTime;
    }

    public bool CANBEPICKEDUP
    {
        get { return true; }
    }
    float pickupcooldown;

    public virtual void EnablePhysics () {
        body.simulated = true;
        col.enabled = true;
        ship = null;
        pickupcooldown = 1.5f;
    }

    public virtual void DisablePhysics () {
        body.simulated = false;
        col.enabled = false;
    }

    public virtual void Draw () { }

    bool activated;
    bool selected;

    public virtual void Activate () {
        activated = true;
    }

    public void Deactivate () {
        activated = false;
    }

    public void Select () {
        selected = true;
    }

    public void TalkWithShip (Ship ship, PartFixture fixture) {
        this.ship = ship;
        this.fixture = fixture;

        Vector2 pos = fixture.transform.position;
        pos -= LOOKDIR * .5f;
        Vector2 offset = Vector2.zero;

        if (activated) {
            offset += LOOKDIR * .25f;
        }

        POS = Vector2.Lerp (POS, pos + offset, .35f);
        ROT = Mathf.LerpAngle (ROT, fixture.transform.eulerAngles.z, .35f);
        selected = false;
    }

    public virtual void AssignButton (string newControlName) {

        button = newControlName;
    }

    void OnCollisionEnter2D (Collision2D col) {
        // Ship s = col.collider.gameObject.GetComponent<Ship> ();
        // if (s != null) {
        // GET PICKED BACK UP AGAIN !! 
        // Destroy (gameObject);
        // VOICE.Say (voice.pickUp);
        // s.PickUpPartFromSpace (this);       
        // }
    }

    public void ShowBubble () {
        SpeechBubble.SetTrigger ("Show");
        Generator.GenerateAlien ();

    }

    List<EffectBase> effects = new List<EffectBase> ();
    protected void ShowEffects () {
        foreach (EffectBase e in effects) {
            e.Show ();
        }
    }
}