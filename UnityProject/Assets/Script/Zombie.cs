using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [Header("血量")]
    public float hp = 100;
    private float hurtHp;

    [Header("攻擊力")]
    public int atk;

    [Header("喇叭")]
    public AudioSource aud;

    [Header("音效")]
    public AudioClip soundAtk;

    [Header("玩家")]
    public Player player;

    [Header("")]
    public Transform tra;

    /// <summary>
    /// 攻擊
    /// </summary>
    public void Attack()
    {
        if (hp <= 0)
        {
            print("殭屍想幹嘛？死了還想打人！");
            return;
        }

        player.Hurt();
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
        hurtHp = Random.Range(5, 20);
        print("<color=red>" + "殭屍受到傷害: " + hurtHp + "</color>");
        hp -= hurtHp;
        print("<color=red>" + "殭屍剩下血量: " + hp + "</color>");

        if (hp <= 0) Dead();
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {
        tra.eulerAngles = new Vector3(-90, 0, 180);
        print("<color=fuchsia>殭屍死了！殭屍死了！別再打了！</color>");

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Attack();
        }
    }
}
