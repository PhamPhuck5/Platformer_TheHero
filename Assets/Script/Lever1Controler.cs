using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1Controler : MonoBehaviour
{
    public Transform TelePoint;
    public Transform ApearPoint;

    private void Awake()
    {
        if (GlobalVariable.IsLoad == true)
        {
            SaveLoad.Instance.LoadInventory();
            Player.Instance.transform.position = ApearPoint.position;
        }
        if (GlobalVariable.IsLoad)
        {
            Player.Instance.transform.position = TelePoint.position;
        }
    }
    void Start()
    {
        InventoryManager.Instance.UpdateCoinAmount();
        string SpawnFunction = "SpawnTurtle";
        InvokeRepeating(methodName: SpawnFunction, 2f, 5f);
    }
    private void SpawnTurtle()
    {
        if (ObjectPooling.Instance.PoolDictionary["Turtle"].Count == 0) return;
        GameObject temp = ObjectPooling.Instance.PoolDictionary["Turtle"].Dequeue();
        temp.GetComponent<Enemy>().Respown();
    }
}
