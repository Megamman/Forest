using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRottate : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }

        if (Input.GetKeyDown("a"))
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }

        if (Input.GetKeyDown("d"))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }

        if (Input.GetKeyDown("s"))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }
}
