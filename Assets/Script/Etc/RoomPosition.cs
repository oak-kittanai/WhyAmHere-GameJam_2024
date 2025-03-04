using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPosition : MonoBehaviour
{
    public static RoomPosition Instance { get; private set; } = new RoomPosition();

    [Header("First Floor")]
    public Vector2 Room1_1 = new Vector2(-102.61f, 1.59f);
    public Vector2 Room2_1 = new Vector2(-169.7f, 1.59f);
    public Vector2 RoomJanitor_1 = new Vector2(68.22f, 1.59f);

    [Header("Second Floor")]
    public Vector2 Room1_2 = new Vector2(-102.61f, 23.58f);
    public Vector2 Room2_2 = new Vector2(-169.7f, 23.58f);
    public Vector2 RoomToliet_2 = new Vector2(68.5f, 23.58f);

    [Header("Third Floor")]
    public Vector2 Room1_3 = new Vector2(-102.61f, 45.38f);
    public Vector2 RoomBoss_3 = new Vector2(-174.92f, 45.38f);
    public Vector2 RoomToliet_3 = new Vector2(68.33f, 45.38f);

    [Header("Original Door Position")]
    public Vector2 OriginalRoom1_1 = new Vector2(2.5f, 1.59f);
    public Vector2 OriginalRoom2_1 = new Vector2(-18.67f, 1.59f);
    public Vector2 OriginalRoomJanitor_1 = new Vector2(-51f, 1.59f);

    public Vector2 OriginalRoom1_2 = new Vector2(4.2f, 23.58f);
    public Vector2 OriginalRoom2_2 = new Vector2(-18.6f, 23.58f);
    public Vector2 OriginalRoomToliet_2 = new Vector2(-51.1f, 23.58f);

    public Vector2 OriginalRoom1_3 = new Vector2(4.6f, 45.38f);
    public Vector2 OriginalRoomBoss_3 = new Vector2(-38.9f, 45.38f);
    public Vector2 OriginalRoomToliet_3 = new Vector2(-51.3f, 45.38f);

}
