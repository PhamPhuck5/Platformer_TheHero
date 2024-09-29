using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePoint : MonoBehaviour
{
    [SerializeField] Vector3 Taget;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collision.CompareTag("Player"))
            {
                Player.Instance.Teleport(Taget);
            }
        }
    }
}
