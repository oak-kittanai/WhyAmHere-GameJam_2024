using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Ref")]
    FlashLight flash;

    [SerializeField] private TMP_Text _paperQuestText;
    [SerializeField] private TMP_Text _keyQuesText;
    [SerializeField] private TMP_Text _entranceText;

    [Header("Item")]
    public bool haveFlash;
    public bool haveBigFlash;

    [SerializeField] private int _paperQuantity;

    public int Battry;
    public bool isReCharge;

    [Header("Key")]
    public bool haveKey1;
    public bool haveKey2;

    public bool isKey1;
    public bool isKey2;

    public GameObject Key1;
    public GameObject Key2;

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

    public TextMeshProUGUI NumBattry;

    [Header ("Codition")]
    public bool Quest1;
    public bool Quest2;

    public bool LastQuest;

    private void Start()
    {
        Battry = 8;
        isReCharge = true;
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

        flash = FindFirstObjectByType<FlashLight>();
    }

    private void Update()
    {
        NumBattry.text = "" + Battry;

        if (Battry == 0)
        {
            isReCharge = false;
        }
        

        if (haveKey1 == false)
        {
            Key1.SetActive(false);
        }
        if (haveKey2 == false)
        {
            Key2.SetActive(false);
        }

        if (haveKey1 == true)
        {
            Key1.SetActive(true);
        }
        if (haveKey2 == true)
        {
            Key2.SetActive(true);
        }

        SwitchItem();

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

        UpdateUIQuest();
    }

    void SwitchItem()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentItem = (int)Item.Flash;
            Item1.color = Color.gray;
            Item2.color = Color.white;
            Item3.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentItem = (int)Item.BigFlash;
            Item1.color = Color.white;
            Item2.color = Color.gray;
            Item3.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentItem = (int)Item.Key;
            Item1.color = Color.white;
            Item2.color = Color.white;
            Item3.color = Color.gray;
        }
    }

    public void GetKey(int x)
    {
        if (x == 1)
        {
            haveKey1 = true;
            AudioManager.instance.GetKey.Play();
        }
        if (x == 2)
        {
            haveKey2 = true;
            AudioManager.instance.GetKey.Play();
        }

    }

    public void UseBattry()
    {
        if (isReCharge == true)
        {
            flash.ReCharge();
            Battry = Battry - 1;
        }
    }

    public void UpdateUIQuest()
    {
        _paperQuestText.text = ($"Find {_paperQuantity} / 3 Paper");
        if (_paperQuantity == 3)
        {
            _paperQuestText.color = Color.green;
            Quest1 = true;
        }

        _keyQuesText.text = "Find A Sliver Key";
        if (haveKey2 == true)
        {
            _keyQuesText.color = Color.green;
            Quest2 = true;
        }

        if (Quest1 == true && Quest2 == true)
        {
            LastQuest = true;
            _entranceText.color = Color.red;
            _entranceText.text = "Go Back To The Entrance And Leave";
            _paperQuestText.text = "";
            _keyQuesText.text = "";
        }
    }
}
