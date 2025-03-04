using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameContoller : MonoBehaviour
{
    [Header("Ref")]
    public GameObject ExitZone;
    public GameObject EndEventEffect;
    public GameObject NomalEventEffect;

    public GameObject HardcoreBossChase;

    Inventory inventory;

    private void Start()
    {
        ExitZone.SetActive(false);
        EndEventEffect.SetActive(false);

        inventory = FindFirstObjectByType<Inventory>();
    }

    private void Update()
    {
        EndGameUpdate();
    }

    void EndGameUpdate()
    {
        if (inventory.LastQuest == true)
        {
            ExitZone.SetActive(true);
            EndEventEffect.SetActive(true);
            HardcoreBossChase.SetActive(true);

            NomalEventEffect.SetActive(false);
        }

    }
}
