using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    private int Direction;
    private PlayerAnimation Animator;
    private int UpDown;
    private Rigidbody2D ThisRB;
    private void Awake()
    {
        Animator = GetComponent<PlayerAnimation>();
        ThisRB = GetComponent<Rigidbody2D>();
    }
    public void Init()
    {
        if(Animator == null) Animator = GetComponent<PlayerAnimation>();
        Animator.Climb();
        if (gameObject.GetComponent<SpriteRenderer>().flipX) Direction = 1;
        else Direction = -1;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) UpDown = 2;
        else { UpDown = -3; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Animator.Jump();
            ThisRB.AddForce(new Vector2(Direction * 15, 0), ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        ThisRB.velocity = new Vector2(ThisRB.velocity.x, UpDown);
    }
}
