using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵を管理する
public class EnemyManager : MonoBehaviour
{
    public new string name;
    public int hp;
    public int at;
    //攻撃関数
    public void Attack(PlayerManager player)
    {
        player.Damage(at);
    }
    //ダメージ関数
    public void Damage(int damage)
    {
        hp -= damage;
    }

    public void OnTap()
    {
        Debug.Log("クリックされた");
    }
}
