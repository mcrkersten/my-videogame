using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fire : MonoBehaviour
{
    public Transform bulletSpawn;
    private float fireTimer;
    public float fireRate;
    public int bulletSpeed;
    public GameObject EnemybulletPrefab;
    // Use this for initialization
    void Start () {
        fireTimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer = fireTimer - Time.deltaTime;
        if(fireTimer < 0){
            Fire();
            fireTimer = fireRate;
        }
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
}


