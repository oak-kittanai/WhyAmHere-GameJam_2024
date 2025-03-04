using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    [Header("Single")]
    public static SwitchLight Instance;

    [Header("Light")]
    public GameObject[] Lights;

    public GameObject SwitchUp;
    public GameObject SwitchDown;

    [Header("Is")]
    public bool playerInRange;
    public bool isLightOn;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        for (int i = 0; i < Lights.Length; i++)
        {
            if (isLightOn == false)
            {
                Lights[i].SetActive(false);
            }

            if (isLightOn == true)
            {
                Lights[i].SetActive(true);
            }
            
        }

        if (playerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isLightOn = true;
                SwitchUp.SetActive(true);
                SwitchDown.SetActive(false);
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

    private void OnTriggerStay2D(Collider2D collision)
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
