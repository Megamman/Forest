using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public GameObject In;
    public GameObject Out;

    public float speed;

    public void moveIn()
    {
        transform.position = Vector2.MoveTowards(transform.position, In.transform.position, Time.deltaTime * speed);
    }

    public void moveOut()
    {
        transform.position = Vector2.MoveTowards(transform.position, Out.transform.position, Time.deltaTime * speed);
    }
}
