using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class TiggerZone : MonoBehaviour
{
    private GameObject _self;
    public GameObject _otherEvent;

    [Header("Config")]
    [SerializeField] private floor _currentFloor;
    [SerializeField] private enum floor{None, First, Second, Third};
    [SerializeField] private bool _isPlayerInRange;
    [SerializeField] private bool _otherObj;

    private void Start()
    {
        _self = this.gameObject;
    }

    private void Update()
    {
        if (_isPlayerInRange == true)
        {
            switch (_currentFloor)
            {
                case floor.None:
                    _otherObj = true;
                    _otherEvent.SetActive(true);
                    _self.SetActive(false);
                    break;
                case floor.First:
                    GameEventManager.instance.isFirstFloorTrigger = true;
                    _self.SetActive(false);
                    break;
                case floor.Second:
                    GameEventManager.instance.isSecondFloorTrigger = true;
                    _self.SetActive(false);
                    break;
                case floor.Third:
                    GameEventManager.instance.isThirdFloorTrigger = true;
                    _self.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isPlayerInRange = false;
        }
    }
}
