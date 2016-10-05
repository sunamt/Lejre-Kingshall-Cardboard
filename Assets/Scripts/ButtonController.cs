using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public bool VR_On;
    private GameObject _sceneController;
    public GameObject progressText;

    private AsyncOperation async = null;

    void Awake()
    {


    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "1_Splash")
        {
            StartCoroutine(WaitToLoadMenu());
        }
    }

    IEnumerator WaitToLoadMenu()
    {
        yield return new WaitForSeconds(4);
        async = SceneManager.LoadSceneAsync(1);
        yield return async;
    }

    // Update is called once per frame
    void Update()
    {
        if (async != null)
        {
            //Update load texture based on async progress
            progressText.GetComponent<Image>().fillAmount = async.progress;
            print(async.progress);
        }
    }



    public void MenuClickHistory()
    {
        SceneManager.LoadScene(2);
    }

    public void MenuClickModel()
    {
        SceneManager.LoadScene(2); //old was 4
    }

    public void MenuClickContact()
    {
        SceneManager.LoadScene(3);
    }

    public void ClickBackToMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void VREnabled()
    {
    }

    public void OpenKingshall()
    {
        StartCoroutine(BeginFade(img.color, Color.white, 3f));   
    }

    public Image img;

    private IEnumerator BeginFade(Color start, Color end, float duration)
    {
        float timer = 0f;
        
        while (timer <= duration)
        {
            img.color = Color.Lerp(start, end, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        switch (GameObject.Find("VR_Toggle").GetComponent<Toggle>().isOn)
        {
            case true:
                SceneManager.LoadScene(7);
                break;
            case false:
                SceneManager.LoadScene(5);
                break;
        }


    }
}