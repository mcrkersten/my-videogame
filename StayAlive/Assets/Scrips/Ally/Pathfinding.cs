using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {
    public Transform[] target;
    public float speed;
    public Animator animator;
    public float rotationSpeed;
    public float moveSpeed;
    private float currentDist;
    private int current;
	// Update is called once per frame
	void Update () {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("CageEnd")) {
            //Vector3 pos = Vector3.MoveTowards(transform.position, new Vector3(target[current].position.x, transform.position.y, target[current].position.z), speed);
            //GetComponent<Rigidbody>().MovePosition(pos);

            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target[current].transform.position - transform.position), rotationSpeed * Time.deltaTime);
        }
        currentDist = Vector3.Distance(target[current].transform.position, this.transform.position);

        if(currentDist < .5f)
        {
            current++;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NextLevel")
        {
            Destroy(gameObject);
        }
    }
}
