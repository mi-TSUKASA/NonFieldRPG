using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int hp;
    public int at;
    //攻撃関数
    public void Attack(EnemyManager enemy)
    {
        enemy.Damage(at);
    }
    //ダメージ関数
    public void Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
    }

}
