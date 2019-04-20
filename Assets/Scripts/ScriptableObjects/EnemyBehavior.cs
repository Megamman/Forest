using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom Data/Enemy Behavior", fileName = "New EnemyBehavior")]
public class EnemyBehavior : ScriptableObject
{
    [Header("Information")]
    public string name;

    [Header("Numbers")]
    // Values of stats to character 
    public int health;
    public float speed = 8f;
    public float damage;

    // Attack
    public float startTimeBtwAttack;

    [Header("Distince")]
    public float detectDist;
    public float stoppingDist;

    [SerializeField]
    private float _retreatDiff;

    public float retreatDist
    {
        get
        {
            return stoppingDist - _retreatDiff;
        }
    }

    [Header("Other")]
    public float noiseAmount;

    [Header("Actives")]
    // Use if() statments if true do this, else...
    public bool meleeAttack = true;
    public bool rangeAttack = true;
    // If agressive = false than there is no need a collider for ditection
    public bool noise = false;

    public void Print()
    {
        Debug.Log(name + "noiseAmount:" + noiseAmount);
    }

}
