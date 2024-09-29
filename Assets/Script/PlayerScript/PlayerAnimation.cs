using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script control animation and sound
public class PlayerAnimation : MonoBehaviour
{
    public GameObject HPbarwarn;
    private int AttTime = 0;
    Animator Animator;
    public SpriteRenderer SR;
    private float LastDirection;
    private PlayerControl PlayerControl;
    private Transform FlashTransform;
    void Start()
    {
        Animator = GetComponent<Animator>();
        PlayerControl = GetComponent<PlayerControl>();
        FlashTransform = transform.GetChild(1);
    }
    public void ChangeDirrection()
    {
        {
            if(PlayerControl.MovingDirection != 0)
            {
                Animator.SetBool("IsRun", true);
            }
            else Animator.SetBool("IsRun", false);
            if (PlayerControl.MovingDirection < 0)
            {
                FlashTransform.localEulerAngles = new Vector3(0, 0, 90);
                SR.flipX = true;
                Player.Instance.Horrizontal = -1;
            }
            else if(PlayerControl.MovingDirection > 0)
            {
                FlashTransform.localEulerAngles = new Vector3(0, 0, -90);
                SR.flipX = false;
                Player.Instance.Horrizontal = 1;
            }
        }      
    }
    public void AttackBySword()
    {
        AttTime = (AttTime+1) % 3;
        Animator.Play("Attack" + AttTime.ToString());
//        Animator.Play("Throw");
    }
    public void Block()
    {
        Animator.SetBool("Block", true);
        Animator.Play("IdleBlock");
    }
    public void Hurt()
    {
        Animator.Play("Hurt");
    }
    public void Die()
    {
        PlayerControl.enabled = false;
        Animator.Play("Death");
        GetComponent<Player>().enabled = false;
        SaveLoad.Instance.SaveInventory();
    }
    public void HPbarWarn(float temp)
    {
        HPbarwarn.SetActive(true);
    }
    public void Jump()
    {
        Animator.Play("Jump");
        Animator.SetBool("IsGround", false);
        AudioControler.Instance.SetEffectVoice("Jump");
    }
    public void Roll()
    {
        AudioControler.Instance.SetEffectVoice("Roll");
        Animator.Play("Roll");
        StartCoroutine(PausePlayerControl());
    }
    private IEnumerator PausePlayerControl()
    {
        PlayerControl.enabled = false;
        yield return new WaitForSeconds(0.7f);
        PlayerControl.enabled = true;

    }
    public void Landed()
    {
        Animator.SetBool("IsGround", true);
        AudioControler.Instance.SetEffectVoice("Landing");
    }
    public void SetBlockF()
    {
        Animator.SetBool("Block", false);
    }
    public void Climb()
    {
        Animator.Play("Climb");
    }
}
