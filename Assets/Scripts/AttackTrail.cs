using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrail : MonoBehaviour
{

    public GameObject[] waypoints;
    int cur = 0;
    public float speed;
    float WPradius = -1;

    void FixedUpdate()
    {
        // Waypoint not reached yet? then move closer
        if (Vector2.Distance(waypoints[cur].transform.position, transform.position) < WPradius)
        {
            cur++;
            if (cur >= waypoints.Length)
            {
                cur = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[cur].transform.position, Time.deltaTime * speed);

        Destroy(gameObject, 0.2f);

    }
}
