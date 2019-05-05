using System.Collections;
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
            SceneManager.LoadScene(levelName);
        }

    }

    void OnTriggerExit2D () {
        text.SetActive(false);
    }

}
