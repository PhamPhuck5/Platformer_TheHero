using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemToSellSheld : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (transform.childCount == 0)
            {
                int oldplace = eventData.pointerDrag.GetComponent<DragAndDrop>().NowPlace;
//                int money = 0;
                foreach (InfoStoraging item in InventoryManager.Instance.InventoryStorage)
                {
                    if (item.place == oldplace)
                    {
                        InventoryManager.Instance.DeleteItem(item);
                        Destroy(eventData.pointerDrag);
                        return;
                    }
                }

            }
        }
    }
}
