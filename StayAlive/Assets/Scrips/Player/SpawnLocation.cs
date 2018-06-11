using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{

    public List<GameObject> gateNames = new List<GameObject>();
    [SerializeField]
    private GameObject playerStats;

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("PlayerStats");
        this.gameObject.transform.position = gateNames[playerStats.GetComponent<PlayerStats>().gateNumber].transform.position;
    }
}