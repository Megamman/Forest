using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{

    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, enemies.Length);
        Instantiate(enemies[rand], transform.position, transform.rotation, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
