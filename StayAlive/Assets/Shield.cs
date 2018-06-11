using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    public Enemy_Warhog warhog;
    private Animator animator;
    public List<GameObject> spawns = new List<GameObject>();
    public List<GameObject> activeEnemies = new List<GameObject>();
    public GameObject[] enemyType;

    public void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }
    // Use this for initialization
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            warhog.health = warhog.health - 1;
            if(warhog.health >= 0)
            {
                animator.SetTrigger("Hit");
                Wave();
            }           
            if(warhog.health <= 0)
            {
                animator.SetBool("Depleted", true);
                gameObject.GetComponent<Collider>().enabled = false;
            }
        }
    }

    public void Wave()
    {
        int random = Random.Range(0, enemyType.Length);

        foreach(GameObject spawn in spawns)
        {
            GameObject curEnemy = Instantiate(enemyType[random], spawn.transform.position, spawn.transform.rotation, spawn.transform);
            activeEnemies.Add(curEnemy);
        }
    }

    public void Update()
    {
        foreach(GameObject enemy in activeEnemies)
        {
            if(enemy == null)
            {
                activeEnemies.Remove(enemy);
            }
        }
    }

}
