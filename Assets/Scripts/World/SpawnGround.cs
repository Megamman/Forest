using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public Generation_1 ground;
    public GameObject altGround;

    public int exitIndex;

    public bool foundRoom = false;
    public bool foundTrigger = false;

    // Start is called before the first frame update
    void Start() {

        Invoke("Ground", 0.3f);
        //Ground();
    }

    void Ground()
    {
        if (!foundRoom && !foundTrigger)
        {
            Generation_1 genScript = Instantiate<Generation_1>(ground, transform.position, transform.rotation);

            if (genScript != null)
            {
                genScript.DisableBorder(exitIndex);
            }

            LevelManager.Instance.rooms.Add(genScript.gameObject);
        }

        else if (foundTrigger && !foundRoom)
        {
            Debug.Log (gameObject.transform.position);
            Instantiate(altGround, transform.position, transform.rotation);
        }

        Destroy(this.gameObject);

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
