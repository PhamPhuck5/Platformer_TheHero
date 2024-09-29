using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossBehevior : MonoBehaviour
{
    [SerializeField] GameObject BossDoorBlock;
    [SerializeField] GameObject BossHP;
    [SerializeField] GameObject Machete;
    [SerializeField] GameObject Boss;
    [SerializeField] GameObject FireLight;

    private bool BossApeared = false;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")&&!BossApeared)
        {
            BossApeared = true;
            BossDoorBlock.SetActive(true);
            Boss.SetActive(true);
            BossHP.SetActive(true);
            InvokeRepeating("Attack", 2, 6);
        }
    }
    private void Attack()
    {
        int temp = Random.Range(0, 3);
        if (temp == 0)
        {
            StartCoroutine("BossAttackThunder");
        }
        else if(temp == 1)
        {
            BossAttackBoom();
        }
        else
        {
            FireLight.SetActive(false);
            BossAttackMachete();
        }
    }
    IEnumerator BossAttackThunder()
    {
        float Timer = 0;
        int i = 1;
        GameObject Thunder = ObjectPooling.Instance.PoolDictionary["Thunder"].Dequeue();
        if(Thunder == null)
        {
            Debug.LogError("Thunder don't exist in PoolDictionary");
            yield break;
        }
        Thunder Temp = Thunder.GetComponent<Thunder>();
        while (true)
        {
            Timer += Time.deltaTime;
            if(Timer/1.5 >= i)
            {
                i++;
                Thunder.SetActive(true);
                Temp.Init();
            }
            if (i >= 4) yield break;
            yield return null;
        }
    }
    private void BossAttackBoom()
    {
        Queue<GameObject> Booms = ObjectPooling.Instance.PoolDictionary["Boom"];
        if(Booms == null)
        {
            Debug.LogError("Boom don't exist in PoolDictionary");
            return;
        }
        while(Booms.Count>0)
        {
            GameObject Temp = Booms.Dequeue();
            Temp.SetActive(true);
            Temp.GetComponent<Boom>().Init();
        }
    }
    private void BossAttackMachete()
    {
        Machete.SetActive(true);
        Machete.GetComponent<Machete>().Init();
    }

}
