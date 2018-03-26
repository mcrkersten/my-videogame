using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkRotation : MonoBehaviour {
    float tiltAngle = 15f;
    public GunController axis;


    void Update()
    {
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
        transform.localEulerAngles = new Vector3(0, (axis.angle + 45), 0);

    }
}
