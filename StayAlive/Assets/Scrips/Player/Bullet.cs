using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject smokePrefab;
    public Transform BulletPosition;
    public bool isShot;
    [Header("Audio settings")]
    public AudioSource Source;
    public AudioClip AudioHit;
    public AudioClip AudioEndLife;
    private bool hasPlayed = false;

    public float timer;
    private float timePassed;
    private void Update()
    {
        timePassed = timePassed + Time.deltaTime;
        if(timePassed > timer && isShot == true)
        {
            BulletPosition = gameObject.transform;
            playSound(0);
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
                playSound(1);
                transform.DetachChildren();
            }
            Destroy(this.gameObject);
        }
    }

    public void smoke()
    {
        var smoke = (GameObject)Instantiate(
            smokePrefab,
            BulletPosition.position,
            BulletPosition.rotation);
    }

    public void playSound(int i)
    {
        Source.pitch = (Random.Range(1.3f, .8f));
        if (i == 1)
        {
            Source.PlayOneShot(AudioHit);
        } 
        else if(i == 0)
        {
            Source.PlayOneShot(AudioEndLife);
        }
    }
}
