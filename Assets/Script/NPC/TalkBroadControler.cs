using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TalkBroadControler : MonoBehaviour
{
    [SerializeField] Button SellButton;
    [SerializeField] Button BuyButton;
    [SerializeField] Button ExitButton;
    [SerializeField] GameObject Phase1;
    [SerializeField] GameObject SellPlace;
    [SerializeField] GameObject BuyPlace;
    [SerializeField] GameObject Broad;
    private void Awake()
    {
        SellButton.onClick.AddListener(OpenSellPhase);
        BuyButton.onClick.AddListener(OpenBuyPhase);
        ExitButton.onClick.AddListener(Exit);
    }
    private void OpenSellPhase()
    {
        Phase1.SetActive(false);
        BuyPlace.SetActive(true);
        SellPlace.SetActive(false);
    }
    private void OpenBuyPhase()
    {
        Phase1.SetActive(false);
        BuyPlace.SetActive(false);
        SellPlace.SetActive(true);
    }
    private void Exit()
    {
        Phase1.SetActive(true);
        BuyPlace.SetActive(false);
        SellPlace.SetActive(false);
        Broad.SetActive(false);
        Player.Instance.gameObject.GetComponent<PlayerControl>().enabled = true;
    }
}
