using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel : MonoBehaviour
{
    public string levelName;

    public GameObject text;

    void Start () {
        text.SetActive(false);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player"){

            text.SetActive(true);

        }
    }

    void Update ()
    {
        if (Input.GetButtonDown("Interaction") && text.activeInHierarchy == true) {
            text.SetActive(false);
            SceneManager.LoadScene(levelName);
        }

    }

    void OnTriggerExit2D () {
        text.SetActive(false);
    }

}
