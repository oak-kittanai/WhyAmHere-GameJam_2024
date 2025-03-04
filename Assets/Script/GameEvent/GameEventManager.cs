using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance;

    [Header("GameEvent")]
    public GameObject[] _EventTriggerF1;
    public GameObject[] _EventTriggerF2;
    public GameObject[] _EventTriggerF3;

    [Header("Condition")]
    public bool _isTriggerF1 = true;
    public bool _isTriggerF2 = true;
    public bool _isTriggerF3 = true;

    [Header("OnCheck")]
    public bool isFirstFloorTrigger;
    public bool isSecondFloorTrigger;
    public bool isThirdFloorTrigger;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        FloorEventUpdate();
    }

    void FloorEventUpdate()
    {
        // Floor 1 Event
        if (isFirstFloorTrigger == true)
        {
            if (_isTriggerF1)
            {
                for (int i = 0; i < _EventTriggerF1.Length; i++)
                {
                    // ตัวเก็บ Event ของ Floor 1
                    _EventTriggerF1[i].SetActive(true);
                    if (i == _EventTriggerF1.Length)
                    {
                        isFirstFloorTrigger = false;
                        
                        break;
                    }
                }
                _isTriggerF1 = false;
            }
            
        }


        // Floor 2 Event
        if (isSecondFloorTrigger == true)
        {
            for (int i = 0; i < _EventTriggerF2.Length; i++)
            {
                if (_isTriggerF2)
                {
                    // ตัวเก็บ Event ของ Floor 2
                    _EventTriggerF2[i].SetActive(true);
                    if (i == _EventTriggerF2.Length)
                    {
                        isSecondFloorTrigger = false;
                        
                        break;
                    }
                }
                _isTriggerF2 = false;
            }

        }

        // Floor 3 Event
        if (isThirdFloorTrigger == true)
        {
            if (_isTriggerF3)
            {
                for (int i = 0; i < _EventTriggerF3.Length; i++)
                {
                    // ตัวเก็บ Event ของ Floor 3
                    _EventTriggerF3[i].SetActive(true);
                    if (i == _EventTriggerF3.Length)
                    {
                        isThirdFloorTrigger = false;
                        
                        break;
                    }
                }
                _isTriggerF3 = false;
            }
        }
    }
}
