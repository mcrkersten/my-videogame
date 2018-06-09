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
    [HideInInspector]
    public float timer;
    public static PlayerStats instance = null;

    [Header("World atributes")]

    public int gateNumber;
    public int levelNumber;
    public string dungeonName;

    [HideInInspector]
    public int levelLength;
    [HideInInspector]
    public string levelName;

    public List<bool> liberation = new List<bool>();
    
    void Awake()
    {
        levelNumber = 0;
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        timer = ManaRegenPerSecond;

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
