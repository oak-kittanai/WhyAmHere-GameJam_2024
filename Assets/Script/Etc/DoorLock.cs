using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorLock : MonoBehaviour
{
    [Header("Ref")]
    public SpriteRenderer sRender;
    public Sprite DoorOpen;
    public Sprite DoorClose;
    Inventory inventory;

    public Sprite DoorUnlock;

    public GameObject Player;

    public GameObject lockedMess;

    [Header("transiton")]
    public Animator transiton;
    public float transitonTime = 1f;

    [Header("Is")]
    public bool playerInRange;

    public bool isThisEventDoor;
    public bool isEventTrigger;
    public bool freeToGo;

    [Header("Teleporter")]
    public Vector2 playerPos;

    private void Start()
    {
        inventory=FindFirstObjectByType<Inventory>();

        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
        DoorConfigUpdate();
    }

    void DoorConfigUpdate()
    {
        // Event Door Trigger
        if (isThisEventDoor)
        {
            if (isEventTrigger == true)
            {
                if (playerInRange == true)
                {
                    if (Input.GetKeyDown(KeyCode.E) && inventory.haveKey1 == true)
                    {
                        Player.transform.position = playerPos;
                    }
                }
            }
            else if (isEventTrigger == false)
            {
                if (playerInRange == true)
                {
                    if (Input.GetKeyDown(KeyCode.E) && inventory.haveKey1 == true)
                    {
                        lockedMess.SetActive(true);
                        StartCoroutine(DelayClose());
                    }
                }
            }

            // Nomal Door
            if (isEventTrigger)
            {
                sRender.sprite = DoorUnlock;
            }
        }
        
        if (freeToGo == true)
        {
            if (playerInRange == true)
            {
                if (Input.GetKeyDown(KeyCode.E) && inventory.haveKey1 == true)
                {
                    AudioManager.instance.GateOpen.Play();

                    Player.transform.position = playerPos;
                }
            }
        }
 
    }

    IEnumerator DelayClose()
    {
        yield return new WaitForSeconds(2);
        lockedMess.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (inventory.haveKey1 == true)
            {
                sRender.sprite = DoorOpen;
            }
            else sRender.sprite = DoorClose;
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sRender.sprite = DoorClose;
            playerInRange = false;
        }
    }
}
