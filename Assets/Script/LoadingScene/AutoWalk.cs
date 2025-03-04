using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWalk : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sprite;

    [Header("State")]
    public int State = 0;
    public enum AnimationState {Walk}

    private void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        State = (int)AnimationState.Walk;
        animator.SetInteger("State", State);
    }
}
