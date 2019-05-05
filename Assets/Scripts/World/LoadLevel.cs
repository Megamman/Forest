using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public string levelName;

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    public Animator trees;

    public int rooms;
    public bool operation = false;

    // Start is called before the first frame update
    void Start()
    {
        loadingScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        rooms = GetComponent<LevelManager>().numbRooms;

        //load();
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
