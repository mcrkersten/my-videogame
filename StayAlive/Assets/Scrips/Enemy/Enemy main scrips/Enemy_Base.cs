using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Base : MonoBehaviour
{
    private Transform target;
    private Transform selfLocation;
    private float moveTimerCount;
    private Animator spawnAnimation;
    private Transform myTransform;
    private EnemyResponse MoveInVision;

    [Header("Start settings")]
    public bool canMove;
    [SerializeField, Tooltip("If true, enemy can walk")]
    public float moveTimer;
    [SerializeField, Tooltip("Time the enemy will wait after spawning")]

    [Header("particles | StatusAnimations")]
    public GameObject bloodFab;
    public Animator Detection;

    [Header("Movement settings")]
    [SerializeField, Tooltip("Set movementspeed")]
    public int moveSpeed;
    [SerializeField, Tooltip("Set acceleration speed")]
    public float acceleration;
    private float actualMovespeed;
    [SerializeField, Tooltip("Set rotationspeed")]
    public int rotationSpeed;
    [SerializeField, Tooltip("Max distance of response to player")]
    public int maxdistance;



    void Awake()
    {
        myTransform = transform;
    }

    // Use this for initialization
    void Start () {
        MoveInVision = GetComponent<EnemyResponse>();
        selfLocation = GetComponent<Transform>();
        spawnAnimation = GetComponent<Animator>();
        canMove = false;
        moveTimerCount = moveTimer;
    }

    // Update is called once per frame
    void Update()
    {

        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (go == null)
        {
            //NOTHING
        }
        else
        {
            target = go.transform;
            moveTimerCount = moveTimerCount - Time.deltaTime;
            if (moveTimerCount < 0)
            {
                canMove = true;
            }
            if (spawnAnimation.GetCurrentAnimatorStateInfo(0).IsName("Normal") || canMove == true)
            {
                Debug.DrawLine(target.position, myTransform.position, Color.red);

                myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

                if (Vector3.Distance(target.position, myTransform.position) > maxdistance)
                {
                    //Move towards target
                    if (actualMovespeed < moveSpeed)
                    {
                        actualMovespeed = actualMovespeed + acceleration;
                    }
                    Detection.SetBool("Detected", true);
                    myTransform.position += myTransform.forward * actualMovespeed * Time.deltaTime;
                }
            }
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Bullet")
        {
            var blood = (GameObject)Instantiate(
                bloodFab,
                selfLocation.position,
                selfLocation.rotation);
            blood.transform.parent = null;//GameObject.Find(Level_Name).transform;
            Destroy(gameObject);
        }

        if(coll.gameObject.tag == "Player")
        {
            Vector3 dir = coll.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * GetComponent<DamageAmount>().force);
        }
    }
}
