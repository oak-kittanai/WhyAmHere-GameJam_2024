using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{

    public float delayLight;
    public GameObject _lightBulb;

    [SerializeField]
    private bool isOn;
    [SerializeField]
    private bool isOff;

    private void Start()
    {
        isOn = true;
    }

    private void Update()
    {
        if (isOn == true)
        {
            StartCoroutine(TrunOff());
        }

        if (isOff == true)
        {
            StartCoroutine(TrunOn());
        }
    }

    IEnumerator TrunOff()
    {
        yield return new WaitForSeconds(delayLight);
        _lightBulb.gameObject.SetActive(false);
        isOn = false;
        isOff = true;
    }

    IEnumerator TrunOn()
    {
        yield return new WaitForSeconds(delayLight);
        _lightBulb.gameObject.SetActive(true);
        isOn = true;
        isOff = false;
    }
}
