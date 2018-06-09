using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadingOutside : MonoBehaviour
{
    public Image loaderImage;
    // Use this for initialization
    public void FadingIn()
    {
        StartCoroutine(FadeIn(1f, .4f));
    } 

    public void FadingOut()
    {
        StartCoroutine(FadeOut(0f, .4f));
    }


    public IEnumerator FadeIn(float aValue, float aTime)
    {
        float alpha = loaderImage.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));
            loaderImage.color = newColor;          
            yield return null;            
        }
        FadingOut();
    }

    IEnumerator FadeOut(float aValue, float aTime)
    {
        float alpha = loaderImage.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));
            loaderImage.color = newColor;
            yield return null;
        }
    }
}
