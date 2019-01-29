using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eneamy : MonoBehaviour
{
    public float noise = 20f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Random.insideUnitCircle * noise;
    }
}

