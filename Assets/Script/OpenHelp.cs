using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHelp : MonoBehaviour
{
    public GameObject Help;

    private void Update()
    {
        Help.SetActive(true);
    }


    void Open()
    {
        Help.SetActive(!Help.active);
    }
}
