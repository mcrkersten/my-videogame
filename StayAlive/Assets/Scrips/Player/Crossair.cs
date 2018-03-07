using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossair : MonoBehaviour {

    public LineRenderer line;
    public Ray raycast;

	// Use this for initialization
	void Start()
    {
    }

	// Update is called once per frame
	void Update () {
        line.positionCount = 2;
        line.SetPosition(0, raycast.GetPoint(1));
        line.SetPosition(1, transform.position);
	}
}
