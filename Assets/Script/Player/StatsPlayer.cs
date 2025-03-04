using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour
{
    public static StatsPlayer Instance;

    [Header("Ref")]
    AudioManager _audioManager;
    GameManager manager;
    InventoryPlayer inventoryPlayer;
    PlayerMovement player;
    Inventory inventory;
    Collider2D selfColl;
    Rigidbody2D selfRB;

    [Header("Stats")]
    public float stamina = 50;
    public float maxStamina = 50;
    private float hideSpeed = 0;
    private float nomalSpeed = 4;

    [Header("Run")]
    public bool isRun;
    public bool isRunning;
    [Header("Stamina")]
    public bool isStamina;
    public bool isReSta;
    public bool isSmallReSta;
    public Slider staminaBar;

    [Header("Hide")]
    public bool isHidAble;
    public bool isHide;
    public bool isHidden;

    private void Start()
    {
        isStamina = false;
        isRun = false;
        isRunning = false;
        isSmallReSta = false;

        if (Instance == null)
        {
            Instance = this;
        }

        if (manager == null)
        {
            GameObject _gameManager = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            manager = _gameManager.GetComponent<GameManager>();
        }
        if (selfColl == null)
        {
            selfColl = GetComponent<Collider2D>();
        }

        selfRB = GetComponent<Rigidbody2D>();
        inventory = FindFirstObjectByType<Inventory>();
        inventoryPlayer = FindFirstObjectByType<InventoryPlayer>();
        player = FindFirstObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        HealthAndStaminaSystem();
        RunSystem();

        if (isRun == true)
        {
            if (Input.GetKey(KeyCode.LeftShift) && player.Direction.x != 0)
            {
                stamina -= 5 * Time.deltaTime;
                isRunning = true;
            }
            else
            {
                isRunning = false;
            }
        }
        
        HideSystem();
        UpdateStaminaBar();
    }

    public void HideSystem()
    {
        if (isHidAble == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && isHidden == false)
            {
                AudioManager.instance.LockerOpen.Play();
                inventoryPlayer.flashLightRight.SetActive(false);
                inventoryPlayer.flashLightLeft.SetActive(false);
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
                player.sprite.enabled = false;
                isRun = false;
                player.isFlash = false;
                player.isShutter = false;
                selfColl.isTrigger = true;
                selfRB.constraints = RigidbodyConstraints2D.FreezePositionY;


                player.speed = hideSpeed;
            }
            if (isHidden == false)
            {
                selfColl.enabled = true;
                player.sprite.enabled = true;
                isRun = true;
                player.isShutter = true;
                player.speed = nomalSpeed;
                selfRB.constraints = RigidbodyConstraints2D.None;
                selfColl.isTrigger = false;
            }
        }
    }

    public void HealthAndStaminaSystem()
    {
        // Stamina
        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }
        if (stamina < 0)
        {
            stamina = 0;
        }
    }

    public void RunSystem()
    {
        // Can Run
        if (isReSta == true)
        {
            isRun = false;
            stamina += 2 * Time.deltaTime;
            isRunning = false;
        }
        if (isSmallReSta == true)
        {
            stamina += 1 * Time.deltaTime;
        }
        if (stamina >= 50)
        {
            isStamina = true;
            isReSta = false;
        }

        if (isStamina == true)
        {
            isRun = true;
        }
        if (stamina <= 1)
        {
            isReSta = true;
            isStamina = false;
        }

        if (isRunning == true)
        {
            player.speed = player.runSpeed;
        }
        if (isRunning == false)
        {
            isSmallReSta = true;
            player.speed = player.nSpeed;
        }
    }

    void UpdateStaminaBar()
    {
        staminaBar.value = stamina;
    }

    public void HitDelay()
    {
        StartCoroutine(GetHitDelay());
    }
    
    IEnumerator GetHitDelay()
    {
        selfColl.isTrigger = true;
        selfRB.constraints = RigidbodyConstraints2D.FreezePositionY;
        yield return new WaitForSeconds(2f);
        selfRB.constraints = RigidbodyConstraints2D.None;
        selfColl.isTrigger = false;
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
}
