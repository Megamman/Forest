using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Transform targetchild { get; private set; }
    public GameObject child;
    public bool followChild = true;

    void Start()
    {
        if (followChild)
        {
            targetchild = child.transform;
        }
    }

    void update()
    {
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Blade"))
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
