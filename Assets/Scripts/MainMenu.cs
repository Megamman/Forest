using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string levelName;
    
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    void Start()
    {
        loadingScreen.SetActive(false);
    }

    public void PlayGame ()
    {
        StartCoroutine(LoadAsynchronously());
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator LoadAsynchronously()
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
    }
}
