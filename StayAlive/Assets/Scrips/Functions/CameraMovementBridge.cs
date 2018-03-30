using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementBridge : MonoBehaviour {
    [SerializeField]
    private Transform follow;
    public float StartValue = 20;

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
            transform.position = Vector3.Lerp(transform.position, 
                new Vector3 (follow.position.x, follow.position.y, 
                follow.position.z +StartValue), 0.01f);
        }       
    }

    void ViewToAnimate()
    {
        StartValue = 0;
    }
    void ResetView()
    {
        StartValue = 20;
    }
}
