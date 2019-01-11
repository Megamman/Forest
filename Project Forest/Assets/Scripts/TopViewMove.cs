using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopViewMove : MonoBehaviour
{
    
    public float speed;

    public Animator animator;

    public Rigidbody2D rb2d;

    // Update is called once per frame
    void Update()
    {
        // this will set the controls and the direction of where the character will move.
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0.0f);

        // This will get the paramiter from the animater and activate the animation acording to the direction moved too.
        animator.SetFloat("DirX", movement.x);
        animator.SetFloat("DirY", movement.y);

        // This will set the speed of th character's movement.
        transform.position = transform.position + movement * speed * Time.deltaTime;
        // This will set so that the character will not get stuck in an animation when hitting an object with a Rigidbody and Collider.
        rb2d.velocity = new Vector2(movement.x, movement.y);
    }

}
