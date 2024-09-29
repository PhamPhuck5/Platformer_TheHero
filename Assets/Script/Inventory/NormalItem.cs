using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
//hien ra trong UI
[Serializable]
public class NormalItem : InventoryItem
{
    [SerializeField] Image Image;
    [SerializeField] Text NameItem;
    [SerializeField] Text QuantityItem;

    public void SetInfo(ItemBase ThisInfo,int ThisQuantity)
    {
        Info = ThisInfo;
        quantity = ThisQuantity;
    }
    public void Init()
    {
        if (Info == null) { return; }
        Image.sprite = Info.Image;
        NameItem.text = Info.Name;
        QuantityItem.text = this.quantity.ToString();
    }
}
