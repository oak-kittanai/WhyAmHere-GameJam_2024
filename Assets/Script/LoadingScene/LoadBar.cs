using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadBar : MonoBehaviour
{
    [SerializeField] float _loadSpeed;
    public float _minLoad;
    public float _maxLoad;

    [SerializeField] bool _startCD;
    [SerializeField] bool _warp;
    [SerializeField] Slider _loadingBar;

    void Update()
    {
        CheckLoadbarUpdate();
    }

    void CheckLoadbarUpdate()
    {
        _loadingBar.value = _minLoad;
        _loadingBar.maxValue = _maxLoad;

        if (!_startCD)
        {
            if (_minLoad < _maxLoad)
            {
                _minLoad += _loadSpeed * Time.deltaTime;
            }
            else
            {
                _startCD = true;
            }
        }

        if (_minLoad >= _maxLoad && !_warp)
        {
            StartCoroutine(TeleportToGame());
            _warp = true;
        }
    }

    IEnumerator TeleportToGame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game");
    }
}
