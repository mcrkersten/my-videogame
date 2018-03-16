using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    public GameObject guns;
    public GameObject bulletPrefab;
    public Transform bulletSpawn1;
    public Transform bulletSpawn2;
    public int bulletSpeed;
    public float bulletTime;
    private float fireTimer;
    private bool gun1 = false; //left
    private bool gun2 = true; // right
    public float fireRate;
    public PlayerStats PS;

    public LineRenderer LeftLaser;
    public LineRenderer RightLaser;


    // Update is called once per frame
    void Start()
    {
        PS = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
        LeftLaser.enabled = false;
        RightLaser.enabled = true;
        fireTimer = 0;
    }

    void FixedUpdate () {
        RotateController();
        fireTimer = fireTimer + Time.deltaTime;
        if (Input.GetAxis("joystick button 10") > 0 || Input.GetKey("space"))
        {
            if (fireTimer > fireRate)
            {
                if (gun1 == true && gun2 == false && PS.mana > 0)
                {
                    Fire1();
                    PS.mana = PS.mana - 1;
                    PS.timer = PS.ManaRegenPerSecond;
                    gun1 = false;
                    LeftLaser.enabled = false;
                    RightLaser.enabled = true;
                    gun2 = true;
                }
                else if (gun2 == true && gun1 == false && PS.mana > 0)
                {
                    Fire2();
                    PS.mana = PS.mana - 1;
                    PS.timer = PS.ManaRegenPerSecond;
                    gun2 = false;
                    LeftLaser.enabled = true;
                    RightLaser.enabled = false;
                    gun1 = true;
                }
                fireTimer = 0;
            }
        }
    }

    void RotateController() {
        float x = Input.GetAxis("R_Horizontal");
        float y = Input.GetAxis("R_Vertical");

        //guns.transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, -y) * Mathf.Rad2Deg - 45, guns.transform.eulerAngles.z);

        if (x != 0.0f || y != 0.0f)
        {
            float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            guns.transform.eulerAngles = new Vector3 (0,angle + 45,0);
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

}
