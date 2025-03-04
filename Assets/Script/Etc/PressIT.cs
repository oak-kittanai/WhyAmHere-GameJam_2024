using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PressIT : MonoBehaviour
{
    [Header("Ref")]
    public GameObject ButtonE;
    public GameObject missKey;
    Inventory inventory;
    GameManager manager;

    [Header("Is")]
    public bool playerInRange;
    public bool isMissKey;

    private void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();

        if (manager == null)
        {
            GameObject _gameManager = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            manager = _gameManager.GetComponent<GameManager>();
        }
    }

    private void Update()
    {
        if (playerInRange == true)
        {
            ButtonE.SetActive(true);
        }
        if (playerInRange == false)
        {
            ButtonE.SetActive(false);
        }

        if (isMissKey == true)
        {
            missKey.SetActive(true);
        }
        if (isMissKey == false)
        {
            missKey.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key 1")
        {
            playerInRange = true;
        }
        if (collision.gameObject.tag == "Key 2")
        {
            playerInRange = true;
        }
        if (collision.gameObject.tag == "Interact")
        {
            playerInRange = true;
        }
        if (collision.gameObject.tag == "Hidable")
        {
            playerInRange = true;
        }
        if (collision.gameObject.tag == "Stair" && inventory.haveKey2 == false)
        {
            isMissKey = true;
        }
        if (collision.gameObject.tag == "Stair" && inventory.haveKey2 == true && inventory.currentKey == 2 && inventory.currentItem == 3)
        {
            playerInRange = true;
        }
        if (collision.gameObject.tag == "ExitZone")
        {
            playerInRange = true;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key 1")
        {
            playerInRange = true;
        }
        if (collision.gameObject.tag == "Key 2")
        {
            playerInRange = true;
        }
        if (collision.gameObject.tag == "Interact")
        {
            playerInRange = true;
        }
        if (collision.gameObject.tag == "Hidable")
        {
            playerInRange = true;
        }
        if (collision.gameObject.tag == "Stair" && inventory.haveKey2 == false)
        {
            isMissKey = true;
        }
        if (collision.gameObject.tag == "Stair" && inventory.haveKey2 == true && inventory.currentKey == 2 && inventory.currentItem == 3)
        {
            playerInRange = true;
        }
        if (collision.gameObject.tag == "ExitZone")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key 1")
        {
            playerInRange = false;
        }
        if (collision.gameObject.tag == "Key 2")
        {
            playerInRange = false;
        }
        if (collision.gameObject.tag == "Interact")
        {
            playerInRange = false;
        }
        if (collision.gameObject.tag == "Hidable")
        {
            playerInRange = false;
        }
        if (collision.gameObject.tag == "Stair" && inventory.haveKey2 == false)
        {
            isMissKey = false;
        }
        if (collision.gameObject.tag == "Stair" && inventory.haveKey2 == true && inventory.currentKey == 2 && inventory.currentItem == 3)
        {
            playerInRange = false;
        }
        if (collision.gameObject.tag == "ExitZone")
        {
            playerInRange = false;
        }
    }
}
