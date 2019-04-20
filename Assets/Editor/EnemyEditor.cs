using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Enemy), true)]
public class EnemyEditor : Editor
{
    private void OnSceneGUI()
    {
        Enemy enemy = target as Enemy;
        EnemyBehavior behavior = enemy.behavior;

        // if no behavior on script, stop here.
        if (behavior == null) return;

        Handles.color = Color.blue;
        Handles.DrawWireDisc(enemy.transform.position, Vector3.forward, behavior.stoppingDist);
        
        Handles.color = Color.red;
        Handles.DrawWireDisc(enemy.transform.position, Vector3.forward, behavior.retreatDist);

        Handles.color = Color.green;
        Handles.DrawWireDisc(enemy.transform.position, Vector3.forward, behavior.detectDist);
    }
}
