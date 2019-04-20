using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject text;
    public GameObject dialogueBox;

    void Start () {
        text.SetActive(false);
        dialogueBox.SetActive(false);
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
            dialogueBox.SetActive(true);
        }

    }

    void OnTriggerExit2D () {
        text.SetActive(false);
        dialogueBox.SetActive(false);
    }
    
}
