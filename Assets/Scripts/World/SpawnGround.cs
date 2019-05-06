using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public GameObject ground;

    private bool foundRoom = false;

    // Start is called before the first frame update
    void Start() {

        Ground();
    }

    void Ground()
    {
        if (foundRoom)
        {
            ground.GetComponent<Generation_1>().GenDoors();
        } else {

            GameObject newGround = Instantiate(ground, transform.position, transform.rotation);
            LevelManager.Instance.rooms.Add(newGround);
        }

        //Destroy(this);

    }

}
