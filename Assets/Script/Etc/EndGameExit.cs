using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameExit : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private bool _playerInRange;

    private void Update()
    {
        UpdateConfig();
    }

    void UpdateConfig()
    {
        if (_playerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("End");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _playerInRange = false;
        }
    }
}
