using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Singleton<Player>, DamageAble
{
    [SerializeField] int maxHP;
    private int CurrentHP;
    public Image HPbar;
    public PlayerAnimation PlayerAnimation;
    public int Horrizontal;//This show where player look at;
    public int SwordDmg=70;
    public bool Attackable=true;
    RaycastHit2D[] hit;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        CurrentHP = maxHP;
        Horrizontal = 1;
    }

    public void AddPlayerHP(int addhp)
    {
        CurrentHP += addhp;
        if (CurrentHP > maxHP) CurrentHP = maxHP;
        HPbarCheck();
        Debug.Log("CurrentHp +" +CurrentHP);
    }
    public void TakeDmg(int EnemyDamage)
    {
        AudioControler.Instance.SetEffectVoice("Hit");
        if (Attackable == true)
        {
            CurrentHP -= EnemyDamage;
            PlayerAnimation.Hurt();
            if (CurrentHP <= 0)
            {
                PlayerAnimation.Die();
                Invoke("Respown", 1f);
            }
            HPbarCheck();
            Debug.Log("CurrentHp" + CurrentHP);
        }
    }
    private void HPbarCheck()
    {
        float temp = (float)CurrentHP / (float)maxHP;
        HPbar.fillAmount = temp;
        if (temp <= 0.4f)
        {
            GetComponent<PlayerAnimation>().HPbarWarn(temp);
        }
    }
    public void AttackBySword()
    {
        float SizeX = transform.localScale.x;
        float SizeY = transform.localScale.y;

        Vector3 Temp = transform.position;
        Vector2 AttPoint = new Vector2(Temp.x + 0.65f * SizeX*Horrizontal, Temp.y + 0.65f * SizeY + 0.02f);//tranh cham dat
        hit = Physics2D.BoxCastAll(AttPoint,new Vector2(2* 0.35f * SizeX, 2* 0.65f * SizeY),0,new Vector2(0,0), GlobalVariable.EnemyLayer);//BoxCastAll are Error or my error
        if(hit.Length != 0)
        {
            foreach(RaycastHit2D n in hit)
            {
                if (n.collider.gameObject.CompareTag("Enemy"))
                {
                    n.collider.gameObject.GetComponent<DamageAble>().TakeDmg(SwordDmg);
                }
            }
        }
    }
    public void Teleport(Vector3 Taget)
    {
        transform.position = Taget;
    }
    public void Respown()
    {
        GlobalVariable.IsLoad = true;
        CurrentHP = maxHP;
        SceneManager.LoadScene("lever1");
    }

    private void OnApplicationQuit()
    {
        SaveLoad.Instance.SaveInventory();
    }

}


