using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour, DamageAble
{
    protected int maxHP;
    public int CurrentHP;
    protected int Dmg;
    public int MoveSpeed;
    public UnityEngine.UI.Image HPbar;
    protected string Name;
    [SerializeField] protected int Reward;

    public void TakeDmg(int playerdamage)
    {
        CurrentHP -= playerdamage;
        if (CurrentHP < 0)
        {
            CurrentHP = 0;
        }
        if (CurrentHP == 0)
        {
            Die();
        }
        HPbar.fillAmount = (float)CurrentHP / (float)maxHP;
    }
    protected virtual void Die()
    {
        DataManager.Instance.PlayerStatus.money += Reward;
        InventoryManager.Instance.UpdateCoinAmount();
        ObjectPooling.Instance.die(this.gameObject,Name);
    }
    abstract public void Move();
    virtual public void Attack()
    {
        
    }
    public void Respown()
    {
        CurrentHP = maxHP;
        HPbar.fillAmount = (float)CurrentHP / (float)maxHP;
        float x;
        x = Random.Range(-2f, 10f);
        RaycastHit2D ray = Physics2D.Raycast(new Vector2(x, 10), Vector2.down);
        transform.position = new Vector3(x, ray.point.y + 0.3f, 0);
        gameObject.SetActive(true);
        return;
    }

}
/* private bool CanRespawn(float x)
{
    Vector2 CheckHit = new Vector2(x, 10);
    Vector2 Checkspace = new Vector2(0.3f, 0);

    RaycastHit2D ray1 = Physics2D.Raycast(CheckHit - Checkspace, Vector2.down, 15f);
    RaycastHit2D ray2 = Physics2D.Raycast(CheckHit, Vector2.down, 15f);
    RaycastHit2D ray3 = Physics2D.Raycast(CheckHit + Checkspace, Vector2.down, 15f);

    if (ray1.collider != null && ray2.collider != null && ray3.collider != null)
    {
        if (Mathf.Abs(ray1.point.x - ray2.point.x) <= 0.1f && Mathf.Abs(ray1.point.x - ray3.point.x) <= 0.1f)
        {
            return true;
        }
    }

    return false;
}

public void Respawn()
{
    CurrentHP = maxHP;
    float x;
    while (true)
    {
        x = Random.Range(-2f, 10f);
        if (CanRespawn(x))
        {
            RaycastHit2D ray = Physics2D.Raycast(new Vector2(x, 10), Vector2.down);

            if (ray.collider != null)
            {
                transform.position = new Vector3(x, ray.point.y + 0.3f, 0);
                gameObject.SetActive(true);
                return;
            }
        }
    }
}*/
