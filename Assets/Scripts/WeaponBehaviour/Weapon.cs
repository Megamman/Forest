using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public WeaponBehaviour behavior;

    public GameObject wepeon;

    private float timeAttack;

    public Transform attackPos;

    void Start()
    {
        //attackPos = GameObject.FindWithTag("AttackPos").transform;
        timeAttack = 0;
        //Debug.Log(attackPos.position);
    }

    private void Update()
    {
        if (timeAttack <= 0)
        {
            Attack();
        }
        else
        {
            timeAttack -= Time.deltaTime;
        }

    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(wepeon, attackPos.position, transform.rotation);
            timeAttack = behavior.btwAttack;
        }
    }

}