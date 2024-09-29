using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sense : MonoBehaviour
{
    [SerializeField]GameObject SenseTalkUI;
    [SerializeField]Button SenseButton;
    [SerializeField] GameObject TalkBroad;
    private void Awake()
    {
        SenseButton.onClick.AddListener(BroadOn);
    }
    public void BroadOn()
    {
        Debug.Log("Broadom");
        TalkBroad.SetActive(true);
        Player.Instance.gameObject.GetComponent<PlayerControl>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SenseTalkUI.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        SenseTalkUI.SetActive(false);
    }
}
