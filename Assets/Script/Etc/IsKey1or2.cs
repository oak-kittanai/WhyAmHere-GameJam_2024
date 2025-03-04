using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Inventory;

public class IsKey1or2 : MonoBehaviour
{
    Inventory inventory;

    public GameObject Key1;
    public GameObject Key2;

    public bool isKey1;
    public bool isKey2;

    private void Start()
    {
        Key1.SetActive(false);
        Key2.SetActive(false);
        inventory = FindAnyObjectByType<Inventory>();
    }

    private void Update()
    {
        if (inventory.currentKey == 1 && inventory.haveKey1 == true)
        {
            Key1.SetActive(true);
        }

        if (inventory.currentKey == 2 && inventory.haveKey2 == true)
        {
            Key2.SetActive(true);
        }
    }


}
