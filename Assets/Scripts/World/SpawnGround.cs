using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public GameObject ground;
    public GameObject door;

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
            Destroy(door);
            ground.GetComponent<Generation_1>().GenDoor();
        } else {
            Instantiate(ground, transform.position, transform.rotation);
        }

    }

}
