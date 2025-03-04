using UnityEngine;

public class PaperPickUp : MonoBehaviour
{
    [Header("Ref")]
    Inventory inventory;

    [Header("Bool")]
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
                switch (x)
                {
                    case 1:
                        inventory.havePaper1 = true;
                        break;
                    case 2:
                        inventory.havePaper2 = true;
                        break;
                    case 3:
                        inventory.havePaper3 = true;
                        break;
                }
                Destroy(this.gameObject);
            }
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
