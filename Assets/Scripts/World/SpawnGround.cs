using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public GameObject ground;

    private bool foundGround = false;

    // Start is called before the first frame update
    void Start() {

        Invoke("Ground", 0.1f);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            foundGround = true;
        }
    }

    void Ground()
    {
        if (foundGround)
        {
            Destroy(gameObject);
        } else {
            Instantiate(ground, transform.position, transform.rotation);
        }

        Destroy(gameObject, 4f);
    }

}
