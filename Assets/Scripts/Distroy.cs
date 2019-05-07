using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distroy : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {

        if(other.tag == "Rooms")
        {
            Debug.Log("ground");
            //Destroy(other.gameObject);
        }
    }
}
