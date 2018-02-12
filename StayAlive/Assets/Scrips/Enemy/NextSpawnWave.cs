using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSpawnWave : MonoBehaviour {
    public GameObject[] Enemies;
    public Manager manager;
    public bool spawnEnemies;
    public int levelNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(manager.levelCounter == levelNumber)
        {
            spawnEnemies = true;
        }
	}
}
