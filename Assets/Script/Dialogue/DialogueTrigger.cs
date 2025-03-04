using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueCharacter
{
    public string name;
    public Texture icon;
}

[Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    public string line;
}

[Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ref")]
    public GameObject Dialogue;

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Dialogue.SetActive(true);
            TriggerDialogue();
            Destroy(gameObject);
        }
    }
}
