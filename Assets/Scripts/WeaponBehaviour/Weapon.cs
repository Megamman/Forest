using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public WeaponBehaviour behavior;

    public GameObject weapon;

    public float timeAttack;

    public Transform attackPos;

    public bool activeAttack = false;

    void Start()
    {
        //attackPos = GameObject.FindWithTag("AttackPos").transform;
        timeAttack = 0;
        //Debug.Log(attackPos.position);
    }

    public void Timer()
    {
        timeAttack -= Time.deltaTime;
    }

    public void Attack()
    {
        if (timeAttack <= 0)
        {
            activeAttack = true;
            Instantiate(weapon, attackPos.position, Quaternion.identity);
        }
        else
        {   
            activeAttack = false;
        }

        if (activeAttack)
        {
            timeAttack = behavior.btwAttack;
        }
        
    }

}