using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generation_1 : MonoBehaviour
{

    // this generation will may happen when the monsters are dead??
    public GameObject[] enemies;
    public GameObject[] trees;
    public GameObject[] doors;

    //public List<GameObject> rooms;

    private bool foundEnemy = true;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("GenEnemy", 0);
        Invoke("GenTree", 0);
        Invoke("GenDoors", 0.1f);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (!foundEnemy)
    //     {
    //         GenDoors();
    //     }
    // }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Rooms")
        {
            Debug.Log("ground");
            //foundRoom = true;
        }

        if (other.CompareTag("enemy"))
        {
            Debug.Log(gameObject.name);
            foundEnemy = true;
        } else {
            foundEnemy = false;
            this.gameObject.SetActive(true);
        }

    }

    void GenEnemy()
    {
        if(enemies.Length > 0)
        {
            int enemyRand = Random.Range(0, enemies.Length);
            Instantiate(enemies[enemyRand], transform.position, transform.rotation, transform);
        }
    }

    void GenTree()
    {
        int treeRand = Random.Range(0, trees.Length);
        Instantiate(trees[treeRand], transform.position, transform.rotation, transform);
    }

    public void GenDoors()
    {
        int doorRand = Random.Range(0, 5);

        if (doorRand > 1)
        {
        int pathRand = Random.Range(0, doors.Length);
        Instantiate(doors[pathRand], transform.position, transform.rotation, transform);
        }

    }


}
