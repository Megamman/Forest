using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopViewMove : MonoBehaviour
{
    
    public float speed;

    private Animator animator;

    private Rigidbody2D rb2d;

    private SpriteRenderer renderer;

    public 

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // this will set the controls and the direction of where the character will move.
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0.0f);

        // This will get the paramiter from the animater and activate the animation acording to the direction moved too.
        animator.SetInteger("DirX", Mathf.CeilToInt(movement.x));
        animator.SetInteger("DirY", Mathf.CeilToInt(movement.y));

        // If going left the renderer will check the x to flip
        renderer.flipX = movement.x < 0;

        // This will set the speed of th character's movement.
        transform.position = transform.position + movement * speed * Time.deltaTime;
        // This will set so that the character will not get stuck in an animation when hitting an object with a Rigidbody and Collider.
        rb2d.velocity = new Vector2(movement.x, movement.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paths")
        {
            Teleport teleportScript = other.GetComponentInChildren<Teleport>();
            if (teleportScript == null) return;

            teleportScript.TeleportObject(gameObject);
        }
        
        // CAN BREAK: IF IT TRIGGERS ANYTHING ELSE, CHANGE THE TO LEVEL OBJECT.
        if (other.tag == "Teleport")
        {
            ToLevel toLevelScript = other.GetComponentInChildren<ToLevel>();
            if (toLevelScript == null) return;

            toLevelScript.ShowDialogue();
        }

        if (other.tag == "MainCamera")
        {
            CameraTP toPosScript = other.GetComponentInChildren<CameraTP>();
            if (toPosScript == null) return;

            toPosScript.TeleportCamera();
        }

        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);

        }

    }

}
