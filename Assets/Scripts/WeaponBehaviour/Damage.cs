using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public WeaponBehaviour behavior;
    

    void Start()
    {
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(behavior.damage);
            Debug.Log("That's a lot of Damage");
        }

    }
}
