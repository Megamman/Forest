using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public GameObject AreaCam;
    public Transform[] loc;
    public GameObject[] enemies;

    void Start()
    {
        AreaCam.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AreaCam.SetActive(true);
            for (int i = 0; i < loc.Length; i++)
            {
                int rand = Random.Range(0, enemies.Length);
                Instantiate(enemies[rand], loc[i].position, loc[i].rotation);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AreaCam.SetActive(false);
        }
    }

}
