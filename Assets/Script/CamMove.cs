using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    private CinemachineConfiner2D cameraConfiner;
    private PolygonCollider2D colliderPoly;

    private void Start()
    {
        cameraConfiner = FindObjectOfType<CinemachineConfiner2D>();
        colliderPoly = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraConfiner.m_BoundingShape2D = colliderPoly;
        }
    }
}
