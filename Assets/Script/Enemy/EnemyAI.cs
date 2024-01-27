using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Ref")]
    GameManager manager;

    [Header("Properties")]
    public GameObject player;
    public float speed;
    public float distanceBetween;

    public float distance;

    private void Start()
    {
        if (manager == null)
        {
            GameObject _gameManager = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            manager = _gameManager.GetComponent<GameManager>();
        }
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance <  distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
