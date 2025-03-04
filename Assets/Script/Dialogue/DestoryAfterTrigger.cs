using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryAfterTrigger : MonoBehaviour
{
    [Header("Ref")]
    public GameObject Dialogue;

    public Dialogue dialogue;

    [Header("Setting")]
    public GameObject _mob;
    public float _timer;
    [SerializeField] private bool _questEvent;
    public bool QuestEventCharacter;

    bool _isPlayer;

    private void Start()
    {
        if (Dialogue == null)
        {
            Dialogue = GameObject.FindGameObjectWithTag("SupChat");
        }

    }
    private void Update()
    {
        if (_questEvent == true)
        {
            GameManager.Instance.QuestAccept();
        }
    }

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isPlayer)
        {
            if (collision.gameObject.tag == "Player")
            {
                Dialogue.SetActive(true);
                TriggerDialogue();
                if (DialogueManager.Instance.isDialogueActive == true)
                {
                    StartCoroutine(DestoryAfter());
                }
                _isPlayer = true;
            }
        }

    }

    IEnumerator DestoryAfter()
    {
        if (QuestEventCharacter == true)
        {
            _questEvent = true;
        }
        yield return new WaitForSeconds(_timer);
        _mob.SetActive(false);
    }
}
