using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSingleLayerLevels : MonoBehaviour {

    private float TimeWaited;
    private int TotalEnemies;
    private bool once = true;

    public GameObject mainCamshaker;
    public GameObject GateSmokeParticlePrefab;

    [SerializeField, Tooltip("Update automatisch")]
    public int TotalSpawnPoints;

    [Header("Animation atributes")]
    public Animator anim;
    [SerializeField, RangeAttribute(1, 10), Tooltip("Timer voor spawnen van enemies na level transitie")]
    public float TimeWait;

    // Use this for initialization
    void Start () {
        TimeWaited = TimeWait;
    }

    // Update is called once per frame
    void Update()
    {
        TotalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        TotalSpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawn").Length;

        if (TotalEnemies == 0 && TotalSpawnPoints == 0)
        {
            anim.SetBool("NextLevel", true);
            TimeWaited = TimeWaited - Time.deltaTime;
            if (TimeWaited < 0)
            {
                mainCamshaker.GetComponent<CameraShake>().enabled = true;
                if (once == true)
                {
                    GateSmoke();
                    once = false;
                }
            }
        }
    }

    void GateSmoke()
    {
        var smoke = (GameObject)Instantiate(
            GateSmokeParticlePrefab
            );
    }
}


