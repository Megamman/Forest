using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public float minRooms;

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    public Animator trees;
    public GameObject treesObject;

    public int rooms;
    public bool operation = false;

    // Start is called before the first frame update
    void Start()
    {
        loadingScreen.SetActive(true);
        treesObject.SetActive(true);
        trees.SetBool("ChangeScene", true);
    }

    // Update is called once per frame
    void Update()
    {
        rooms = GetComponent<LevelManager>().numbRooms;

        StartCoroutine(LevelLoader());
        //load();
    }

    IEnumerator LevelLoader()
    {
        float rooms = GetComponent<LevelManager>().rooms.Count;
        slider.maxValue = minRooms;

        while (rooms < minRooms)
        {
            slider.value = GetComponent<LevelManager>().rooms.Count;

            yield return null;
        }
        trees.SetBool("ChangeScene", false);
        loadingScreen.SetActive(false);
        //treesObject.SetActive(false);


    }

    /*void load()
    {
        if (rooms > 5)
        {
            operation == true;
            trees.SetBool("ChangeScene", false);
            loadingScreen.SetActive(false);

        }
        else
        {
            while (!operation)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);

                slider.value = progress;
                progressText.text = progress * 100f + "%";

                yield return null;
            }
        }
    }*/

    /**
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
        if (operation.isDone) trees.SetBool("ChangeScene", false);
    }
    */
}
