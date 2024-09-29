using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Machete : MonoBehaviour
{
    private quaternion ZeroQuaternion;
    private quaternion HalfQuaternion;
    private Coroutine AttackCoroutine;
    private GameObject TPlayer;
    [SerializeField] GameObject FireLight;
    private void Start()
    {
        ZeroQuaternion = Quaternion.Euler(0, 0, 0);
        HalfQuaternion = Quaternion.Euler(0, 0, 180);
        TPlayer = Player.Instance.gameObject;
    }
    public void Init()
    {
        transform.rotation = ZeroQuaternion;
        AttackCoroutine = StartCoroutine("Attack");
    }
    IEnumerator Attack()
    {
        while(transform.localEulerAngles.z < 180)
        {
            transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + 90 * Time.deltaTime);
            yield return null;
        }
        if(transform.localEulerAngles.z > 180)
        {
            EndAttack();
        }
    }
    private void EndAttack()
    {
        StopCoroutine(AttackCoroutine);
        FireLight.SetActive(true);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            Player.Instance.TakeDmg(30);
            TPlayer.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 30, ForceMode2D.Impulse);
        }
    }
}
