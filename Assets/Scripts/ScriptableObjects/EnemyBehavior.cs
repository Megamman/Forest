using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom Data/Enemy Behavior", fileName = "New EnemyBehavior")]
public class EnemyBehavior : ScriptableObject
{
    
    public string name;

    [Header("Numbers")]
    // Values of stats to character 
    public int health;
    public float speed = 8f;
    public float noiseAmount;
    public float damage;

    // Attack
    public float timeAttack;
    public float startTimeBtwAttack;
    // If rangeAttack = True
    public float stoppingDist;
    public float retreatDist;

    [Header("Actives")]
    // Use if() statments if true do this, else...
    public bool keepDistance = true;
    public bool meleeAttack = true;
    public bool rangeAttack = true;
    // If agressive = false than there is no need a collider for ditection
    public bool aggressive = true;
    public bool noise = false;

    [Header("Animation")]
    // Set the animations
    public int animIdle = 0;
    public int animMelee = 10;
    public int animRange = 11;

    public void Print()
    {
        Debug.Log(name + "noiseAmount:" + noiseAmount);
    }

}
