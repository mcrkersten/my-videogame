using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {
    public Transform[] target;
    public float speed;
    public Animator animator;

    private int current;
	// Update is called once per frame
	void Update () {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("CageEnd")) {
            Vector3 pos = Vector3.MoveTowards(transform.position, new Vector3(target[current].position.x, transform.position.y, target[current].position.z), speed);
            GetComponent<Rigidbody>().MovePosition(pos);
        }

        Debug.DrawLine(target[current].position, transform.position, Color.green);

        if (transform.position.z == target[current].position.z && transform.position.x == target[current].position.x)
        {
            current = (current +1) % target.Length;
            print(current);
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
