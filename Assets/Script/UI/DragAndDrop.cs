using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] RectTransform RectTransform;
    [SerializeField] Canvas canvas;
    [SerializeField] Image Image;
    [HideInInspector] public Transform Parent;
    public int NowPlace;
    private void Start()
    {
        canvas = InventoryManager.Instance.canvas;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Image.raycastTarget = false;
        Parent = transform.parent;
        transform.SetParent(transform.root);
        NowPlace = Parent.GetSiblingIndex();
    }
    public void OnDrag(PointerEventData eventData)
    {
        RectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(Parent);
        Image.raycastTarget = true;
    }
    public void SwapItem(Transform otherIventory,Transform OtherItem)
    {
        OtherItem.SetParent(Parent);
        Parent = otherIventory;
    }
}
