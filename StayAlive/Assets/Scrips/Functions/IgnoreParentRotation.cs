using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreParentRotation : MonoBehaviour {

    [Header("Rotation values")]
    [SerializeField, Tooltip("Rotate objects undependent of their parent object")]
    public float Xvalue;
    public float Yvalue;
    public float Zvalue;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
        transform.Rotate(Xvalue, Yvalue, Zvalue);
    }
}
