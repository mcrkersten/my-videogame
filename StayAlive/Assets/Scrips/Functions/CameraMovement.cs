using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField]
    private Transform follow;
    public float ExtraOnX;
    public float ExtraOnY;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        follow = GameObject.FindGameObjectWithTag("Player").transform;
        if (follow == null)
        {
            return;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, 
                new Vector3 (follow.position.x + ExtraOnX, follow.position.y + ExtraOnY, 
                follow.position.z), 0.01f);
        }       
    }
}
