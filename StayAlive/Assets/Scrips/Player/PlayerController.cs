    using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStats PS;
    private bool canMove = true;
    private bool targetable = true;
    private Animator Anim;
    private float timer1;
    private float timer2;

    [Header("Start settings")]
    public float Movespeed = .1f;

    [Header("Collisions to ignore")]
    public Collider ignore;
    public Collider portal;

    
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
                //RESET ENEMY COLLISION
                Physics.IgnoreLayerCollision(9, 10, false);
            }
        }
    }

    void Movement()
    {
        transform.Translate(new Vector3(-Movespeed, 0, Movespeed) * Input.GetAxis("Vertical"));
        transform.Translate(new Vector3(Movespeed, 0, Movespeed) * Input.GetAxis("Horizontal"));
    }

    void OnTriggerEnter(Collider portal)
    {
        if (portal.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Enemy" || c.gameObject.tag == "EnemyBullet" && targetable == true )
        {
            PS.health = PS.health - c.gameObject.GetComponent<DamageAmount>().DamageToPlayer;
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
            //IGNORE ENEMY COLLISION
            Physics.IgnoreLayerCollision(9, 10, true);
        }
    }

}