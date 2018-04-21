using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageAmount))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(EnemyResponse))]

public class Enemy_Gun : MonoBehaviour
{   
    private Transform myTransform;
    private Animator animator;
    private Transform selfLocation;
    private float fireTimer;

    [Header("Movement settings")]
    [SerializeField, Tooltip("Set movementspeed")]
    public float moveSpeed;
    [SerializeField, Tooltip("Set rotation speed speed")]
    public float rotationSpeed;

    [Header("Functions")]
    public EnemyResponse MoveInVision;
    public Animator Detection;
    public GameObject bloodFab;

    [Header("Target settings")]
    [SerializeField, Tooltip("Self updating to player")]
    public GameObject go;

    [Header("Gun assets")]
    public Transform bulletSpawn;
    public float fireRate;
    public int bulletSpeed;
    public GameObject EnemybulletPrefab;

    [Header("Spawn friends")]
    public SpawnManager spawnmanager;

    [Header("Audio settings")]
    public AudioSource wahSource;
    public AudioClip wahAudio;
    private bool hasPlayed = false;

    void Awake()
    {
        myTransform = transform;
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
            return;
        }         
        else if (MoveInVision.moveAss == true)
        {
            PlayAudio();
            animator.SetBool("HasGun", true);
            Debug.DrawLine(go.transform.position, myTransform.position, Color.red);
            moveToTarget();
            fireTimer = fireTimer - Time.deltaTime;

            if (fireTimer < 0 && animator.GetCurrentAnimatorStateInfo(0).IsName("Ready"))
            {
                animator.SetTrigger("Fire");
                fireTimer = fireRate;
            }
            if (spawnmanager == null)
            {
                return;
            }
            else
            {
                spawnmanager.spawnEnemies = true;
            }
        }
    }
    private void moveToTarget()
    {
        //Move towards target
        Detection.SetBool("Detected", true);
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(go.transform.position - myTransform.position), rotationSpeed * Time.deltaTime);
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


    void AnimationFire()
    {
        Fire();
    }

    void PlayAudio()
    {
        if (hasPlayed == false)
        {
            wahSource.PlayOneShot(wahAudio);
            hasPlayed = true;
        }
    }


    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            var blood = (GameObject)Instantiate(
                bloodFab,
                new Vector3(selfLocation.position.x, selfLocation.position.y + 1, selfLocation.position.z),
                selfLocation.rotation);
            blood.transform.parent = null;
            Destroy(gameObject);
        }
    }
}