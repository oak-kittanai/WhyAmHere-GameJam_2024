using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Ref")]
    GameManager manager;
    InventoryPlayer inventoryPlayer;
    StatsPlayer stats;
    Inventory inventory;

    public SpriteRenderer sprite;
    Animator animator;
    Rigidbody2D rb;
    
    [Header("Movement")]
    public float speed;
    public float nSpeed;
    public float runSpeed;
    public Vector2 Direction = Vector2.zero;

    [Header("Is")]
    public bool isShutter;
    public bool isFlash;

    [Header("Shutter")]
    public bool isDoShutter;
    public GameObject collAtt;

    [Header("State")]
    public int State = 0;
    public enum AnimationState { Idle, Walk, Run, PutupFlash, IdleFlash, WalkFlash, RunFlash, PutupBigFlash, Shutter, ShutterFlash }

    

    private void Start()
    {
        isShutter = true;
        isFlash = false;

        inventory = FindFirstObjectByType<Inventory>();
        rb = GetComponent<Rigidbody2D>();
        inventoryPlayer = FindFirstObjectByType<InventoryPlayer>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        stats = FindFirstObjectByType<StatsPlayer>();

        if (manager == null)
        {
            GameObject _gameManager = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            manager = _gameManager.GetComponent<GameManager>();
        }
    }

    private void Update()
    {
        if (isDoShutter == true)
        {
            ShutterAttackSystem();
        }
        if (isDoShutter == false)
        {
            collAtt.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        float x, y;
        x = Input.GetAxis("Horizontal");
        y = 0f;

        Direction = new Vector2(x, y);

        Vector2 moveDirection = Direction * speed * Time.deltaTime;

        transform.Translate(moveDirection);

        if (isFlash == false)
        {
            NomalCharacter();
            inventoryPlayer.flashLightRight.SetActive(false);
            inventoryPlayer.flashLightLeft.SetActive(false);
        }

        if ( isFlash == true && stats.isHidden == false)
        {
            CharacterWithFlash();
        }
    }

    public void ShutterAttackSystem()
    {
        AudioManager.instance.Shutter.Play();
        collAtt.SetActive(true);
        StartCoroutine(WaitForShutter());
    }

    public void NomalCharacter()
    {
        if (Direction.x > 0 && stats.isRunning == true)
        {
            sprite.flipX = true;
            State = (int)AnimationState.Run;
        }
        else if (Direction.x < 0 && stats.isRunning == true)
        {
            sprite.flipX = false;
            State = (int)AnimationState.Run;
        }
        else if (Direction.x > 0)
        {
            sprite.flipX = true;
            State = (int)AnimationState.Walk;
        }
        else if (Direction.x < 0)
        {
            sprite.flipX = false;
            State = (int)AnimationState.Walk;
        }
        else
        {
            State = (int)AnimationState.Idle;
        }

        if (Direction.x < 0 || Direction.x > 0)
        {
            if (!AudioManager.instance.PlayerWalk.isPlaying)
            {
                AudioManager.instance.PlayerWalk.Play();
            }
        }
        else { AudioManager.instance.PlayerWalk.Stop(); }

        if (Direction.x < 0 && stats.isRunning == true || Direction.x > 0 && stats.isRunning == true)
        {
            if (!AudioManager.instance.PlayerRun.isPlaying)
            {
                AudioManager.instance.PlayerRun.Play();
            }
        }
        else { AudioManager.instance.PlayerRun.Stop(); }


        if (Input.GetKeyDown(KeyCode.F) && isShutter == true)
        {
            State = (int)AnimationState.Shutter;
            isDoShutter = true;
        }
        

        animator.SetInteger("State", State);
    }

    public void CharacterWithFlash()
    {
        if (Direction.x > 0 && stats.isRunning == true)
        {
            sprite.flipX = true;
            State = (int)AnimationState.RunFlash;
            inventoryPlayer.flashLightRight.SetActive(true);
            inventoryPlayer.flashLightLeft.SetActive(false);
        }
        else if (Direction.x < 0 && stats.isRunning == true)
        {
            sprite.flipX = false;
            State = (int)AnimationState.RunFlash;
            inventoryPlayer.flashLightRight.SetActive(false);
            inventoryPlayer.flashLightLeft.SetActive(true);
        }
        else if (Direction.x > 0)
        {
            sprite.flipX = true;
            State = (int)AnimationState.WalkFlash;
            inventoryPlayer.flashLightRight.SetActive(true);
            inventoryPlayer.flashLightLeft.SetActive(false);
        }
        else if (Direction.x < 0)
        {
            sprite.flipX = false;
            State = (int)AnimationState.WalkFlash;
            inventoryPlayer.flashLightRight.SetActive(false);
            inventoryPlayer.flashLightLeft.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.F) && isShutter == true)
        {
            State = (int)AnimationState.ShutterFlash;
            isDoShutter = true;
        }
        else
        {
            State = (int)AnimationState.IdleFlash;
        }

        animator.SetInteger("State", State);
    }

    IEnumerator WaitForShutter()
    {
        yield return new WaitForSeconds(1f);
        isDoShutter = false;
    }
}
