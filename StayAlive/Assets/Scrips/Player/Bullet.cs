using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject smokePrefab;
    public Transform BulletPosition;

    public float timer;
    private float timePassed;
    private void Update()
    {
        timePassed = timePassed + Time.deltaTime;
        if(timePassed > timer)
        {
            BulletPosition = gameObject.transform;
            smoke();
            transform.DetachChildren();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        BulletPosition = gameObject.transform;

        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Wall" || coll.gameObject.tag == "EnemyBullet" || coll.gameObject.tag == "Bullet")
        {
            if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Wall" || coll.gameObject.tag == "EnemyBullet" || coll.gameObject.tag == "Enemy")
            {
                smoke();
                transform.DetachChildren();
            }
            Destroy(gameObject);
        }
    }

    public void smoke()
    {
        var smoke = (GameObject)Instantiate(
            smokePrefab,
            BulletPosition.position,
            BulletPosition.rotation);
    }
}
