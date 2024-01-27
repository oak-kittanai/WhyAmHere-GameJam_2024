using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Ref")]
    GameManager manager;
    Inventory inventory;
    SpriteRenderer sprite;
    Animator animator;

    [Header("Stats")]
    public float Stamina = 50;
    public float MaxStamina = 50;

    [Header("Movement")]
    public float speed;

    public Rigidbody2D rb;
    Vector2 Direction = Vector2.zero;

    [Header("Hide")]
    public bool isHidAble;
    public bool isHide;
    public bool isHidden;

    [Header("Is")]
    public bool isShutter;
    public bool isBigFlash;
    public bool isFlash;
    [Header("Run")]
    public bool isRun;
    public bool isRunning;
    [Header("Stamina")] 
    public bool isStamina;
    public bool isReSta;
    public bool isSmallReSta;
    public Slider staminaBar;

    [Header("State")]
    public int State = 0;
    public enum AnimationState { Idle, Walk, Run, PutupFlash, IdleFlash, WalkFlash, RunFlash, PutupBigFlash, Shutter, ShutterFlash }

    [Header("Light")]
    public GameObject flashLightRight;
    public GameObject flashLightLeft;


    private void Start()
    {
        isStamina = false;
        isRun = false;
        isRunning = false;
        isShutter = true;
        isBigFlash = false;
        isFlash = false;
        isSmallReSta = false;

        flashLightRight.SetActive(false);
        flashLightLeft.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
        inventory = FindFirstObjectByType<Inventory>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        if (manager == null)
        {
            GameObject _gameManager = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            manager = _gameManager.GetComponent<GameManager>();
        }
    }

    private void Update()
    {
        UpdateStaminaBar();

        // Stamina
        if (Stamina > MaxStamina)
        {
            Stamina = MaxStamina;
        }
        if (Stamina < 0)
        {
            Stamina = 0;
        }

        // Can Run
        if (isReSta == true)
        {
            isRun = false;
            Stamina += 2 * Time.deltaTime;
            isRunning = false;
        }
        if (isSmallReSta == true)
        {
            Stamina += 1 * Time.deltaTime;
        }
        if (Stamina >= 50)
        {
            isStamina = true;
            isReSta = false;
        }

        if (isStamina == true)
        {
            isRun = true;
        }
        if (Stamina <= 1)
        {
            isReSta = true;
            isStamina = false;
        }
        if (isRun == true)
        {
            if (Input.GetKey(KeyCode.LeftShift) && Direction.x != 0)
            {
                Stamina -= 5 * Time.deltaTime;
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }
        }

        if (isRunning == true)
        {
            speed = 6;
        }
        if (isRunning == false)
        {
            isSmallReSta = true;
            speed = 4;
        }

        // Hide 
        if (isHidAble == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && isHidden == false)
            {
                flashLightRight.SetActive(false);
                flashLightLeft.SetActive(false);
                isHidden = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && isHidden == true)
            {
                isHidden = false;
            }
        }

        if (isHidAble == true)
        {
            if (isHidden == true)
            {
                this.sprite.enabled = false;
                isRun = false;
                isFlash = false;
                isShutter = false;
                speed = 0;
            }
            if (isHidden == false)
            {
                this.sprite.enabled = true;
                isRun = true;
                isFlash = true;
                isShutter = true;
                speed = 4;
            }
        }
        
        // Current Item Use

        if (inventory.currentItem == 1 && inventory.haveFlash)
        {
            isBigFlash = false;
            isFlash = true;
        }
        else if (inventory.currentItem == 1)
        {
            isBigFlash = false;
            isFlash = false;
        }
        

        if (inventory.currentItem == 2)
        {
            isBigFlash = false;
            isFlash = false;
        }
        else if (inventory.currentItem == 2 && inventory.haveBigFlash)
        {
            isBigFlash = true;
            isFlash = false;
        }

        if (inventory.currentItem == 3)
        {
            isBigFlash = false;
            isFlash = false;
        }

    }

    public void FixedUpdate()
    {
        float x, y;
        x = Input.GetAxis("Horizontal");
        y = 0f;

        Direction = new Vector2(x, y);

        Vector2 moveDirection = Direction * speed * Time.deltaTime;

        transform.Translate(moveDirection);

        if (isBigFlash == false && isFlash == false)
        {
            NomalCharacter();
            flashLightRight.SetActive(false);
            flashLightLeft.SetActive(false);
        }

        if (isBigFlash == false && isFlash == true && isHidden == false)
        {
            CharacterWithFlash();
        }

        if (isBigFlash == true && isFlash == false)
        {
            CharacterWithBigFlash();
        }

    }

    public void NomalCharacter()
    {
        if (Direction.x > 0 && isRunning == true)
        {
            sprite.flipX = true;
            State = (int)AnimationState.Run;
        }
        else if (Direction.x < 0 && isRunning == true)
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
        else if (Input.GetKeyDown(KeyCode.F) && isShutter == true)
        {
            State = (int)AnimationState.Shutter;
        }
        else
        {
            State = (int)AnimationState.Idle;
        }

        animator.SetInteger("State", State);
    }

    public void CharacterWithFlash()
    {
        if (Direction.x > 0 && isRunning == true)
        {
            flashLightRight.SetActive(true);
            flashLightLeft.SetActive(false);
            sprite.flipX = true;
            State = (int)AnimationState.RunFlash;
        }
        else if (Direction.x < 0 && isRunning == true)  
        {
            flashLightRight.SetActive(false);
            flashLightLeft.SetActive(true);
            sprite.flipX = false;
            State = (int)AnimationState.RunFlash;
        }
        else if (Direction.x > 0)
        {
            flashLightRight.SetActive(true);
            flashLightLeft.SetActive(false);
            sprite.flipX = true;
            State = (int)AnimationState.WalkFlash;
        }
        else if (Direction.x < 0)
        {
            flashLightRight.SetActive(false);
            flashLightLeft.SetActive(true);
            sprite.flipX = false;
            State = (int)AnimationState.WalkFlash;
        }
        else if (Input.GetKeyDown(KeyCode.F) && isShutter == true )
        {
            State = (int)AnimationState.ShutterFlash;
        }
        else
        {
            State = (int)AnimationState.IdleFlash;
        }

        animator.SetInteger("State", State);
    }


    // still big flash ?
    public void CharacterWithBigFlash()
    {

        animator.SetInteger("State", State);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hidable")
        {
            isHidAble = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hidable")
        {
            isHidAble = false;
        }
    }

    void UpdateStaminaBar()
    {
        staminaBar.value = Stamina;
    }


}
