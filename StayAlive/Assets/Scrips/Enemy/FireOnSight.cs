using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnSight : MonoBehaviour
{
    public Transform target;
    private Transform selfLocation;
    public GameObject bloodFab;
    public float moveSpeed;
    public float rotationSpeed;
    private Transform myTransform;
    public Animator animator;
    public EnemyResponse MoveInVision;
    private Transform tempTransform;
    public Animator Detection;
    public SpawnManager spawnmanager;
    public GameObject go;

    [Header("Gun assets")]
    public Transform bulletSpawn;
    private float fireTimer;
    public float fireRate;
    public int bulletSpeed;
    public GameObject EnemybulletPrefab;

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
        MoveInVision = GetComponent<EnemyResponse>();
    }

    // Update is called once per frame
    void Update()
    {
        go = GameObject.FindGameObjectWithTag("Player");
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
                    moveToTarget();

                    fireTimer = fireTimer - Time.deltaTime;
                    if (fireTimer < 0)
                    {
                        Fire();
                        fireTimer = fireRate;
                    }

                    if (spawnmanager == null)
                    {
                        //NOTHING
                    }
                    else
                    {
                        spawnmanager.spawnEnemies = true;
                    }

                }
            }
        }
    }
    private void moveToTarget()
    {
        //Move towards target
        Detection.SetBool("Detected", true);
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

        tempTransform.position = myTransform.position;
        tempTransform.rotation = myTransform.rotation;
    }

    void Fire()
    {
        var bulletEnemy = (GameObject)Instantiate(
    EnemybulletPrefab,
    bulletSpawn.position,
    bulletSpawn.rotation);

        // Add velocity to the bullet
        bulletEnemy.GetComponent<Rigidbody>().velocity = bulletEnemy.transform.forward * bulletSpeed;
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