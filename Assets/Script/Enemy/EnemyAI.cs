using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class EnemyAI : MonoBehaviour
{
    [Header("Ref")]
    GameManager manager;
    Animator animator;
    SpriteRenderer sprite;

    [Header("Properties")]
    public GameObject player;
    public float speed;
    public float distanceBetween;

    public float distance;

    [Header("Hp")]
    public int hp = 0;
    public int maxhp = 50;

    [Header("State")]
    public int State = 0;
    public enum AnimationState { Idle, Walk, Attack }

    [Header("Is")]
    public bool isBossDead;


    private void Start()
    {
        isBossDead = false;
        animator = GetComponent<Animator>();

        if (manager == null)
        {
            GameObject _gameManager = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            manager = _gameManager.GetComponent<GameManager>();
        }
        hp = maxhp;
    }

    private void Update()
    {
        if (hp > maxhp)
        {
            hp = maxhp;
        }

        if (hp < 0)
        {
            hp = 0;
        }

        if (hp == 0)
        {
            
            isBossDead = true;
            this.gameObject.SetActive(false);
        }



        State = (int)AnimationState.Idle;

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance <  distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            State = (int)AnimationState.Walk;
        }

        if (distance <= 2)
        {
            AttackPlayer();
        }

        animator.SetInteger("State", State);
    }

    void AttackPlayer()
    {
        manager.GetHit(5);

        State = (int)AnimationState.Attack;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HolyAttack")
        {
            GetDmgOnBoss(50);
        }
    }

    public void GetDmgOnBoss(int getDamage)
    {
        hp = hp - getDamage;
    }

}
