using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Warhog : MonoBehaviour {
    public float rotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, rotationSpeed, 0));
    }
}
