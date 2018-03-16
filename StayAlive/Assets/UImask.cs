using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImask : MonoBehaviour {


    [Header("Hit points")]
    public SpriteMask[] HP;
    public SpriteRenderer[] accent1;

    [Header("Mana")]
    public SpriteMask[] mana;
    public SpriteRenderer[] accent2;

    [Header("Playerstats")]
    public PlayerStats stats;

    // Use this for initialization
    void Awake () {
        stats = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        HPMask();
        ManaMask();
    }

    void HPMask()
    {
        if (stats.health == 0)
        {
            HP[0].enabled = false;
            accent1[0].enabled = false;
        }
        if (stats.health == 1)
        {
            HP[1].enabled = false;

            accent1[1].enabled = false;
            accent1[0].enabled = true;
        }
        if (stats.health == 2)
        {
            HP[2].enabled = false;

            accent1[2].enabled = false;
            accent1[1].enabled = true;
        }
        if (stats.health == 3)
        {
            HP[3].enabled = false;

            accent1[3].enabled = false;
            accent1[2].enabled = true;
        }
        if (stats.health == 4)
        {
            HP[4].enabled = false;

            accent1[4].enabled = false;
            accent1[3].enabled = true;
        }
        if (stats.health == 5)
        {
            accent1[4].enabled = true;
        }
    }

    void ManaMask()
    {
        if(stats.mana == 0)
        {
            mana[0].enabled = false;
            accent2[0].enabled = false;

        }
        if (stats.mana == 1)
        {
            mana[0].enabled = true;
            mana[1].enabled = false;

            accent2[0].enabled = true;
            accent2[1].enabled = false;

        }
        if (stats.mana == 2)
        {
            mana[1].enabled = true;
            mana[2].enabled = false;

            accent2[1].enabled = true;
            accent2[2].enabled = false;

            accent2[0].enabled = false;

        }
        if (stats.mana == 3){
            mana[2].enabled = true;
            mana[3].enabled = false;

            accent2[2].enabled = true;
            accent2[3].enabled = false;

            accent2[1].enabled = false;
        }
        if(stats.mana == 4)
        {
            mana[3].enabled = true;
            mana[4].enabled = false;

            accent2[3].enabled = true;
            accent2[4].enabled = false;

            accent2[2].enabled = false;
        }
        if(stats.mana == 5)
        {
            mana[4].enabled = true;
            accent2[4].enabled = true;

            accent2[3].enabled = false;
        }
    }
}
