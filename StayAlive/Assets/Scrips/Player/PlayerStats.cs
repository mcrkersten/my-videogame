using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [Header("Point atributes")]
    public int points;

    [Header("Health atributes")]
    public int health;


    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
