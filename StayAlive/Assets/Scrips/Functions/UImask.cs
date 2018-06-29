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

    [Header("UltimateColors")]
    public Color ultimate;
    public Color normal;
    public Material ultimateMat;
    public Material normalMat;
    public GameObject particles;

    // Use this for initialization
    void Awake () {
        stats = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        HPMask();

        if (stats.mana < 5)
        {
            ManaMask();
        }
        else
        {
            Ultimate();
        }       
    }

    void HPMask()
    {
        for (int i = 0; i < HP.Length; i++)
        {
            if(stats.health - 1 < i)
            {
                HP[i].enabled = false;
            }
            for (int x = 0; x < stats.health; x++)
            {
                HP[x].enabled = true;
            }
            accent1[i].enabled = false;
            accent1[stats.health - 1].enabled = true;          
        }
        if(stats.health == 0)
        {
            HP[0].enabled = false;
        }
    }

    void ManaMask()
    {
        for (int i = 0; i < mana.Length; i++)
        {
            accent2[i].color = normal;
            accent2[i].material = normalMat;
            particles.SetActive(false);

            if (stats.mana - 1 < i)
            {
                mana[i].enabled = false;
            }
            for (int x = 0; x < stats.mana; x++)
            {
                mana[x].enabled = true;
            }
            accent2[i].enabled = false;
            if(stats.mana > 0)
            {
                accent2[stats.mana - 1].enabled = true;
            }
            
        }
        if (stats.mana == 0)
        {
            mana[0].enabled = false;
        }
    }

    void Ultimate()
    {
        if(stats.ActivateUltimate == true)
        {
            for (int i = 0; i < mana.Length; i++)
            {
                particles.SetActive(true);
                mana[4].enabled = true;
                accent2[i].color = ultimate;
                accent2[i].material = ultimateMat;
                accent2[i].enabled = true;
            }
        }
    }        
}
