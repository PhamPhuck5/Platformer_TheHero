using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SetItemBroad : Singleton<SetItemBroad>
{
    [SerializeField] Image _Image;
    [SerializeField] Text _Name;
    [SerializeField] Text _Descriptsion;
    public GameObject ItemBroad;

    public void SetInfo(ItemBase Item)
    {
        _Image.sprite = Item.Image;
        _Name.text = Item.Name;
        _Descriptsion.text = Item.description;
    }

}
