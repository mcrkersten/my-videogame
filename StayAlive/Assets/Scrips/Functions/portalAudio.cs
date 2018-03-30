using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class portalAudio : MonoBehaviour {

    public AudioSource Source;
    public AudioClip Audio;
	
	// Update is called once per frame
	void PlaySound () {
        Source.PlayOneShot(Audio);
    }
}
