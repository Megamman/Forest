using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRottate : MonoBehaviour
{

    public float speed = 200f;

    void Update()
    {
        mouseDir();
    }

    void mouseDir()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = UnityEngine.Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}
