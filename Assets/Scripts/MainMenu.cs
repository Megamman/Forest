using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string levelName;

    public GameObject menu;
    public GameObject guide;
    
    void Start()
    {
        guide.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void GuideOn()
    {
        menu.SetActive(false);
        guide.SetActive(true);
    }

    public void GuideOff()
    {
        menu.SetActive(true);
        guide.SetActive(false);
    }

}
