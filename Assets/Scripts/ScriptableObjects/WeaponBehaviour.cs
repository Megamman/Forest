using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom Data/Weapon Behavior", fileName = "New WeaponBehaviour")]
public class WeaponBehaviour : ScriptableObject
{
    [Header("Information")]
    public string name;
    public string description;

    [Header("Numbers")]
    public float damage;
    public float btwAttack;

    /*
    [Header("Position")]
    public Transform attackPos;

    [Header("Weapon")]
    public GameObject weapon;
    */

    // [Header("Visuals")]
    //public GameObject attackMove;

}
