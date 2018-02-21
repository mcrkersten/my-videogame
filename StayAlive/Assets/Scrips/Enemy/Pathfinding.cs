using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {
    public Transform[] target;
    public float speed;

    private int current;
	// Update is called once per frame
	void Update () {
        if (transform.position.z != target[current].position.z && transform.position.x != target[current].position.x)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, new Vector3(target[current].position.x, transform.position.y, target[current].position.z), speed);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            current = (current +1) % target.Length;
            print(" next Target");
        }
	}
}
