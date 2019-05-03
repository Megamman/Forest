using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDeactive : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Paths")
        {
            Destroy(gameObject);
        }
    }
}
