using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDown : MonoBehaviour, IDropHandler
{
    //Only for change place in inventory not to other
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (transform.childCount == 0)
            {
                ChangePlace(eventData);
            }
            else
            {
                SwapPlace(eventData);
            }
        }
    }
    private void ChangePlace(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<DragAndDrop>().Parent = transform;
        int oldplace = eventData.pointerDrag.GetComponent<DragAndDrop>().NowPlace;
        int newPlace = transform.GetSiblingIndex();
        InventoryManager.Instance.SetEmpty(oldplace);
        foreach (InfoStoraging item in InventoryManager.Instance.InventoryStorage)
        {
            if (item.place == oldplace) item.place = newPlace;
            return;
        }
    }
    private void SwapPlace(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<DragAndDrop>().SwapItem(transform, transform.GetChild(0));
        eventData.pointerDrag.GetComponent<DragAndDrop>().Parent = transform;
        int oldplace = eventData.pointerDrag.GetComponent<DragAndDrop>().NowPlace;
        int newPlace = transform.GetSiblingIndex();
        Debug.Log(oldplace + " " + newPlace);
        foreach (InfoStoraging item in InventoryManager.Instance.InventoryStorage)
        {
            if (item.place == newPlace) { item.place = oldplace; }
            else if (item.place == oldplace) { item.place = newPlace; }
            //vi cac phan tu chi dung 1 lan
        }
    }
}
