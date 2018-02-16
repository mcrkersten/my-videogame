using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskAnimate : MonoBehaviour {

    private Animator animator;
    private Enemy_Easy script;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        script = GetComponentInParent<Enemy_Easy>();
	}
	
	// Update is called once per frame
	void Update () {
       if (script.canMove == true)
        {
            animator.SetBool("CanAnimate", true);
        }
	}
}
