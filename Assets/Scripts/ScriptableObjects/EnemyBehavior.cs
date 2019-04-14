using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom Data/Enemy Behavior", fileName = "New EnemyBehavior")]
public class EnemyBehavior : ScriptableObject
{
    [Header("World Properties")]
    public float worldSpeed = 5f;
    public bool stayCloseToPlayer = true;

    [Header("Battle Properties")]
    public int damage = 2;
}
