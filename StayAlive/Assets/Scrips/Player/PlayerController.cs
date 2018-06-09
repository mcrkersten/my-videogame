using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerStats PS;
    private bool canMove = true;
    public bool cantMoveDialog = false;
    private bool targetable = true;
    private float timer1;
    private float timer2;

    public SceneLoader sceneLoader;

    [Header("Start settings")]
    public float Movespeed;

    [Header("Collisions to ignore")]
    public Collider ignore;
    public Collider portal;

    [Header("Animation on hit")]
    public Animator hands;
    public Animator body;

    private string levelName;
    private string portalName;
    [SerializeField]
    private int levelLength;


    // Use this for initialization
    void Awake()
    {       
        PS = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
        levelLength = PS.levelLength;
        timer1 = 0;
        timer2 = 0;
        if (GameObject.FindGameObjectWithTag("SceneLoader") != null)
        {
            sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        }
        if (GameObject.FindGameObjectWithTag("NextLevel") != null)
        {
            portal = GameObject.FindGameObjectWithTag("NextLevel").GetComponent<Collider>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (canMove == true && cantMoveDialog == false)
        {
            Movement();
        }
        else if(canMove == false)
        {
            timer1 = timer1 + Time.deltaTime;
            if (timer1 > .6)
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
                hands.SetBool("Hit", false);
                body.SetBool("Hit", false);
                timer2 = 0;
                //RESET ENEMY COLLISION
                Physics.IgnoreLayerCollision(9, 10, false);
            }
        }if (portal == null)
        {
            return;
        }
        else
        {
            Physics.IgnoreCollision(ignore, portal);
        }      
    }



    void Movement()
    {
        transform.Translate(new Vector3(-Movespeed, 0, Movespeed) * Input.GetAxis("Vertical"));
        transform.Translate(new Vector3(Movespeed, 0, Movespeed) * Input.GetAxis("Horizontal"));
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "NextLevel")
        {
            if(PS.levelLength > PS.levelNumber)
            {
                SceneManager.LoadScene(PS.dungeonName + PS.levelNumber);
                PS.levelNumber++;
            }
            else
            {
                PS.levelNumber = 0;
                PS.liberation[PS.gateNumber] = true;
                sceneLoader.loadSceneGO = true;
            }
            
        }
        
        if(trigger.tag == "Gate")
        {
            PS.levelNumber = 0;
            PS.gateNumber = trigger.gameObject.GetComponent<LevelSelector>().GateNumber;
            PS.dungeonName = trigger.gameObject.GetComponent<LevelSelector>().dungeonName;
            PS.levelLength = trigger.gameObject.GetComponent<LevelSelector>().levelLength;
            sceneLoader.scene = trigger.gameObject.GetComponent<LevelSelector>().levelName;
            PS.levelName = sceneLoader.scene;
            sceneLoader.loadSceneGO = true;          
        }

        if (trigger.tag == "healthItem")
        {
            PS.health = PS.health + 1;
            Destroy(trigger.gameObject);
        }

    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Enemy" || c.gameObject.tag == "EnemyBullet" && targetable == true )
        {         
            PS.health = PS.health - c.gameObject.GetComponent<DamageAmount>().DamageToPlayer;
            canMove = false;
            targetable = false;
            
            Physics.IgnoreLayerCollision(9, 10, true);

            Vector3 dir = c.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * c.gameObject.GetComponent<DamageAmount>().force);

            print(c.gameObject.GetComponent<DamageAmount>().force);
            hands.SetBool("Hit", true);
            body.SetBool("Hit", true);
        }
    }
}