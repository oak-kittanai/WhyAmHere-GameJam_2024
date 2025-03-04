using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1GameEvent : MonoBehaviour
{
    public GameObject _EventGhost;

    SwitchLight switchLight;

    private void Start()
    {
        if (switchLight == null)
        {
            switchLight = FindFirstObjectByType<SwitchLight>();
        }

        _EventGhost.SetActive(false);
    }

    private void Update()
    {

        if (SwitchLight.Instance.isLightOn == true)
        {
            _EventGhost.SetActive(true);
        }
    }
}
