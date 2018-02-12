using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject smokePrefab;
    public Transform BulletPosition;

    void OnCollisionEnter(Collision coll)
    {
        BulletPosition = gameObject.transform;

        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Wall" || coll.gameObject.tag == "EnemyBullet" || coll.gameObject.tag == "Bullet")
        {
            if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "EnemyBullet")
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
