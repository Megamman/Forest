using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailSpawn : MonoBehaviour
{
    public GameObject Trail;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Trail, transform.position, transform.rotation);
            Trail.SetActive(true);
        }
    }
}
