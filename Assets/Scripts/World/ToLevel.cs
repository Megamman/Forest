﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToLevel : MonoBehaviour
{
    public string levelName;

    public GameObject text;
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    public Animator trees;

    //private IEnumerator LoadAsynchronously;

    void Start () {
        text.SetActive(false);
        loadingScreen.SetActive(false);
    }

    public void ShowDialogue()
    {
        text.SetActive(true);
    }

    void Update ()
    {
        if (Input.GetButtonDown("Interaction") && text.activeInHierarchy == true)
        {
            text.SetActive(false);
            //SceneManager.LoadScene(levelName);

            trees.SetBool("ChangeScene", true);

            StartCoroutine(LoadAsynchronously());
        }

    }

    IEnumerator LoadAsynchronously ()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
        if (operation.isDone) trees.SetBool("ChangeScene", false);
    }

    void OnTriggerExit2D () {
        text.SetActive(false);
    }

}
