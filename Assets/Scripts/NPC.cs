using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Start()
    {
        // This will start the IEnumerator
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
     
        //Debug.Log("I am idle");
        // This will start a timer
        yield return new WaitForSeconds(5f);

        // This will generate a random number
        int rand = Random.Range(1, 4);

        // This will set the parameter Intiger in the animator to the generated number
        anim.SetInteger("state", rand);
        //Debug.Log(rand);

        StartCoroutine(ResetAnim());
    }


    IEnumerator ResetAnim()
    {
        yield return new WaitForSeconds(1f);

        // This will set the parameter Intiger in the animato to the set number (0)
        anim.SetInteger("state", 0);
        //Debug.Log("I stopped moving");
        StartCoroutine(Timer());
    }
}
