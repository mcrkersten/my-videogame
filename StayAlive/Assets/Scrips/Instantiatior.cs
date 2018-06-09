using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiatior : MonoBehaviour {
    public GameObject instantGameObject;

	// Use this for initialization
	void Start () {
        Instantiate(instantGameObject, this.transform.position, this.transform.rotation, null);
	}
}
