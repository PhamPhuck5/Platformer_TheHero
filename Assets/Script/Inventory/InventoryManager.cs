using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;


//1 cai inventory rong 2 hang o ben tay phai, vi tri se la 2n+a(a=0or1),key la vi tri
public class InventoryManager : Singleton<InventoryManager>
{
    public Canvas canvas;
    public Transform InfoFrameTransform;
    private const int MaxInventorySlot = 18;
    [SerializeField] GameObject NormalItemBase;//prefab
    [SerializeField] Transform _GridLayout;
    List<Transform> _ItemSlot = new List<Transform>();

    [SerializeField] public List<InfoStoraging> InventoryStorage; //{ get; private set; }
    bool[] IsEmpty = new bool[MaxInventorySlot];

    [SerializeField]Text CoinAmoutText;
    /*    [SerializeField] List<InventoryItem> _Item = new List<InventoryItem>();
        public List<InventoryItem> Item => _Item;*/

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        for (int i = 0; i < MaxInventorySlot; i++)
        {
            IsEmpty[i] = true;
        }
        InventoryStorage = new List<InfoStoraging>();
        _ItemSlot = _GridLayout.GetComponentsInChildren<Transform>(false).ToList();
    }
    public void Init()//after start
    {
/*        int i = 1;
        foreach(InventoryItem item in _Item)
        {
            Instantiate(item, _ItemSlot[i]);
            i++;
        }
 sinh ra 1 cai theo prefab InventoryItem va cap nhat cac gia tri theo ID trong ItemInfo*/
        foreach(InfoStoraging item in InventoryStorage)
        {
            addNewItem(item);
        }
        if (DataManager.Instance.PlayerStatus.BuyRing)
        {
            GameObject Temp = Player.Instance.gameObject;
            Temp.GetComponent<PlayerControl>().BuyRing();
        }
    }
    private void Init(int quantiti, int ID,int place)
    {
        NormalItem ItemInfo = _GridLayout.transform.GetChild(place).GetChild(0).GetComponent<NormalItem>();
        ItemInfo.SetInfo(DataManager.Instance.ItemDictionary[ID], quantiti);
        ItemInfo.Init();
    }
    private void addNewItem(InfoStoraging item)//add item to empty place
    {
        GameObject temp = Instantiate(NormalItemBase, _ItemSlot[item.place + 1]);
        NormalItem ItemInfo = temp.GetComponent<NormalItem>();
        ItemInfo.SetInfo(DataManager.Instance.ItemDictionary[item.ID], item.quantiti);
        ItemInfo.Init();
    }
    public int add(int ID, int _quantity)
    {
        int temp = -1;
        temp = DataManager.Instance.ItemDictionary[ID].MaxCapacity;
        if(temp ==-1)
        {
            Debug.LogError("CantFindID");
            return -1;
        }
        //seach the having slot
        foreach (InfoStoraging item in InventoryStorage)
        {
            if (item.ID == ID&&item.quantiti<temp)
            {
                if(_quantity + item.quantiti > temp)
                {
                    _quantity = _quantity + item.quantiti - temp;
                    item.quantiti = temp;
                    Init(temp,ID,item.place);
                }
                else {
                    item.quantiti += _quantity;
                    Init(item.quantiti, ID,item.place);
                    return 0;
                }
            }
        }
        //add to new slot
        for (int i = 0; i < MaxInventorySlot; i++)
        {
            if (IsEmpty[i])
            {
                InfoStoraging NewItem = new InfoStoraging();
                NewItem.ID = ID;
                NewItem.place = i;
                IsEmpty[i] = false;
                if(_quantity <= temp){
                    NewItem.quantiti = _quantity;
                    SetItemInventory(NewItem);
                    addNewItem(NewItem);
                    return 0;
                }
                else
                {
                    NewItem.quantiti = temp;
                    _quantity -= temp;
                    SetItemInventory(NewItem);
                    addNewItem(NewItem);
                }
            }
        }
        return _quantity;
    }
    public void use(GameObject item)
    {
        DataManager.Instance.UsageItem[item.GetComponent<NormalItem>().Info.ID]();
        NormalItem thisItem = item.GetComponent<NormalItem>();
        if (thisItem.quantity == 1)
        {
            Destroy(item);
        }
        else
        {
            thisItem.quantity--;
            thisItem.Init();
        }
    }
    public void DeleteItem(InfoStoraging item)
    {
        int money = 0;
        money = item.quantiti * DataManager.Instance.ItemDictionary[item.ID].price;
        InventoryStorage.Remove(item);
        DataManager.Instance.PlayerStatus.money += money;
        UpdateCoinAmount();
        IsEmpty[item.place] = true;
    }
    public void SetEmpty(int place)
    {
        IsEmpty[place] = true;
    }
    public void ClearInventory()
    {
        InventoryStorage.Clear();
        for(int i=0; i<MaxInventorySlot;i++)
        {
            IsEmpty[i] = true;
        }
    }
    // them moi vao 1 o
    public void SetItemInventory(InfoStoraging item)
    {
        InventoryStorage.Add(item);
        IsEmpty[item.place] = false;
    }

    public void UpdateCoinAmount()
    {
        CoinAmoutText.text = DataManager.Instance.PlayerStatus.money.ToString();
    }
}

[Serializable][SerializeField] public class InfoStoraging
{
    public int place;
    public int ID;
    public int quantiti;
}

