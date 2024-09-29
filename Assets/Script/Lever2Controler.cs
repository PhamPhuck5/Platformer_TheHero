using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2Controler : Singleton<Lever2Controler>
{
 //   public RectTransform CoinRT;
//    public GameObject Coin;
    [SerializeField] GameObject PlayerInitPosittion;
    protected override void Awake()
    {
        base.Awake();
        SaveLoad.Instance.LoadInventory();
    }
    private void Start()
    {
        Vector3 Temp = PlayerInitPosittion.transform.position;
        Player.Instance.gameObject.transform.position = Temp;
    }
}
