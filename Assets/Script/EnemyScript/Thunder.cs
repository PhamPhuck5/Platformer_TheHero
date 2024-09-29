using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    private float Timer = 0;
    private bool IsDame = false;
    private string Name = "Thunder";
    private Animator Animator;
    private bool CanDelete = false;

    private void Start()
    {
        ObjectPooling.Instance.AddToDictionaly(Name, gameObject);
        Animator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }
    public void Init()
    {
        IsDame = false;
        Timer = 0;
        Animator.Play("Thunder");
        CanDelete = true;
        transform.position = Player.Instance.transform.position;

    }
    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > 0.3f && !IsDame)
        {
            IsDame = true;
            RaycastHit2D[] Temp = Physics2D.RaycastAll(transform.position, Vector2.up, 1f);
            for (int i = 0; i < Temp.Length; i++)
            {
                if (Temp[i].collider != null)
                {
                    if (Temp[i].collider.CompareTag("Player"))
                    {
                        Player.Instance.TakeDmg(15);
                    }
                }
            }
        }
        else if (Timer >= 1f && CanDelete)
        {
            ObjectPooling.Instance.die(this.gameObject, Name);
            gameObject.SetActive(false);
        }
    }
}
