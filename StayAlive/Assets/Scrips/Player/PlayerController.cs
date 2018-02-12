using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Manager managerScript;
    public float Movespeed = .1f;

    // Use this for initialization
    private void Start()
    {
        managerScript = GameObject.Find("GameController").GetComponent<Manager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(managerScript.canMove == true)
        {
            Movement();
        }  
    }

    void Movement()
    {
        transform.Translate(new Vector3(-1,0,1) * Input.GetAxis("Vertical") * Movespeed);
        transform.Translate(new Vector3(1, 0, 1) * Input.GetAxis("Horizontal") * Movespeed);
    }
}