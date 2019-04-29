using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject text;
    public GameObject dialoguebox;

    public Dialogue dialogue;

    void Start () {
        text.SetActive(false);
        
        dialoguebox.GetComponent<BoxMovement>().moveOut();
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
            dialoguebox.GetComponent<BoxMovement>().moveIn();
            //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

    }

    void OnTriggerExit2D () {
        text.SetActive(false);
        dialoguebox.GetComponent<BoxMovement>().moveOut();
    }
    
}
