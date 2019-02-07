using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailSpawn : MonoBehaviour
{
    public GameObject Trail;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Trail, transform.position, transform.rotation);
            Trail.SetActive(true);
        }
    }
}
