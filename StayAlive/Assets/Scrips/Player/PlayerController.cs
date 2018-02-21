using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float Movespeed = .1f;

    // Use this for initialization

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        transform.Translate(new Vector3(-1,0,1) * Input.GetAxis("Vertical") * Movespeed);
        transform.Translate(new Vector3(1, 0, 1) * Input.GetAxis("Horizontal") * Movespeed);
    }
}