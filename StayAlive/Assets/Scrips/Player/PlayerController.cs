    using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Movespeed = .1f;
    public Collider ignore;
    public Collider portal;
    private bool canMove = true;
    private bool targetable = true;
    private float timer1;
    private float timer2;
    public PlayerStats PS;
    private Animator Anim;

    // Use this for initialization
    void Start()
    {
        PS = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
        portal = GameObject.FindGameObjectWithTag("NextLevel").GetComponent<Collider>();
        Anim = gameObject.GetComponent<Animator>();
        timer1 = 0;
        timer2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timers();
        Physics.IgnoreCollision(ignore,portal);
    }

    void Movement()
    {
        transform.Translate(new Vector3(-1,0,1) * Input.GetAxis("Vertical") * Movespeed);
        transform.Translate(new Vector3(1, 0, 1) * Input.GetAxis("Horizontal") * Movespeed);
    }

    void timers()
    {
        if (canMove == true)
        {
            Movement();
        }
        else
        {        
            timer1 = timer1 + Time.deltaTime;
            if (timer1 > .4)
            {
                canMove = true;
                timer1 = 0;
            }
        }

        if (targetable == false)
        {
            timer2 = timer2 + Time.deltaTime;
            if (timer2 > 1.5)
            {
                targetable = true;
                Anim.SetBool("Hit", false);
                timer2 = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (other.tag == "Enemy")
        {
            PS.health = PS.health - other.GetComponent<DamageAmount>().DamageToPlayer;        
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Enemy" && targetable == true)
        {
            canMove = false;
            targetable = false;
            Anim.SetBool("Hit", true);
            Vector3 dir = c.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * c.gameObject.GetComponentInChildren<DamageAmount>().force);
            print(c.gameObject.GetComponentInChildren<DamageAmount>().force);        
        }
        else if (c.gameObject.tag == "Enemy" && targetable == false)
        {
            Physics.IgnoreCollision(c.collider, this.GetComponent<Collider>());
        }
    }

}