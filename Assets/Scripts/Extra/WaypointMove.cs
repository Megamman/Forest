using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMove : MonoBehaviour
{

    public float speed;

    public Transform[] waypoints;
    private int randomSpot;

    public float startWaitTime;
    private float waitTime;
    
    public Animator anim;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, waypoints.Length);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[randomSpot].position, speed * Time.deltaTime);


        if (Vector2.Distance(transform.position, waypoints[randomSpot].position) < 0.2f)
        {
            if( waitTime <= 0)
            {
                randomSpot = Random.Range(0, waypoints.Length);
                _renderer.flipX = transform.position.x > waypoints[randomSpot].position.x;
                waitTime = startWaitTime;
                anim.SetInteger("Speed", 1);
            } else
            {
                waitTime -= Time.deltaTime;
                anim.SetInteger("Speed", 0);
            }
        }

        //Vector3 movement = (transform.position - parent) / Time.deltaTime;
    }
}
