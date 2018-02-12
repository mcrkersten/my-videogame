using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    
    private int TotalEnemies;
    private float TimeWaited;
    private bool OneLevelanimation = true;

    [Header("World information")]
    [SerializeField, Tooltip("Update automatisch")]
    public int levelCounter = 0;
    [SerializeField, Tooltip("Update automatisch")]
    public int TotalSpawnPoints;
    [SerializeField, Tooltip("Select all level layers")]
    public GameObject[] levels;
    [SerializeField, Tooltip("Select all level floors | remove collision at animation")]
    public GameObject[] levelFloor;
    [Header("Animation atributes")]
    public Animator[] anim;
    [SerializeField, RangeAttribute(1, 10), Tooltip("Timer voor spawnen van enemies na level transitie")]
    public float TimeWait;
    [SerializeField, Tooltip("Hole in floor type")]
    public GameObject NextFloorAnimationFab;
    [Header("Player information")]
    public GameObject Player;
    public bool canMove = true;


    // Use this for initialization
    void Start () {
        TimeWaited = TimeWait;
	}
	
	// Update is called once per frame
	void Update () {
        TotalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        TotalSpawnPoints = levels[levelCounter].transform.childCount;
        if (TotalEnemies == 0)
        {
            if(TotalSpawnPoints == 1)
            {
                canMove = false;
                if (OneLevelanimation && TimeWaited < 1)
                {
                    NextFloor();
                    OneLevelanimation = false;
                }
                TimeWaited = TimeWaited - Time.deltaTime;
                if (TimeWaited < 0)
                {
                    Physics.IgnoreCollision(levelFloor[levelCounter].GetComponent<MeshCollider>(), Player.GetComponent<Collider>());
                    anim[levelCounter].SetBool("NextLevel", true);
                    levelCounter = levelCounter + 1;
                    TimeWaited = TimeWait;
                    OneLevelanimation = true;
                    canMove = true;
                }
            }
        }
    }

    void NextFloor()
    {
        var nextFloor = (GameObject)Instantiate(
            NextFloorAnimationFab,
            Player.transform.position,
            Player.transform.rotation);
        nextFloor.transform.position = Player.transform.position;
        nextFloor.transform.parent = levelFloor[levelCounter].transform;
    }
}
