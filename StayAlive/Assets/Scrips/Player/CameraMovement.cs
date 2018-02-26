using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField]
    private Transform follow;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        follow = GameObject.FindGameObjectWithTag("Player").transform;
        if (follow == null)
        {
            //notnhing
        }
        else
        {
            transform.position = new Vector3(follow.position.x + 20, follow.position.y + 30, follow.position.z - 20);
        }       
    }
}
