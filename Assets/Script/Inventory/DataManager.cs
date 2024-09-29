using System;
using System.Collections.Generic;
using UnityEngine;
public class DataManager : Singleton<DataManager>
{
    //chua thong tin cua item va cac vat pham dac biet
    [SerializeField] List<ItemBase> _Item = new List<ItemBase>();//List de lay thong tin tu scriptableobject
 //____________________________________

    Dictionary<int, ItemBase> _GeneralDataItem = new Dictionary<int, ItemBase>();
    public Dictionary<int, ItemBase> ItemDictionary => _GeneralDataItem;//thong tin theo id
 //____________________________________

    Dictionary<int, Action> _UsageItem = new Dictionary<int, Action>();
    public Dictionary<int, Action> UsageItem => _UsageItem;//tac dung theo id
 //____________________________________

    public PlayerStatus PlayerStatus = new PlayerStatus();
    protected override void Awake()
    {
        base.Awake();
        UseItem Instance = new UseItem();
        foreach (ItemBase item in _Item)
        {
            _GeneralDataItem.Add(item.ID, item);
            if (item.ID < 10) continue;
            string methodName = "ID" + item.ID.ToString();
            System.Reflection.MethodInfo method = typeof(UseItem).GetMethod(methodName);
            Action Usage = (Action)Delegate.CreateDelegate(typeof(Action), Instance, method);
            _UsageItem.Add(item.ID, Usage);
        }
    }
}
public class UseItem
{
    public void ID10()
    {
        Player.Instance.AddPlayerHP(70);
    }
    public void ID11()
    {

    }
    public void ID20()
    {
        Player.Instance.AddPlayerHP(20);
    }
    public void ID21()
    {
        Player.Instance.AddPlayerHP(20);

    }
}
public class PlayerStatus
{
    public bool GaveFlash = false;
    public bool BuyRing = false;
    public int money = 0;
}
