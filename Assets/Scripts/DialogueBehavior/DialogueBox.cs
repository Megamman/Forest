using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{ 
    public DialogueBehavior behavior;

    public Image Character;
    public Image Background;

    public Text Name;
    public Text Dialogue;

    // Start is called before the first frame update
    void Start()
    {
        Name.text = behavior.Name.ToString();

        Character.sprite = behavior.Character;

        Background.sprite = behavior.Background;

        Dialogue.text = behavior.Dialogue.ToString();

    }
}
