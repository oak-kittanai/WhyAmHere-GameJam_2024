using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Item")]
    public bool haveFlash;
    public bool haveBigFlash;

    [Header("Key")]
    public bool haveKey1;
    public bool haveKey2;

    public bool isKey1;
    public bool isKey2;

    [Header("Paper")]
    public bool havePaper1;
    public bool havePaper2;
    public bool havePaper3;
    public bool havePaper4;
    public bool havePaper5;
    public bool havePaper6;

    [Header("InUse")]
    public int currentItem = 0;
    public enum Item { None, Flash, BigFlash, Key }

    public int currentKey = 0;
    public enum Key { None, Key1, Key2};

    [Header("ShowUI")]
    public RawImage Item1, Item2, Item3;
    public GameObject intory;

    private void Start()
    {
        // Item
        haveFlash = true;

        // Key
        haveKey1 = false;
        haveKey2 = false;

        isKey1 = false;
        isKey2 = false;

        //Paper
        havePaper1 = false;
        havePaper2 = false;
        havePaper3 = false;
        havePaper4 = false;
        havePaper5 = false;
        havePaper6 = false;
    }

    private void Update()
    {
        SwitchItem();

        if (Input.GetKeyDown(KeyCode.I))
        {
            intory.SetActive(!intory.active);
        }

        if (currentItem == 2)
        {
            if (currentKey == 0)
            {
                isKey1 = false;
                isKey2 = false;
            }
            if (currentKey == 1)
            {
                isKey1 = true;
                isKey2 = false;
            }
            if (currentKey == 2)
            {
                isKey1 = false;
                isKey2 = true;
            }
        }

    }

    void SwitchItem()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentItem = (int)Item.Flash;
            Item1.color = Color.red;
            Item2.color = Color.white;
            Item3.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentItem = (int)Item.BigFlash;
            Item1.color = Color.white;
            Item2.color = Color.red;
            Item3.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentItem = (int)Item.Key;
            Item1.color = Color.white;
            Item2.color = Color.white;
            Item3.color = Color.red;
        }
    }

    public void ChangeKey1()
    {
        currentKey = (int)Key.Key1;
    }
    public void ChangeKey2()
    {
        currentKey = (int)Key.Key2;
    }

    public void GetKey(int x)
    {
        if (x == 1)
        {
            haveKey1 = true;
        }
        if (x == 2)
        {
            haveKey2 = true;
        }
    }
}
