using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public GameObject ground;
    public GameObject altGround;

    public bool foundRoom = false;
    public bool foundTrigger = false;

    // Start is called before the first frame update
    void Start() {

        Invoke("Ground", 0.2f);
        //Ground();
    }

    void Ground()
    {
        if (!foundRoom)
        {
            GameObject newGround = Instantiate(ground, transform.position, transform.rotation);
            LevelManager.Instance.rooms.Add(newGround);
        }
        if (foundTrigger)
        {
            Debug.Log (gameObject.transform.position);
            GameObject newAltGround = Instantiate(altGround, transform.position, transform.rotation);
            LevelManager.Instance.rooms.Add(newAltGround);
        }

        Destroy(this);

    }

    void OnTriggerEnter2D (Collider2D other)
    {

        if(other.tag == "Rooms")
        {
            //Debug.Log("found Room");
            foundRoom = true;
            //Destroy(other.gameObject);
        }

        if(other.tag == "Trigger")
        {
            Debug.Log("found Room");
            foundTrigger = true;
            //Destroy(other.gameObject);
        }
    }

}
