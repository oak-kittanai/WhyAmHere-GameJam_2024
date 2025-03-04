using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Ref")]
    GameManager manager;
    Inventory inventory;

    [Header("Is")]
    public bool isRun;
    public bool isWalk;

    [Header("Audio")]
    // SEffect
    public AudioSource PlayerWalk;
    public AudioSource PlayerRun;
    public AudioSource GetKey;
    public AudioSource DoorOpen;
    public AudioSource Shutter;
    public AudioSource LockerOpen;
    public AudioSource GateOpen;

    // Mob
    public AudioSource Uncle;
    public AudioSource Kid;
    public AudioSource UncleBoss;

    // BG
    public AudioSource BGSound;

    // Car
    public AudioSource CarOut;


    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    private void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();

        if (manager == null)
        {
            GameObject _gameManager = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            manager = _gameManager.GetComponent<GameManager>();
        }
    }

}
