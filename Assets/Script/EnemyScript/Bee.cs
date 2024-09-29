using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bee : Enemy
{
    private float TimeAttack;
    private Vector2 MoveDiretion;
    private float angle;
    public Rigidbody2D RB;
    public GameObject bullet;
    public GameObject DeadBody;

    private void Start()
    {
        maxHP = 20;
        CurrentHP = maxHP;
        Dmg = 15;
        MoveSpeed = 1;
        TimeAttack = 0;
    }
    private void Update()
    {
        Move();
        TimeAttack += Time.deltaTime;
         if(TimeAttack >= 4f)
         {
            Attack();
            TimeAttack = 0f;
         }   
    }
    private void FixedUpdate()
    {
        RB.velocity = MoveDiretion;
    }

    public override void Move()
    {
        Vector3 PlayerPossittion= Player.Instance.transform.position;
        Vector3 EnemyPosittion = transform.position;
        Vector2 Temp = new Vector2(PlayerPossittion.x - EnemyPosittion.x, PlayerPossittion.y - EnemyPosittion.y);
        MoveDiretion = Temp.normalized * MoveSpeed;
        angle = Mathf.Atan2(Temp.y, Temp.x) * Mathf.Rad2Deg+90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public override void Attack()
    {
        GameObject thebullet = Instantiate(bullet, transform.position + new Vector3(MoveDiretion.x, MoveDiretion.y, 0), Quaternion.Euler(new Vector3(0, 0, angle)));
        thebullet.GetComponent<Bullet>().Direction = MoveDiretion / MoveSpeed;
    }

    protected override void Die()
    {
        DataManager.Instance.PlayerStatus.money += Reward;
        Instantiate(DeadBody,this.transform.position,quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.TakeDmg(Dmg);
        }
    }
}
