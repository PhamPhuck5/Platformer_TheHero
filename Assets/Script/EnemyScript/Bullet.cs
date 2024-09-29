using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 Direction;
    private float Movespeed;
    private void Start()
    {
        Movespeed = 3f;
    }
    private void Update()
    {
        transform.position += Direction * Time.deltaTime * Movespeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.TakeDmg(10);
        }
        Destroy(gameObject);
    }
}
