using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManager : MonoBehaviour
{
    [Header("Ref")]
    PlayerController player;
    Inventory Inventory;

    [Header("UI")]
    public GameObject menuEsc;

    [Header("Hp")]
    public int hp = 5;
    public int maxhp = 5;
    public Image[] Hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("ItemUse")]
    public bool isFlash;
    public bool isBigFlash;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        Inventory = FindFirstObjectByType<Inventory>();

        menuEsc.SetActive(false);
        isFlash = false;
        isBigFlash = false;
    }

    private void Update()
    {
        HeartsSystem();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuEsc.SetActive(!menuEsc.active);
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
    }

    public void GetHit()
    {
        hp = hp - 1;
    }

    
}
