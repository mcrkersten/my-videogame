using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {
    public int sceneToDestroy;

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == sceneToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
