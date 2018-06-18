using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    private float fireTimer;
    private bool gun1 = false; //left
    private bool gun2 = true; // right
    private PlayerStats PS;
    public float angle;

    [Header("Bullet prefab")]
    public GameObject bulletPrefab;

    [Header("Guns")]
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public Animator shootAni;

    [Header("Fire settings")]
    public int bulletSpeed;
    public float bulletTime;
    public float fireRate;

    [Header("Target lines")]
    public LineRenderer LeftLaser;
    public LineRenderer RightLaser;

    [Header("Audio settings")]
    public AudioSource gunSource;
    public AudioClip gunAudio;

    [Header("Ultimate Settings")]
    public bool UltimateActive;
    public List<GameObject> bulletSpawn = new List<GameObject>();

    // Update is called once per frame
    void Start()
    {
        PS = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
        LeftLaser.enabled = false;
        RightLaser.enabled = true;
        fireTimer = 0;
    }

    void FixedUpdate () {

        if(PS.mana < 5)
        {
            UltimateActive = false;
        }
        else
        {
            UltimateActive = true;
        }
        RotateController();
        fireTimer = fireTimer + Time.deltaTime;
        if (Input.GetAxis("joystick button 10") > 0 || Input.GetKey("space"))
        {
            if (fireTimer > fireRate)
            {
                if (gun1 == true && gun2 == false && PS.mana > 0)
                {
                    Fire1();
                    gunSource.pitch = (Random.Range(1.3f, .8f));
                    gunSource.PlayOneShot(gunAudio);
                    PS.mana = PS.mana - 1;
                    PS.timer = PS.ManaRegenPerSecond;
                    shootAni.SetBool("RightShoot", true);
                    gun1 = false;
                    LeftLaser.enabled = false;
                    RightLaser.enabled = true;
                    gun2 = true;
                }
                else if (gun2 == true && gun1 == false && PS.mana > 0)
                {
                    Fire2();
                    gunSource.pitch = (Random.Range(1.3f, .8f));
                    gunSource.PlayOneShot(gunAudio);
                    PS.mana = PS.mana - 1;
                    PS.timer = PS.ManaRegenPerSecond;
                    shootAni.SetBool("LeftShoot", true);                   
                    gun2 = false;
                    LeftLaser.enabled = true;
                    RightLaser.enabled = false;
                    gun1 = true;
                }
                fireTimer = 0;
            }
        }
        if(Input.GetButtonDown("bumper") && UltimateActive == true)
        {
            foreach(GameObject position in bulletSpawn)
            {
                FireSpeciale1(position);
            }
        }
    }

    void RotateController() {
        float x = Input.GetAxis("R_Horizontal");
        float y = Input.GetAxis("R_Vertical");

        //guns.transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, -y) * Mathf.Rad2Deg - 45, guns.transform.eulerAngles.z);

        if (x != 0.05f && y != 0.05f)
        {
            angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            gameObject.transform.eulerAngles = new Vector3 (0,angle + 45,0);
        }
    }

    void Fire1()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn1.position,
            bulletSpawn1.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, bulletTime);
    }

    void Fire2()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn2.position,
            bulletSpawn2.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, bulletTime);
    }

    void FireSpeciale1(GameObject spawnPos)
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            spawnPos.transform.position,
            spawnPos.transform.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        Destroy(bullet, bulletTime);
    }

    private void ShootLeftDone()
    {
        shootAni.SetBool("LeftShoot", false);
    }

    private void ShootRightDone()
    {
        shootAni.SetBool("RightShoot", false);
    }

}
