using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddControlDummy : MonoBehaviour {
    public Ship ship;

    public GameObject thrusterPrefab;

    void Start () {

    }

    void Update () {
        if (Input.GetKeyDown (KeyCode.V)) AddPart (0);
        if (Input.GetKeyDown (KeyCode.B)) AddPart (1);
        if (Input.GetKeyDown (KeyCode.N)) AddPart (2);
        if (Input.GetKeyDown (KeyCode.M)) AddPart (3);
    }

    void AddPart (int id) {
        GameObject g = Instantiate (thrusterPrefab, ship.partFixtures[id].position, Quaternion.identity);

        ship.AddControl (g.GetComponent<ShipPart> (), id);
    }
}