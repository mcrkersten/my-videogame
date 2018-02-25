using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Easy_Stealth : MonoBehaviour
{
    public Transform target;
    private Transform selfLocation;
    public GameObject bloodFab;
    public float moveSpeed;
    public float rotationSpeed;
    private Transform myTransform;
    private Animator animator;
    public string Level_Name;
    private EnemyResponse MoveInVision;
    private Transform tempTransform;
    public Animator Detection;
    public SpawnManager spawnmanager;

    void Awake()
    {
        myTransform = transform;
        tempTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        selfLocation = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        MoveInVision = GetComponent<EnemyResponse>();
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
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Normal"))
            {
                Debug.DrawLine(target.position, myTransform.position, Color.red);

                if (MoveInVision.moveAss == true)
                {
                    //Move towards target
                    Detection.SetBool("Detected", true);
                    myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
                    myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

                    tempTransform.position = myTransform.position;
                    tempTransform.rotation = myTransform.rotation;
                    if(spawnmanager == null)
                    {
                        //NITHING
                    }
                    else
                    {
                        spawnmanager.spawnEnemies = true;
                    }

                }
            }
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Bullet")
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