using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDemage : MonoBehaviour
{
    public EnemyBehavior behavior;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().TakeDamage((int) behavior.damage);
            Debug.Log("It hearts");
        }
    }

}
