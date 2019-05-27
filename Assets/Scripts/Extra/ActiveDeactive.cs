using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ActiveDeactive : MonoBehaviour
{
    private BoxCollider2D collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    public void SetActive(bool active)
    {
        collider.enabled = active;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("I have triggered.");
        if (other.gameObject.tag == "Paths")
        {
            SetActive(false);
        }
    }
}
