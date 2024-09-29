using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
//script de goi bang thong tin
public class ItemInfoFrame : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            InventoryManager.Instance.use(this.gameObject);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        int ID = GetComponent<NormalItem>().Info.ID;
        GameObject Broad = SetItemBroad.Instance.ItemBroad;
        Broad.transform.position = InventoryManager.Instance.InfoFrameTransform.position;
        Broad.GetComponent<SetItemBroad>().SetInfo(DataManager.Instance.ItemDictionary[ID]);
        Broad.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        GameObject Broad = SetItemBroad.Instance.ItemBroad;
        Broad.SetActive(false);
    }
}
