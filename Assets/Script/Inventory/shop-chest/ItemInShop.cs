using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInShop : MonoBehaviour
{
    [SerializeField] int ID;
    [SerializeField] Text _Name;
    [SerializeField] Text _Description;
    [SerializeField] Text _Price;
    [SerializeField] Image _Image;
    [SerializeField] Button BuyButton;

    private void Start()
    {
        if (ID == 1 && DataManager.Instance.PlayerStatus.BuyRing == true) { Destroy(gameObject); }
        ItemBase ItemInfo = DataManager.Instance.ItemDictionary[ID];
        _Name.text = ItemInfo.Name;
        _Description.text = ItemInfo.description;
        _Price.text = ItemInfo.price.ToString();
        _Image.sprite = ItemInfo.Image;
        if (ID >= 10) { BuyButton.onClick.AddListener(() => Buy(ItemInfo.price)); }
        else if(ID <10) { BuyButton.onClick.AddListener(() => BuyAndUseItem(ItemInfo.price));}
        InventoryManager.Instance.UpdateCoinAmount();
    }
    private void Buy(int price)
    {
        if (DataManager.Instance.PlayerStatus.money >= price)
        {
            InventoryManager.Instance.add(ID, 1);
            DataManager.Instance.PlayerStatus.money -= price;
        }
        else { Debug.Log("Dont enough money"); }
    }
    private void BuyAndUseItem(int price)
    {
        if (DataManager.Instance.PlayerStatus.money >= price)
        {
            DataManager.Instance.PlayerStatus.money -= price;
            if (ID == 1)
            {
                Player.Instance.gameObject.GetComponent<PlayerControl>().BuyRing();
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.Log("Dont enough money");
        }
    }
}
