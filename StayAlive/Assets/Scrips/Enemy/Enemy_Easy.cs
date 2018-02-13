using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Easy : MonoBehaviour
{
    private Transform target;
    private Transform selfLocation;
    private float moveTimerCount;
    private Animator animator;
    private Transform myTransform;
    private EnemyResponse MoveInVision;

    [Header("Start settings")]
    public bool canMove;
    [SerializeField, Tooltip("If true, enemy can walk")]
    public float moveTimer;
    [SerializeField, Tooltip("Time the enemy will wait after spawning")]

    [Header("Level and particles")]
    public GameObject bloodFab;
    public string Level_Name;

    [Header("Movement settings")]
    [SerializeField, Tooltip("Set movementspeed")]
    public int moveSpeed;
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
        animator = GetComponent<Animator>();
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        canMove = false;
        moveTimerCount = moveTimer;
    }

    // Update is called once per frame
    void Update()
    {
        moveTimerCount = moveTimerCount - Time.deltaTime;
        if(moveTimerCount < 0)
        {
            canMove = true;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Normal") && canMove == true)
        {
            Debug.DrawLine(target.position, myTransform.position, Color.red);

            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

            if (Vector3.Distance(target.position, myTransform.position) > maxdistance)
            {
                //Move towards target
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter(Collision coll)
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
    }
}
