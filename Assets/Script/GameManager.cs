using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Ref")]
    InventoryPlayer inventoryPlayer;
    PlayerMovement playerMovement;
    StatsPlayer statsPlayer;
    Inventory Inventory;

    [Header("UI")]
    public GameObject menuEsc;
    public GameObject questList;

    public GameObject GameOverMenu;

    [Header("Hp")]
    public int hp = 5;
    public int maxhp = 5;
    public Image[] Hearts;
    bool _isGameOver;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("ItemUse")]
    public bool isFlash;
    public bool isBigFlash;

    [Header("Damage Cooldown")]
    public float damageCooldown;
    private float currentDamageCooldown;

    public Vector2 _playerPosition;

    public AudioSource hitSfx;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        playerMovement = FindFirstObjectByType<PlayerMovement>();
        inventoryPlayer = FindFirstObjectByType<InventoryPlayer>();
        statsPlayer = FindFirstObjectByType<StatsPlayer>();
        Inventory = FindFirstObjectByType<Inventory>();

        GameOverMenu.SetActive(false);

        menuEsc.SetActive(false);
        isFlash = false;
        isBigFlash = false; 

        questList.SetActive(false);
    }

    private void Update()
    {
        HeartsSystem();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuEsc.SetActive(!menuEsc.active);
            if (Time.timeScale != 0)
            {
                Time.timeScale = 0;
            }else
            {
                Time.timeScale = 1;
            }
            
        }

        if (currentDamageCooldown > 0)
        {
            currentDamageCooldown -= Time.deltaTime;
        }



        if (Inventory.currentItem == 1)
        {
            isFlash = true;
            isBigFlash = false;
        }
        else if (Inventory.currentItem == 2)
        {
            isBigFlash = true;
            isFlash = false;
        }
        else 
        {
            isBigFlash = false;
            isFlash = false;
        }


    }

    public void HeartsSystem()
    {
        if (hp > maxhp)
        {
            hp = maxhp;
        }
        if (hp < 0)
        {
            hp = 0;
        }

        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < hp)
            {
                Hearts[i].sprite = fullHeart;
            }
            else
            {
                Hearts[i].sprite = emptyHeart;
            }

            if (i < maxhp)
            {   
                Hearts[i].enabled = true;
            }
            else
            {
                Hearts[i].enabled = false;
            }
        }


        if (hp == 0)
        {
            if (!_isGameOver)
            {
                GameOverMenu.SetActive(true);
                Time.timeScale = 0;
            }
            _isGameOver = true;
        }
    }

    public void QuestAccept()
    {
        questList.SetActive(true);
    }

    public void GetHit(int damage)
    {
        if (currentDamageCooldown > 0) return;

        hp = hp - damage;
        currentDamageCooldown = damageCooldown;
        hitSfx.Play();
        StatsPlayer.Instance.HitDelay();
    }

}
