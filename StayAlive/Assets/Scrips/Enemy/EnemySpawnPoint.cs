using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour {

    public GameObject EnemyPrefab;
    public SpawnManager Manager;
    private bool spawned = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Manager.spawnEnemies == true)
        {
            if(spawned == false)
            {
                Spawn();
                Destroy(gameObject);
            }
        }
	}

    void Spawn()
    {
        var enemy = (GameObject)Instantiate(
            EnemyPrefab,
            gameObject.transform.position,
            gameObject.transform.rotation);
    }
}
