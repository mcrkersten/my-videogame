using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Easy_Stealth : MonoBehaviour
{
    public Transform target;
    private Transform selfLocation;
    public GameObject bloodFab;
    public int moveSpeed;
    public int rotationSpeed;
    private Transform myTransform;
    private Animator animator;
    public string Level_Name;
    private EnemyResponse MoveInVision;
    private Transform tempTransform;

    void Awake()
    {
        myTransform = transform;
        tempTransform = transform;
    }

    // Use this for initialization
    void Start () {
        selfLocation = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        MoveInVision = GetComponent<EnemyResponse>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Normal"))
        {
            Debug.DrawLine(target.position, myTransform.position, Color.red);

            if (MoveInVision.moveAss == true)
            {
                //Move towards target
                myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
                myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

                tempTransform.position = myTransform.position;
                tempTransform.rotation = myTransform.rotation;
            }

            if(MoveInVision.suspicius == true)
            {
                myTransform.position = tempTransform.position;
                myTransform.rotation = tempTransform.rotation;
            }
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Bullet")
        {
            var blood = (GameObject)Instantiate(
                bloodFab,
                selfLocation.position,
                selfLocation.rotation);
            blood.transform.parent = null;//GameObject.Find(Level_Name).transform;
            Destroy(gameObject);
        }
    }
}
