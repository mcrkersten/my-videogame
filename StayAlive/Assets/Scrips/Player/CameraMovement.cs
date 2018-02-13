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
        transform.position = new Vector3(follow.position.x + 20, follow.position.y + 30, follow.position.z - 20);
	}
}
