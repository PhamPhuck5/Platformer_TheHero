using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform PlayerTranform;
    private void Awake()
    {
        PlayerTranform = Player.Instance.transform;
    }
    private void Update()
    {
        Vector3 Move = new Vector3(PlayerTranform.position.x - transform.position.x, PlayerTranform.position.y - transform.position.y + 3f, 0);
        transform.position += Move * Time.deltaTime * 2;
    }
}
