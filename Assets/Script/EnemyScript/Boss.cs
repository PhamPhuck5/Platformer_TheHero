using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Boss : Enemy
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform[] _RespownPosittions;
    [SerializeField] GameObject BossPhase;
    [SerializeField] GameObject SenseTalk;
    protected Animator Animator;
    private List<Vector3> RespownPosittions=new List<Vector3>();
    private bool Atacked = false;
    private void Start()
    {
        Animator = GetComponent<Animator>();
        maxHP = 500;
        CurrentHP = maxHP;
        Dmg = 30;
        MoveSpeed = 0;
        Name = "Boss Ninja";
        foreach(Transform RespownPosittion in _RespownPosittions)
        {
            RespownPosittions.Add(RespownPosittion.position);
        }
        InvokeRepeating("Move", 6f, 8f);
    }
    public override void Attack()
    {
        Vector3 Diretion = Player.Instance.transform.position - transform.position;
        Diretion = Diretion.normalized;
        GameObject thebullet = Instantiate(Bullet, transform.position + new Vector3(Diretion.x, Diretion.y, 0), Quaternion.identity);
        thebullet.GetComponent<Bullet>().Direction = Diretion;
    }

    public override void Move()
    {
        int temp = Random.Range(0, 5);
        transform.position = RespownPosittions[temp];
        if (temp >= 3) GetComponent<SpriteRenderer>().flipX = false;
        else GetComponent<SpriteRenderer>().flipX = true;
        if (temp == 1 || temp == 3)
        {
            Animator.Play("BossInWall");
        }
        else
        {
            Animator.Play("BossAnimation");
        }
    }

    protected override void Die()
    {
        SenseTalk.SetActive(true);
        SenseTalk.GetComponent<SenseTriggerPoint1>().StartTalking();
        Destroy(BossPhase);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Atacked)
        {
            Atacked = true;
            Attack();
        }
    }
}
