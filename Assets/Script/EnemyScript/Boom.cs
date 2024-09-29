using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private float Timer;
    private bool Exploded;
    private Animator Animator;
    private string Name = "Boom";
    [SerializeField] bool CanDelete = false;
    private void Start()
    {
        Animator = GetComponent<Animator>();
        ObjectPooling.Instance.AddToDictionaly(Name, gameObject);
        gameObject.SetActive(false);
    }
    public void Init()
    {
        Timer = 0;
        Exploded = false;
        CanDelete = true;
        Animator.Play("boomAnimation");
    }
    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 1.5f && !Exploded)
        {
            Exploded = true;
            Vector3 PlayerPS = Player.Instance.transform.position;
            Vector2 Distance = PlayerPS - transform.position;
            if (Distance.magnitude < 3f)
            {
                Player.Instance.TakeDmg(50);
            }
        }
        else if (Timer >= 1.75f&&CanDelete)
        {
            ObjectPooling.Instance.die(gameObject, Name);
            gameObject.SetActive(false);
        }
    }
}
