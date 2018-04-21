using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DamageAmount))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(EnemyResponse))]

public class Enemy_Warhog : MonoBehaviour {

    private Transform myTransform;
    private Transform selfLocation;
    //Self updating to player
    private GameObject go;
    private Vector3 location;

    [Header("Movement settings")]
    [SerializeField, Tooltip("Set movementspeed")]
    public float moveSpeed;
    [SerializeField, Tooltip("Set rotation speed speed")]
    public float rotationSpeed;

    [Header("Functions")]
    public EnemyResponse MoveInVision;
    public Animator Detection;
    public GameObject bloodFab;

    [Header("Warhog Objects")]
    public int ListSize;
    public List<GameObject> bullets = new List<GameObject>();
    public GameObject bulletHolder;
    public GameObject mainBulletHolder;
    public float bulletRotation;

    [Header("Spawn friends")]
    public SpawnManager spawnmanager;

    [Header("Audio settings")]
    public AudioSource wahSource;
    public AudioClip wahAudio;
    private bool hasPlayed = false;

    void Awake()
    {
        myTransform = transform;

        for (int i = 0; i < ListSize; i++)
        {
            bullets.Add(Instantiate(bulletHolder,
                mainBulletHolder.transform.position,
                mainBulletHolder.transform.rotation,
                mainBulletHolder.transform));
            float toRotate = 360 / ListSize;
            rotateBulletHolders(toRotate);
        }
    }

    // Use this for initialization
    void Start()
    {
        selfLocation = GetComponent<Transform>();
        MoveInVision = GetComponent<EnemyResponse>();
    }

    // Update is called once per frame
    void Update()
    {
        rotateBulletHolders(bulletRotation);
        go = GameObject.FindGameObjectWithTag("Player");
        if (go == null)
        {
            return;
        }
        else if (MoveInVision.moveAss == true)
        {
            PlayAudio();
            Debug.DrawLine(go.transform.position, myTransform.position, Color.red);
            moveToTarget();
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

    void PlayAudio()
    {
        if (hasPlayed == false)
        {
            wahSource.PlayOneShot(wahAudio);
            hasPlayed = true;
        }
    }

    private void moveToTarget()
    {
        //Move towards target
        Detection.SetBool("Detected", true);
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(go.transform.position - myTransform.position), rotationSpeed * Time.deltaTime);
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

    private void rotateBulletHolders(float rotation)
    {
        foreach(GameObject item in bullets)
        {
            item.transform.eulerAngles = new Vector3(0, item.transform.eulerAngles.y + rotation, 0);
        }
    }
}