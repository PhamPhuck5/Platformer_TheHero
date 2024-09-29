using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootDetected : MonoBehaviour
{
    private PlayerControl PlayerControl;
    private void Awake()
    {
        PlayerControl = Player.Instance.gameObject.GetComponent<PlayerControl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControl.RenewJumpTime();
    }
}
