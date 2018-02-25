using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSingleLayerLevels : MonoBehaviour {

    private float TimeWaited;

    [SerializeField]
    private int TotalEnemies;
    private bool once = true;

    public GameObject mainCamshaker;
    public GameObject GateSmokeParticle;

    [SerializeField, Tooltip("Update automatisch")]
    public int TotalSpawnPoints;

    [Header("Animation atributes")]
    [SerializeField, Tooltip("Animator for portal")]
    public Animator portal;
    [SerializeField, Tooltip("Animator for cages")]
    public Animator[] cages;
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

        if (TotalEnemies == 0)
        {
            animateCages();

            if(TotalSpawnPoints == 0)
            {
                portal.SetBool("NextLevel", true);
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
    }

    void GateSmoke()
    {
        GateSmokeParticle.SetActive(true);
    }

    void animateCages()
    {
        for (int i = 0; i < cages.Length; i++)
        {
            cages[i].SetBool("Free", true);
        }
    }
}


