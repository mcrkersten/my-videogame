using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfChild : MonoBehaviour {
    public float Timer;
    private float Timed;
    ParticleSystem system;
    ParticleSystem.EmissionModule particles;
	// Use this for initialization
	void Start () {
        system = GetComponent<ParticleSystem>();
        particles = system.emission;
        Timed = Timer;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.parent == null)
        {
            particles.rateOverTime = 0;
            Timed = Timed - Time.deltaTime;
            if(Timed < 0)
            {
                Destroy(gameObject);
            }
        }
	}
}
