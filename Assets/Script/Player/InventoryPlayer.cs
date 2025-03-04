using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayer : MonoBehaviour
{
    [Header("Ref")]
    GameManager manager;
    StatsPlayer stats;
    PlayerMovement player;
    Inventory inventory;

    [Header("Light")]
    public GameObject flashLightRight;
    public GameObject flashLightLeft;

    void Start()
    {
        flashLightRight.SetActive(false);
        flashLightLeft.SetActive(false);

        if (manager == null)
        {
            GameObject _gameManager = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            manager = _gameManager.GetComponent<GameManager>();
        }

        inventory = FindFirstObjectByType<Inventory>();
        stats = FindFirstObjectByType<StatsPlayer>();
        player = FindFirstObjectByType<PlayerMovement>();
    }

    void Update()
    {
        if (inventory.currentItem == 1 && inventory.haveFlash)
        {
            player.isFlash = true;
        }
        else if (inventory.currentItem == 1)
        {
            player.isFlash = false;
        }

        if (inventory.currentItem == 2)
        {
            player.isFlash = false;
        }

        if (inventory.currentItem == 3)
        {
            player.isFlash = false;
        }
    }
}
