using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject PlayerPrefab;
    public float TimeBeforeSpawn;
    private float TimeWaited;
    private bool OneSpawn = false;

	// Use this for initialization
	void Start () {
        TimeWaited = TimeBeforeSpawn;
    }

    void Update()
    {
        TimeWaited = TimeWaited - Time.deltaTime;

        if(TimeWaited < 0)
        {
            if(OneSpawn == false)
            {
                SpawnPlayer();
                OneSpawn = true;
            }
        }
    }

    void SpawnPlayer()
    {
        var player = (GameObject)Instantiate(
            PlayerPrefab,
            gameObject.transform.position,
            gameObject.transform.rotation);
    }
}
