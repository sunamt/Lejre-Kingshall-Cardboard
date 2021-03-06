﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class ChangeSceneScript : MonoBehaviour
{


    private float _gazeTimer = 0f;
    private GameObject loadUILeft;
    private GameObject loadUIRight;
    private bool _isGazed = false;

    private float loadCircle;
    private float _gazeDelay = 3f;

    bool wait;

    // Use this for initialization
    void Start()
    {
        loadUILeft = GameObject.Find("LoaderLeft");
        //loadUIRight = GameObject.Find("LoaderRight");
        wait = true;
        StartCoroutine(FinishWaiting());
    }

    IEnumerator FinishWaiting()
    {
        yield return new WaitForSeconds(5);
        wait = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (wait)
            return;

        if (_isGazed)
        {

            _gazeTimer += Time.deltaTime;

            loadCircle = _gazeTimer / _gazeDelay;
            loadUILeft.GetComponent<Image>().fillAmount = loadCircle;
            //loadUIRight.GetComponent<Image>().fillAmount = loadCircle;

        }
        else
        {
            _gazeTimer = 0f;
        }

        if (_gazeTimer >= _gazeDelay)
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        string sceneName = this.gameObject.name;
        Scene sceneExists = SceneManager.GetSceneByName(sceneName);
        SphereFader sf;

        try
        {
            sf = GameObject.Find("Sphere_Inv").GetComponent<SphereFader>();
            sf.FadeAlphaUp(sceneName);
        }
        catch (System.Exception e)
        {
            //print(sceneExists.name + " - Does scene exist");
            //print("Changing scene to " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }

    public void Gazing()
    {
        _isGazed = true;
    }

    public void NotGazing()
    {
        loadUILeft.GetComponent<Image>().fillAmount = 0f;
        //loadUIRight.GetComponent<Image>().fillAmount = 0f;
        _isGazed = false;
    }
}