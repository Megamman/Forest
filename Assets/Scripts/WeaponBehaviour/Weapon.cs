using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{

    public WeaponBehaviour behavior;

    public GameObject weapeonSwitch;

    public float timeAttack;

    public Sprite Icon;

    void Start()
    {
        //attackPos = GameObject.FindWithTag("AttackPos").transform;
        timeAttack = 0;
        //Debug.Log(attackPos.position);
    }


    public void Attack()
    {
        if (Input.GetMouseButtonDown(0) && timeAttack <= 0)
        {
            weapeonSwitch.GetComponent<WeaponSwitch>().Attack();
            timeAttack = behavior.btwAttack;
        }
    }

    public void Timer()
    {
        timeAttack -= Time.deltaTime;
    }

}