using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawner : MonoBehaviour {
    public GameObject EnemyPrefab;
    private Transform Spawnpoint;
    public NextSpawnWave nextSpawn;

    public float TimeWait;
    private float TimeWaited;
	// Use this for initialization
	void Start () {
        Spawnpoint = GetComponent<Transform>();
        TimeWaited = TimeWait;
	}
	
	// Update is called once per frame
	void Update () {
        TimeWaited = TimeWaited - Time.deltaTime;
        if (TimeWaited < 0 && nextSpawn.spawnEnemies == true)
        {
            SpawnEnemy();
        }
        
	}

    void SpawnEnemy()
    {
        var enemy = (GameObject)Instantiate(
            EnemyPrefab,
            Spawnpoint.position,
            Spawnpoint.rotation);
        Destroy(gameObject);
    }
}
