using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSelf : MonoBehaviour {
    public float TimeWait = 4;
    private float TimeWaited;
    // Use this for initialization
    void Start () {
	TimeWaited = TimeWait;
	}
	
	// Update is called once per frame
	void Update () {
        TimeWaited = TimeWaited - Time.deltaTime;
        if (TimeWaited < 0)
        {
            Destroy(gameObject);
        }
	}
}
