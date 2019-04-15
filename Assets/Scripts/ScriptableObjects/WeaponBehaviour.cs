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
    public float speed;
    public float timeAttack;

    [Header("Visuals")]
    public GameObject attackMove;

}
