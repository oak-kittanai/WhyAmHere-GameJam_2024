using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorOnEnter : MonoBehaviour
{
    [Header("Ref")]
    AudioManager _audioManager;
    public SpriteRenderer sRender;
    public Sprite DoorOpen;
    public Sprite DoorClose;

    public GameObject Player;
    private Vector2 _playerPos;

    [Header("transiton")]
    public Animator transiton;
    public float transitonTime = 1f;

    [Header("Setting")]
    public bool playerInRange;
    [SerializeField] bool _isPlayerAlreadyPress;

    [SerializeField] private RoomSelect _roomSelect;
    private enum RoomSelect {Room1_1, Room2_1, RoomJanitor_1, Room1_2, Room2_2, RoomToliet_2, Room1_3, RoomBoss_3, RoomToliet_3, OriRoom1_1, OriRoom2_1, OriRoomJanitor_1,
    OriRoom1_2, OriRoom2_2, OriRoomToliet_2, OriRoom1_3, OriRoomBoss_3, OriRoomToliet_3
    };

    [Header("Teleporter")]
    public Vector2 RoomTeleportPosition;

    private void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        if (_playerPos  == null)
        {
            _playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
    }

    void Update()
    {
        if (playerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                AudioManager.instance.DoorOpen.Play();
                sRender.sprite = DoorOpen;

                switch (_roomSelect)
                {
                    case RoomSelect.Room1_1:
                        RoomTeleportPosition = RoomPosition.Instance.Room1_1;
                        break;
                    case RoomSelect.Room2_1:
                        RoomTeleportPosition = RoomPosition.Instance.Room2_1;
                        break;
                    case RoomSelect.RoomJanitor_1:
                        RoomTeleportPosition = RoomPosition.Instance.RoomJanitor_1;
                        break;
                    case RoomSelect.Room1_2:
                        RoomTeleportPosition = RoomPosition.Instance.Room1_2;
                        break;
                    case RoomSelect.Room2_2:
                        RoomTeleportPosition = RoomPosition.Instance.Room2_2;
                        break;
                    case RoomSelect.RoomToliet_2:
                        RoomTeleportPosition = RoomPosition.Instance.RoomToliet_2;
                        break;
                    case RoomSelect.Room1_3:
                        RoomTeleportPosition = RoomPosition.Instance.Room1_3;
                        break;
                    case RoomSelect.RoomBoss_3:
                        RoomTeleportPosition = RoomPosition.Instance.RoomBoss_3;
                        break;
                    case RoomSelect.RoomToliet_3:
                        RoomTeleportPosition = RoomPosition.Instance.RoomToliet_3;
                        break;
                    case RoomSelect.OriRoom1_1:
                        RoomTeleportPosition = RoomPosition.Instance.OriginalRoom1_1;
                        break;
                    case RoomSelect.OriRoom2_1:
                        RoomTeleportPosition = RoomPosition.Instance.OriginalRoom2_1;
                        break;
                    case RoomSelect.OriRoomJanitor_1:
                        RoomTeleportPosition = RoomPosition.Instance.OriginalRoomJanitor_1;
                        break;
                    case RoomSelect.OriRoom1_2:
                        RoomTeleportPosition = RoomPosition.Instance.OriginalRoom1_2;
                        break;
                    case RoomSelect.OriRoom2_2:
                        RoomTeleportPosition = RoomPosition.Instance.OriginalRoom2_2;
                        break;
                    case RoomSelect.OriRoomToliet_2:
                        RoomTeleportPosition = RoomPosition.Instance.OriginalRoomToliet_2;
                        break;
                    case RoomSelect.OriRoom1_3:
                        RoomTeleportPosition = RoomPosition.Instance.OriginalRoom1_3;
                        break;
                    case RoomSelect.OriRoomBoss_3:
                        RoomTeleportPosition = RoomPosition.Instance.OriginalRoomBoss_3;
                        break;
                    case RoomSelect.OriRoomToliet_3:
                        RoomTeleportPosition = RoomPosition.Instance.OriginalRoomToliet_3;
                        break;
                    default:
                        break;
                }

                _isPlayerAlreadyPress = true;
                Player.transform.position = RoomTeleportPosition;
            }
        }
    }
    
    void CheckPress()
    {
        if (_isPlayerAlreadyPress)
        {
            StartCoroutine(WaitForDoorOpen());
        }
        
    }

    IEnumerator WaitForDoorOpen()   
    {
        yield return new WaitForSeconds(0.5f);
        Player.transform.position = RoomTeleportPosition;
        _isPlayerAlreadyPress = false;
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
            sRender.sprite = DoorClose;
            playerInRange = false;
        }
    }

}
