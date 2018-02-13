using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Easy : MonoBehaviour
{
    public Transform target;
    private Transform selfLocation;
    private bool canMove;
    public float moveTimer;
    private float moveTimerCount;
    public GameObject bloodFab;
    public int moveSpeed;
    public int rotationSpeed;
    public int maxdistance;
    private Transform myTransform;
    private Animator animator;
    public string Level_Name;
    private EnemyResponse MoveInVision;

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
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Normal")|| canMove == true)
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
