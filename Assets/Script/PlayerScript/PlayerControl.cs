using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script nay nhan input va goi cac ham event
//Invoke dde hen tgian
public class PlayerControl : MonoBehaviour
{
    public float MovingDirection;
    private float LastMovingDirection;
    public float MoveSpeed;//2
    private float Move;
    private int JumpTimes;
    [SerializeField] int MaxJumpTime;
    public bool IsJump = false;

    public Rigidbody2D PlayerRB;
    public PlayerAnimation PlayerAnimation;
    
    private void Start()
    {
        JumpTimes = 0;
        LastMovingDirection =1f;
}
    private void Update()
    {
        if (Input.GetKey(KeyCode.S)&&JumpTimes==0)
        {
            Move = 0;
            Player.Instance.Attackable = false;
            Block();
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift)&&JumpTimes==0)
        {
            Player.Instance.Attackable = true;
            PlayerAnimation.SetBlockF();
            PlayerRB.AddForce(new Vector2(Player.Instance.Horrizontal * 4, 0), ForceMode2D.Impulse);
            PlayerAnimation.Roll();
        }
        else ControlPlayer();
    } 
    private void FixedUpdate()
    {
        move();
    }
    private void ControlPlayer()
    {
        Player.Instance.Attackable = true;
        PlayerAnimation.SetBlockF();
        if (Input.GetButtonDown("Jump")||Input.GetKeyDown(KeyCode.W))
        {
            if (JumpTimes < MaxJumpTime)
            {
                PlayerRB.velocity = new Vector2(Move, 10f);
                JumpTimes++;
                PlayerAnimation.Jump();
            }
        }//Jump
        MovingDirection = Input.GetAxisRaw("Horizontal");
        Move = MovingDirection * MoveSpeed;
        if (Input.GetMouseButtonDown(0))
        {
            Player.Instance.AttackBySword();
            PlayerAnimation.AttackBySword();
        }//Attack
        if (MovingDirection != LastMovingDirection) ChangeDirrection();
        LastMovingDirection = MovingDirection;
    }
 
    private void move()
    {
        PlayerRB.velocity = new Vector2(Move, PlayerRB.velocity.y);
    }
    public void RenewJumpTime()
    {
        IsJump = false;
        JumpTimes = 0;
        PlayerAnimation.Landed();
    }
    public void BuyRing()
    {
        MaxJumpTime = 2;
        DataManager.Instance.PlayerStatus.BuyRing = true;
        return;
    }
    private void Block()
    {
        PlayerAnimation.Block();
    }
    private void ChangeDirrection()
    {
        PlayerAnimation.ChangeDirrection();
    }
}
