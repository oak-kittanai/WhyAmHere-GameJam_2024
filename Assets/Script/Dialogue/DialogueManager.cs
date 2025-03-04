using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Ref")]
    public GameObject DiaLog; // should spacebar 20 time after vap

    public static DialogueManager Instance;

    public RawImage CharacterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    [SerializeField] private Queue<DialogueLine> lines = new Queue<DialogueLine> { };

    public bool isDialogueActive = false;

    public float typeSpeed = 0.2f;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;

        lines.Clear();  

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisPlayNextDialogueLine();
    }

    public void DisPlayNextDialogueLine()
    {
        if (lines.Count == 0) 
        {
            StartCoroutine(TimeAfterEnd());
            return;

        }

        DialogueLine currentLine = lines.Dequeue();

        CharacterIcon.texture = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StartCoroutine(TypeSentence(currentLine)); 

        float typingTime = currentLine.line.Length * typeSpeed;

        StartCoroutine(WaitAndDisplayNextDialogueLine(typingTime));
    }

private IEnumerator WaitAndDisplayNextDialogueLine(float waitTime)
{
    yield return new WaitForSeconds(waitTime);
    DisPlayNextDialogueLine();
}

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
    }

    IEnumerator TimeAfterEnd()
    {
        yield return new WaitForSeconds(6f);
        DiaLog.SetActive(false);
        EndDialogue();
    }
}




