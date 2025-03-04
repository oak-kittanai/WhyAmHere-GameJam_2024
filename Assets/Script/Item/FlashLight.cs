using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    [Header("Ref")]
    GameManager manager;
    Inventory inventory;
    public Light2D LightR;
    public Light2D LightL;


    [Header("Hub")]
    public GameObject BattryBar;
    public Slider battryShow;

    [Header("Battry")]
    public float battry;
    public float battryMax = 50;

    public float LightOut = 0f;
    public float LightOn = 0.45f;

    public bool isBattry;

    [Header("Is")]
    public bool isUse;

    private void Start()
    {
        if (manager == null)
        {
            GameObject _gameManager = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            manager = _gameManager.GetComponent<GameManager>();
        }

        inventory = FindFirstObjectByType<Inventory>();
        BattryBar.SetActive(false);

        battry = battryMax;
    }

    private void Update()
    {
        if (battry > 1)
        {
            isBattry = true;
        }
        else
        {
            isBattry = false;
        }

        battryShow.value = battry;

        if (battry > battryMax)
        {
            battry = battryMax;
        }
        if (battry < 1)
        {
            battry = 0;
        }

        if (isBattry == false)
        {
            LightR.intensity = LightOut;
            LightL.intensity = LightOut;
        }
        if (isBattry == true)
        {
            LightR.intensity = LightOn;
            LightL.intensity = LightOn;
        }

        if (inventory.currentItem == 1)
        {
            BattryBar.SetActive(true);
            if (isBattry == true)
            {
                isUse = true;
            }
            if (isBattry == false)
            {
                isUse = false;
            }
        }
        else
        {
            BattryBar.SetActive(false);
        }

        if (isUse == true)
        {
            battry -= 1 * Time.deltaTime;
        }

    }

    public void ReCharge()
    {
        battry = battryMax;
    }

}
