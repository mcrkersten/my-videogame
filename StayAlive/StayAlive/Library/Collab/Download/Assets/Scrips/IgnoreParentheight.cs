using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreParentheight : IgnoreParentRotation
{
    public float YvaluePosition;
    private float XvaluePosition;
    private float ZvaluePosition;
    // Use this for initialization
    void Start () {
     //  XvaluePosition = GetComponentInParent<Transform>().position.x;
     // ZvaluePosition = GetComponentInParent<Transform>().position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0, YvaluePosition, 0);

    }
}
