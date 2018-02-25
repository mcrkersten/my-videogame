using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] SpawnPoints;
    public bool spawnEnemies;

    // Use this for initialization
    void Start()
    {
        spawnEnemies = false;
    }

    private void Update()
    {
        if(spawnEnemies == true)
        {
            SpawnPoints = null;
        }
    }
}

