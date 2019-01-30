using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Range : MonoBehaviour
{
    public Animator anim;
    public GameObject spawning;
    public Vector3 spawn;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Spawn());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {

        //Debug.Log("I am idle");
        // This will start a timer
        yield return new WaitForSeconds(2f);

        // This will set the parameter Intiger in the animator to the generated number
        anim.SetInteger("Spawn", 1);
        //Debug.Log(rand);

        StartCoroutine(ResetAnim());
    }

    IEnumerator ResetAnim()
    {
        yield return new WaitForSeconds(0.25f);


        // This will set the parameter Intiger in the animato to the set number (0)
        anim.SetInteger("Spawn", 0);
        
        // This will spawn the object in gameobject spawning
        spawn = transform.TransformPoint(Vector3.down * 2);
        Instantiate(spawning, spawn,spawning.transform.rotation);

        //Debug.Log("I stopped moving");
        StartCoroutine(Spawn());
    }

}
