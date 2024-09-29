using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestControl : MonoBehaviour
{
    [SerializeField] GameObject CoinPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InventoryManager.Instance.add(21, 3);
            DataManager.Instance.PlayerStatus.money += 500;
            GameObject temp=Instantiate(CoinPrefab, SettingButton.Instance.CointRT);
            Vector2 CoinAP = SettingButton.Instance.CointRT.anchoredPosition + Vector2.right * 600 + Vector2.down*300;
            temp.GetComponent<RectTransform>().anchoredPosition = CoinAP;
            temp.GetComponent<GoToCoin>().Init();
            InventoryManager.Instance.UpdateCoinAmount();
            Destroy(gameObject);
        }
    }
}
