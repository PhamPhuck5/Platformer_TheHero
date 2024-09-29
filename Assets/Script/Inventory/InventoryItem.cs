using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public abstract class InventoryItem:MonoBehaviour
{
    public ItemBase Info;
    [SerializeField]
    public int quantity;
}
