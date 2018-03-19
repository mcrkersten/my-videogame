using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mortar : MonoBehaviour
{
    public Transform mortarSpawn;
    private float fireTimer;
    public float fireRate;
    public int MortarSpeed;
    public GameObject EnemyMortarPrefab;

	// Use this for initialization
	void Start ()
    {
        fireTimer = fireRate;
    }
	
	// Update is called once per frame
	void Update ()
    {
        fireTimer = fireTimer - Time.deltaTime;
        if (fireTimer < 0)
        {
            Fire();
            fireTimer = fireRate;
        }
    }

    void Fire()
    {
        var bulletEnemy = (GameObject)Instantiate(
    EnemyMortarPrefab,
    mortarSpawn.position,
    mortarSpawn.rotation);

        // Add velocity to the bullet
        bulletEnemy.GetComponent<Rigidbody>().velocity = bulletEnemy.transform.up * MortarSpeed;
    }
}
