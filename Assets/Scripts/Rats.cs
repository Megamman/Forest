using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rats : MonoBehaviour
{
    public EnemyBehavior behavior;

    private Animator animator;
    private SpriteRenderer renderer;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
         // This will get the paramiter from the animater and activate the animation acording to the direction moved too.
        animator.SetInteger("DirX", Mathf.CeilToInt(movement.x));
        animator.SetInteger("DirY", Mathf.CeilToInt(movement.y));

        // If going left the renderer will check the x to flip
        renderer.flipX = movement.x < 0;

    
        // This will set so that the character will not get stuck in an animation when hitting an object with a Rigidbody and Collider.
        rb2d.velocity = new Vector2(movement.x, movement.y);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Follow();
        }
    }

    void Follow()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, behavior.worldSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDist && Vector2.Distance(transform.position, player.position) > retreatDist)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -behavior.worldSpeed * Time.deltaTime);
        }
    }


}
