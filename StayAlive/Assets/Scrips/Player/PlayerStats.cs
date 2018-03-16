using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [Header("Point atributes")]
    public int points;

    [Header("Health atributes")]
    public int health;
    public int mana;
    public float ManaRegenPerSecond;
    public float timer;


    // Use this for initialization
    void Awake()
    {
        timer = ManaRegenPerSecond;
        DontDestroyOnLoad(transform.gameObject);
    }


    void Update()
    {
        if(mana < 5)
        {
            timer = timer - Time.deltaTime;
            if(timer <= 0)
            {
                mana = mana +1;
                timer = ManaRegenPerSecond;
            }
        }
    }

}
