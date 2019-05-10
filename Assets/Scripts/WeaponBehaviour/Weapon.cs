using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    public WeaponBehaviour behavior;

    public float timeAttack;

    public Sprite Icon;

    void Start()
    {
        //attackPos = GameObject.FindWithTag("AttackPos").transform;
        timeAttack = 0;
        //Debug.Log(attackPos.position);
    }


    public void Attack(WeaponSwitch ws)
    {
        if (timeAttack <= 0)
        {
            ws.Attack();
            timeAttack = behavior.btwAttack;
        }
    }

    public void Timer()
    {
        timeAttack -= Time.deltaTime;
    }

}