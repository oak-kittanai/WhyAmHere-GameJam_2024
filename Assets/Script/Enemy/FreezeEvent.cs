using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEvent : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _selfRbMob;
    
    public bool isFreeze;

    private void Start()
    {
        _selfRbMob = GetComponent<Rigidbody2D>();
        isFreeze = true;
    }

    private void Update()
    {
        if (isFreeze == false)
        {
            // ทำให้ UnFreeze
        }
    }
}
