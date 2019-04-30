using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDeactive : MonoBehaviour
{

    private bool path = true;

    void update() 
    {
        if(path){
            this.gameObject.SetActive(false);
        }else {
            this.gameObject.SetActive(true);
        }

        // if(doorWay.active) 
        //     {
        //         this.gameObject.SetActive(false);
        //     }else {
        //         this.gameObject.SetActive(true);
        //     }
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Paths"))
        {
            path = true;
        } else {
            path = false;
        }
    }
}
