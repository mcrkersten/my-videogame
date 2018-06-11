using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    public Enemy_Warhog warhog;
    private Animator animator;


    public void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }
    // Use this for initialization
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            warhog.health = warhog.health - 1;
            if(warhog.health > 0)
            {
                animator.SetTrigger("Hit");
            }           
            if(warhog.health <= 0)
            {
                animator.SetBool("Depleted", true);
            }
        }
    }
}
