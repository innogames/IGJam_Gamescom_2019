using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DitherSize : MonoBehaviour
{

    private Material dithermtl;
    private float cameraSize;
    public float staticMultiplier;
    public GameObject cameraGO;

    // Start is called before the first frame update
    void Start()
    {
        dithermtl = this.GetComponent<Renderer>().material;
        cameraSize = cameraGO.GetComponent<Camera>().orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        cameraSize = cameraGO.GetComponent<Camera>().orthographicSize;
        dithermtl.SetTextureScale("_Dither", new Vector2(staticMultiplier / cameraSize, staticMultiplier / cameraSize));
    }
}
