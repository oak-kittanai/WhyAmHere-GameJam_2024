using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Ref")]
    public SpriteRenderer sRender;
    public Sprite DoorOpen;
    public Sprite DoorClose;

    public GameObject Player;

    [Header("transiton")]
    public Animator transiton;
    public float transitonTime = 1f;

    [Header("Is")]
    public bool playerInRange;

    [Header("Teleporter")]
    public Vector2 playerPos;

    void Update()
    {
        if (playerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.transform.position = playerPos;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sRender.sprite = DoorOpen;
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
