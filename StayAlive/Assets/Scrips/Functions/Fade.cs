using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(FadeTo(0f, 4.0f));
    }


    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = GetComponent<SpriteRenderer>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));
            GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }
}
