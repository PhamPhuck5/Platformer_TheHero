using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToCoin : MonoBehaviour
{
    [SerializeField] RectTransform Taget;
    [SerializeField] RectTransform ThisRT;
    Vector2 Direction;
    public void Init()
    {
        Taget = SettingButton.Instance.CointRT;
        Direction = Taget.anchoredPosition - ThisRT.anchoredPosition ;
        Direction = Direction.normalized*5;
    }
    private void Update()
    {
        ThisRT.anchoredPosition += Direction;
        if (ThisRT.anchoredPosition == Taget.anchoredPosition)
        {
            InventoryManager.Instance.UpdateCoinAmount();
            Destroy(gameObject);
        }//trong truong hop thuong xuyen say ra co the cho vao Object pooling
    }
}
