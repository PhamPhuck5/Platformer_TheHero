using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class SaveLoad:Singleton<SaveLoad>
{
    public readonly string SAVE_INVENTORY = System.IO.Path.Combine(Application.dataPath , "Save/inventory.json");

    private void Start()
    {
        Debug.Log(SAVE_INVENTORY);
    }

    public void LoadInventory()
    {
        if (HavingSave())
        {
            InventoryManager.Instance.ClearInventory();
            string temp = System.IO.File.ReadAllText(SAVE_INVENTORY);
            InventoryData ReadLog = JsonUtility.FromJson<InventoryData>(temp);
            foreach(InfoStoraging item in ReadLog.RemainingInIventory)
            {
                InventoryManager.Instance.SetItemInventory(item);
            }
            DataManager.Instance.PlayerStatus.money = ReadLog.coin;
            DataManager.Instance.PlayerStatus.BuyRing = ReadLog.BuyRing;
            DataManager.Instance.PlayerStatus.GaveFlash = ReadLog.gaveFlash;
        }
        else { Debug.LogError("MissSaveFile"); }
        InventoryManager.Instance.Init();
    }
    public void SaveInventory()
    {
        InventoryData temp = new InventoryData();
        foreach (InfoStoraging item in InventoryManager.Instance.InventoryStorage)
        {
            temp.RemainingInIventory.Add(item);
        }
        temp.coin = DataManager.Instance.PlayerStatus.money;
        temp.BuyRing = DataManager.Instance.PlayerStatus.BuyRing;
        temp.gaveFlash = DataManager.Instance.PlayerStatus.GaveFlash;
        string SaveString = JsonUtility.ToJson(temp);
        System.IO.File.WriteAllText(SAVE_INVENTORY, SaveString);
        InventoryManager.Instance.ClearInventory();
    }
    public bool HavingSave()
    {
        if (System.IO.File.Exists(SAVE_INVENTORY)) return true;
        else return false;
    }
}
[System.Serializable]
public class InventoryData
{
    public List<InfoStoraging> RemainingInIventory = new List<InfoStoraging>();
    public int coin;
    public bool BuyRing = false;
    public bool gaveFlash = false;
}
