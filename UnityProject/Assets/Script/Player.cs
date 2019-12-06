using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour   
{
    string text;

    [Header("血量")]
    public float hp = 100;
    private float hurtHp;

    [Header("攻擊力")]
    public int atk;

    [Header("喇叭")]
    public AudioSource aud;

    [Header("音效")]
    public AudioClip soundAtk;

    [Header("殭屍")]
    public Zombie zombie;

    [Header("")]
    public Transform tra;

    /// <summary>
    /// 攻擊
    /// </summary>
    public void Attack()
    {
        if (hp <= 0)
        {
            print("玩家想幹嘛？死了還想打人！");
            return;
        }
        zombie.Hurt();        
    }

    /// <summary>
    /// 受傷
    /// </summary>
    public void Hurt()
    {
        if (hp <= 0)
        {
            Dead();
            return;
        }
        
        hurtHp = UnityEngine.Random.Range(5, 20);
        print("<color=blue>" + "玩家受到傷害: " + hurtHp + "</color>");
        hp -= hurtHp;
        print("<color=blue>" + "玩家剩下血量: " + hp + "</color>");

        if (hp <= 0) Dead();
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {
        print("<color=aqua>玩家死了！玩家死了！別再打了！</color>");
        tra.eulerAngles = new Vector3(-90, 0, 0);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Attack();
        } 
    }
}
