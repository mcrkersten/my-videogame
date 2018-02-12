using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    private Transform follow;

	// Use this for initialization
	void Start () {
        follow = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, follow.position.y + 30, follow.position.z - 20);
	}
}
