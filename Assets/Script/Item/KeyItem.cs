using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    [Header("Ref")]
    Inventory inventory;

    [Header("Is")]
    public bool playerInRange;

    [Header("Is")]
    public int x;

    private void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
    }

    private void Update()
    {
        if (playerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inventory.GetKey(x);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
    }
}
