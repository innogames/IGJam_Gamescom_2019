using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraBrain : MonoBehaviour {

    public float buildzoomlevel = 10;
    public float gamezoomlevel = 35;

    // i'm sorry for creating static variables. 
    // i just couldn't deal 
    public static bool zoomedIn = false;
    public static Vector2 shipposition;

    Vector2 startpos;

    Camera cam;

    SignalBus _signalBus;

    [Inject]
    void Init (SignalBus signalBus) {
        cam = GetComponent<Camera>();
        startpos = transform.position;
        _signalBus = signalBus;
        _signalBus.Subscribe<SystemSignal.GameMode.ConfigureShip.Activate> (ActivateUI);
        _signalBus.Subscribe<SystemSignal.GameMode.ConfigureControls.Activate> (ActivateUI);
        _signalBus.Subscribe<SystemSignal.GameMode.ConfigureShip.Deactivate> (DeactivateUI);
        _signalBus.Subscribe<SystemSignal.GameMode.ConfigureControls.Deactivate> (DeactivateUI);

    }

    void DeactivateUI () { zoomedIn = false; }
    void ActivateUI () { zoomedIn = true; shipposition = FindObjectOfType<Ship> ().transform.position; }

    void Update () {

        Vector2 targetpos = startpos;
        float targetzoom = gamezoomlevel;

        if (zoomedIn) {
            targetzoom = buildzoomlevel;
            targetpos = shipposition;
        }

        cam.orthographicSize = Mathf.Lerp (cam.orthographicSize, targetzoom, .1f);

        transform.position = Vector3.Lerp (transform.position, new Vector3 (targetpos.x, targetpos.y, -10f), .1f);
    }
}