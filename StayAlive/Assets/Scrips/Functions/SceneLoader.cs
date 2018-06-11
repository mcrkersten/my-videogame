using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private bool loadScene = false;
    public bool loadSceneGO = false;
    public GameObject block;
    public GameObject loadAni;
    public string scene;
    [SerializeField]
    private Text loadingText;
    public Text proTip;
    public GameObject image;


    // Updates once per frame
    void Update()
    {
        if (loadSceneGO == true && loadScene == false)
        {
            loadScene = true;
            loadSceneGO = false;

            loadingText.text = "Loading";
            proTip.text = "Having trouble with the game? Try winning!";
            block.SetActive(true);
            loadAni.SetActive(true);
            image.SetActive(true);

            StartCoroutine(LoadNewScene());

        }

        if (loadScene == true)
        {
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

        }

    }

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(1.5f);
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        while (!async.isDone)
        {
            yield return null;
        }

    }

}