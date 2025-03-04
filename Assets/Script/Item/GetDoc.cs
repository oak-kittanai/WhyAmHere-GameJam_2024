using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDoc : MonoBehaviour
{
    [Header("Ref")]
    GameManager manager;
    EnemyAI enemyBoss;

    [Header("Unlock")]
    public bool isUnLock;

    private void Start()
    {
        isUnLock = false;
        enemyBoss = GetComponent<EnemyAI>();

        if (manager == null)
        {
            GameObject _gameManager = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            manager = _gameManager.GetComponent<GameManager>();
        }
    }

    private void Update()
    {
        if (enemyBoss.isBossDead == true)
        {
            isUnLock = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isUnLock == true)
        {
            if (other.gameObject.tag == "Player")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //manager.BossDie();
                }
            }
        }
    }
}
