using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnAnimation : MonoBehaviour {

    [Header("Materials")]
    public Renderer material;
    private MaterialPropertyBlock theObject;


    public float AnimtionSpeed;
    public float AnimationTime;
    private float temp;
    

    // Use this for initialization
    void Start () {
        theObject = new MaterialPropertyBlock();
        material = GetComponent<Renderer>();
        material.GetPropertyBlock(theObject);
        theObject.SetFloat("_Disolver", 0f);
        material.SetPropertyBlock(theObject);

    }
	
	// Update is called once per frame
	void Update () {
		for(float i = 0; i < AnimationTime; i = i + 0.1f)
        {
            material.GetPropertyBlock(theObject);
            theObject.SetFloat("_Disolver", temp = temp + 0.001f);
            material.SetPropertyBlock(theObject);
        }
	}
}
