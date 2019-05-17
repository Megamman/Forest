using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public GameObject[] spawn;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, spawn.Length);
        Instantiate(spawn[rand], transform.position, transform.rotation, transform);
    }
}
