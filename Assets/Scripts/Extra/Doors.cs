using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject spawn;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Paths")
        {
            Destroy(spawn);
        }
    }
}
