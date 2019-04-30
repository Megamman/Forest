using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public GameObject ground;

    private bool foundGround = false;

    // Start is called before the first frame update
    void Start() {

        Invoke("Ground", 0.5f);

        Destroy(gameObject, 2f);
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
            ground.GetComponent<Generation_1>().GenDoors();
        } else {
            Instantiate(ground, transform.position, transform.rotation);
        }

    }

}
