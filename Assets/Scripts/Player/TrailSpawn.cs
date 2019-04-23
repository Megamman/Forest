using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailSpawn : MonoBehaviour
{
    public GameObject weapon;
    public Transform attackPos;

    private Animator anim;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(weapon, attackPos.position, transform.rotation);

        }

        
    }
}
