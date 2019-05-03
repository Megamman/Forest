using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private LevelManager templates;

    //Start is called before the first frame update
    void Start()
    {

        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Transform>();
        templates.rooms.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
