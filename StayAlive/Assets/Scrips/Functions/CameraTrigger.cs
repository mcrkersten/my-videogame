using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

    public Animator cameraObject;

    private void OnTriggerEnter(Collider trig)
    {
        if (trig.gameObject.tag == "CameraTrigger")
        {
            cameraObject.SetTrigger("Continue");
            print("Yas you hit ze trigger");
            Destroy(trig);
        }
    }
}
