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
    public float fireRate;


    // Update is called once per frame
    void Start()
    {
        fireTimer = 0;
    }

    void Update () {
        RotateController();

        if (Input.GetAxis("joystick button 10") > 0 || Input.GetKey("space"))
        {
            fireTimer = fireTimer + Time.deltaTime;
            if(fireTimer > fireRate)
            {
                Fire1();
                Fire2();
                fireTimer = 0;
            }
        }
    }

    void RotateController() {
            float x = Input.GetAxis("R_horizontal");
            float y = Input.GetAxis("R_vertical");
            guns.transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, -y) * Mathf.Rad2Deg - 45, guns.transform.eulerAngles.z);
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
