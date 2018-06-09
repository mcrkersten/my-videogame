using UnityEngine;
using System.Collections;


public class Loader : MonoBehaviour
{
    public GameObject playerStats;


    void Awake()
    {
        if (PlayerStats.instance == null)

            Instantiate(playerStats);
    }
}       