using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar : Bullet {

    public GameObject dirtPrefab;

    void OnCollisionEnter(Collision coll)
    {
        BulletPosition = gameObject.transform;

        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Wall" || coll.gameObject.tag == "EnemyBullet" || coll.gameObject.tag == "Bullet")
        {
            if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "EnemyBullet")
            {
                dirt();
                smoke();
                transform.DetachChildren();
                Destroy(gameObject);
            }
        }
    }

    void dirt()
    {
        var smoke = (GameObject)Instantiate(
            dirtPrefab,
            new Vector3(BulletPosition.position.x + .8f, BulletPosition.position.y + 1, BulletPosition.position.z - .8f),
            Quaternion.Euler(45, -45, 45));
    }
}
