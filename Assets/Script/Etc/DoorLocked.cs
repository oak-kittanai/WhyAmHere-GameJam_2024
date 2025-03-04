using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLocked : MonoBehaviour
{
    [Header("Ref")]
    GameManager manager;
    Inventory inventory;

    public SpriteRenderer sRender;
    public Sprite StairOpen;

    public GameObject Player;

    [Header("Is")]
    public bool isLocked;
    public bool isUnLock;
    public bool playerInRange;

    [Header("Teleporter")]
    public Vector2 playerPos;

    private void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();

        if (manager == null)
        {
            GameObject _gameManager = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            manager = _gameManager.GetComponent<GameManager>();
        }
    }

    private void Update()
    {
        if (isUnLock == true && playerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.transform.position = playerPos;
            }
        }

        if ( isLocked == true && playerInRange == true && inventory.currentItem == 3 && inventory.currentKey == 2 && inventory.haveKey2 == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isUnLock = true;
            }
        }

        if (isUnLock == true)
        {
            sRender.sprite = StairOpen;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
