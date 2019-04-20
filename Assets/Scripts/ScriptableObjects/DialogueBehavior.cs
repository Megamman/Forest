using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom Data/Dialogue Behavior", fileName = "New DialogueBehavior")]
public class DialogueBehavior : ScriptableObject
{
    public string Name;

    public Sprite Character;
    public Sprite Background;

    public string Dialogue;
}
