using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHolder : MonoBehaviour {

    public GameObject bullet;
    private bool empty;

	// Use this for initialization
	void Start () {
        empty = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.childCount <= 0 && empty == true)
        {
            StartCoroutine(Wait());
            empty = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        spawnNewBullet();
        empty = true;
    }

    void spawnNewBullet()
    {
        Instantiate(bullet,
                new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z),
                new Quaternion(0,0,0,0),
                this.gameObject.transform);
    }
}
