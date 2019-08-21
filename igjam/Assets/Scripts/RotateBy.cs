using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBy : MonoBehaviour
{

    public Vector3 rotateAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localEulerAngles = this.transform.localEulerAngles + (rotateAmount * Time.deltaTime);
    }
}
