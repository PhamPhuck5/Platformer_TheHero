using UnityEngine;
using System.Collections;
public class Turtle : Enemy
{
    Rigidbody2D thisRB;
    int direction;
    private int move;
    private float DefauldDistanceToHead; //khoang cach tu centre den khu vuc coi la dau
    private Vector2 CheckWall;
    private SpriteRenderer SR;
    private Collider2D C2D;
    [SerializeField] GameObject DeadBody;
    private void Awake()
    {
        DefaultSetting();
    }
    private void DefaultSetting()
    {
        Name = "Turtle";
        DefauldDistanceToHead = 0.05f;
        maxHP = 100;
        CurrentHP = maxHP;
        Dmg = 25;
        MoveSpeed = 1;
        thisRB = GetComponent<Rigidbody2D>();
        C2D = GetComponent<Collider2D>();
        direction = -1;
        CheckWall = new Vector2(direction, 0);
        move = MoveSpeed * (-1);
        SR = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, CheckWall, 0.35f*transform.localScale.x,GlobalVariable.LayerTerrantToInt);
        if(hit.collider != null)
        {
            move *= -1;
//            CheckWall.x *= -1;
            ChangeAnimationDiretion();
        }
    }
    //neu xoay theo scale thi xoay ca raycast
    protected void ChangeAnimationDiretion()
    {
        //        SR.flipX = (!SR.flipX);
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        thisRB.velocity = new Vector2(move, thisRB.velocity.y);
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    protected override void Die()
    {
        GameObject Temp = Instantiate(DeadBody,transform.position,Quaternion.identity);
        Temp.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(3f, 5f) * Player.Instance.Horrizontal, Random.Range(3f, 5f));
        base.Die();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.collider.bounds.min.y >= C2D.bounds.center.y + DefauldDistanceToHead * transform.localScale.y)
            {
                TakeDmg(50);
                move *= -1;
                ChangeAnimationDiretion();
            }
            else
            {
                Player.Instance.TakeDmg(Dmg);
            }
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            move *= -1;
            ChangeAnimationDiretion();
        }
    }

}
