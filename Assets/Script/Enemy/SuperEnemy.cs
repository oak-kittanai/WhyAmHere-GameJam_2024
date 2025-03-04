using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SuperEnemy : MonoBehaviour
{
    [Header("Ref")]
    Inventory inventory;
    GameManager gameManager;
    Animator animator;
    SpriteRenderer sprite;

    public Transform _playerTrasform;
    public GameObject _attackCollider;

    [Header("State")]
    public int State = 0;
    public enum AnimationState { Idle, Walk, Attack }

    [Header("Config")]
    public float moveSpeed;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float delayAttack;

    [Header("Is")]
    public bool playerInRange;

    private void Start()
    {
        if (_playerTrasform == null)
        {
            _playerTrasform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        inventory = FindFirstObjectByType<Inventory>();
        gameManager = FindAnyObjectByType<GameManager>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (inventory.LastQuest == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, _playerTrasform.position, moveSpeed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, _playerTrasform.transform.position) < _attackRadius)
        {
            if (StatsPlayer.Instance.isHidden == false)
            {
                playerInRange = true;
            }
        }
        if (Vector2.Distance(transform.position, _playerTrasform.transform.position) > _attackRadius)
        {
            playerInRange = false;
            State = (int)AnimationState.Walk;
            _attackCollider.SetActive(false);
        }

        if (playerInRange == true)
        {
            StartCoroutine(AttackDelay());
        }

        animator.SetInteger("State", State);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }

    #region DelayZone

    IEnumerator AttackDelay()
    {
        State = (int)AnimationState.Attack;
        _attackCollider.SetActive(true);
        yield return new WaitForSeconds(2f);
    }

    #endregion

}
