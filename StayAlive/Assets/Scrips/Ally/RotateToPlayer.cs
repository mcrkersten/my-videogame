using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour {

    [Header("Rotation")]
    public GameObject target;
    private GunController playerRotator;
    public float damping;
    private bool lockPlayer;
    public Transform loseTransform;

    [Header("RotatiobLimits")]
    public float min;
    public float max;

    [Header("Animation")]
    public Animator animator;

    Vector3 tempZ;
    bool aniOnce;

    [Header("Converzation & UI")]
    public Camera maincam;
    public Camera talkCam;
    public float talkdistance;
    public Canvas canvas;
    public GameObject fader;

    public GameObject ui;    
    public Text text;
    public int totalTextLines;
    public string[] dialog;
    public GameObject talkIndicator;
    public float resetAngle;
    public GameObject playerStandPos;

    private bool fade = false;

    private int page;
    private float currentDist;



    // Use this for initialization
    void Start () {
        aniOnce = false;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (lockPlayer == false)
            {
                target = GameObject.FindGameObjectWithTag("Player");
                playerRotator = GameObject.FindGameObjectWithTag("rotation").GetComponent<GunController>();

                lockPlayer = true;
            }

            Vector3 targetPostition = new Vector3(target.transform.position.x,
                                      this.transform.position.y,
                                      target.transform.position.z);

            loseTransform.LookAt(targetPostition);

            currentDist = Vector3.Distance(target.transform.position, this.transform.position);

            if (currentDist < talkdistance)
            {
                if (loseTransform.transform.eulerAngles.y > min && loseTransform.transform.eulerAngles.y < max)
                {
                    talkIndicator.SetActive(true);
                    Talk();

                    aniOnce = true;
                    animator.enabled = false;
                    if (transform.eulerAngles.z < 0 || transform.eulerAngles.z > 0)
                    {
                        tempZ = this.transform.eulerAngles;
                        if (tempZ.z < 0)
                        {
                            tempZ = new Vector3(Mathf.Lerp(tempZ.z, 0, .001f), 0, 0);
                        }
                        else
                        {
                            tempZ = new Vector3(Mathf.Lerp(0, tempZ.z, .001f), 0, 0);
                        }
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, tempZ.x);
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                        animator.enabled = false;
                        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, loseTransform.transform.eulerAngles, .05f);                        
                    }
                }                
            }
            else
            {
                transform.eulerAngles = new Vector3(0.1f, transform.eulerAngles.y, 0.1f);

                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, resetAngle, 0), .05f);
                if (this.transform.eulerAngles.y > resetAngle - 1 && this.transform.eulerAngles.y < resetAngle + 1)
                {
                    if (aniOnce == true)
                    {
                        animator.Rebind();
                        aniOnce = false;
                    }
                    animator.enabled = true;
                    talkIndicator.SetActive(false);
                }
            }
        }     
    }
    public void Talk()
    {
        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown("c"))
        {
            ui.SetActive(true);

            if(fade == false)
            {
                fader.GetComponent<FadingOutside>().FadingIn();
                StartCoroutine(FadeTo());
                fade = true;
            }
            else
            {
                CamSwitch1();
            }
            canvas.worldCamera = talkCam;          
        }
    }

    public void CamSwitch1()
    {
        target.transform.position = new Vector3(playerStandPos.transform.position.x, target.transform.position.y, playerStandPos.transform.position.z);
        if (totalTextLines > page)
        {
            target.GetComponent<PlayerController>().cantMoveDialog = true;
            playerRotator.enabled = false;
            talkIndicator.SetActive(false);
            talkCam.enabled = true;
            maincam.enabled = false;
            text.text = dialog[page];
            page++;
        }
        else
        {
            fader.GetComponent<FadingOutside>().FadingIn();
            StartCoroutine(FadeFrom());
            fade = false;
        }
    }

    public void CamSwitch2()
    {
        page = 0;
        maincam.enabled = true;
        talkCam.enabled = false;
        target.GetComponent<PlayerController>().cantMoveDialog = false;
        playerRotator.enabled = true;
        //fade = true;
    }

    IEnumerator FadeTo()
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / .4f)
        {
            //Vector2 size = new Vector2(0, Mathf.Lerp(maincam.orthographicSize, 10, t));
            float size = maincam.orthographicSize - .15f;

            maincam.orthographicSize = size;
            yield return null;
        }
        maincam.orthographicSize = 13;
        CamSwitch1();
    }

    IEnumerator FadeFrom()
    {
        yield return new WaitForSeconds(.4f);
        CamSwitch2();
    }
}
