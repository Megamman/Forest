using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject winPanel;

    private List<Enemy> _enemies;
    protected List<Enemy> enemies
    {
        get
        {
            if (_enemies == null) _enemies = new List<Enemy>();
            return _enemies;
        }
        set
        {
            _enemies = value;
        }
    }

    public float timer = 0;

    void Start()
    {
        pausePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy)
            {
                PauseGame();
            }
            else if (pausePanel.activeInHierarchy)
            {
                ResumeGame();
            }
        }
    }

    private void win()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void ToBase()
    {
        Application.LoadLevel(1);
        Time.timeScale = 1;
    }

    public void ToMenu()
    {
        Application.LoadLevel(0);
        Time.timeScale = 1;
    }

    public void Register(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void Unregister(Enemy enemy)
    {
        Debug.Log(enemy);
        enemies.Remove(enemy);
        if (enemies.Count == 0) win();
    }

}
