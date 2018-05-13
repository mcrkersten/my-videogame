using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

    public Animator cameraObject;
    public GameObject warnignSign;
    public Fade fade;
    public int maxAlpha;


    private void OnTriggerEnter(Collider trig)
    {
        if (trig.gameObject.tag == "CameraTrigger")
        {
            
            cameraObject.SetTrigger("FirstMove");

            if(warnignSign.GetComponent<SpriteRenderer>().enabled == false)
            {
                warnignSign.GetComponent<SpriteRenderer>().enabled = true;
                StartCoroutine(FadeTo(1.0f, 1.0f));
            }
            else
            {
                StartCoroutine(FadeTo(0f, 1.0f));
            }
            Destroy(trig);
            return;
        }
        if(trig.gameObject.tag == "Fade")
        {
            fade.Fading(true);
        }
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = warnignSign.GetComponent<SpriteRenderer>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            warnignSign.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }
}
