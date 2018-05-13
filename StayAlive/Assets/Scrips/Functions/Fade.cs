using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(FadeOut(0f, 4.0f));
    }

    public void Fading(bool NextScene)
    {
        StartCoroutine(FadeIn(1f, 4.0f, NextScene));
    }


    IEnumerator FadeOut(float aValue, float aTime)
    {
        float alpha = GetComponent<SpriteRenderer>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));
            GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }

    public IEnumerator FadeIn(float aValue, float aTime,bool NextScene)
    {
        float alpha = GetComponent<SpriteRenderer>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            GetComponent<SpriteRenderer>().color = newColor;

            yield return null;
        }
        if(NextScene == true)
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        print("nextScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
