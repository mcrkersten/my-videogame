using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSelector : MonoBehaviour {

    public GameObject liberated;
    public GameObject nonLiberated;
    public PlayerStats PS;
    public int campNumber;

    private bool oncePS;

	// Use this for initialization
	void Start () {
        oncePS = false;
        if (GameObject.FindGameObjectWithTag("PlayerStats") != null && oncePS == false)
        {
            PS = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
            oncePS = true;

            int tempSize = PS.liberation.Count;

            if (tempSize == campNumber)
            {
                print("Add Camp");
                PS.liberation.Add(false);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (PS.liberation[campNumber -1] == false)
        {
            liberated.SetActive(false);
            nonLiberated.SetActive(true);
        }
        else
        {
            liberated.SetActive(true);
            nonLiberated.SetActive(false);
        }
	}
}
