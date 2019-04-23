using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public float timer;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timer);
    }
}
