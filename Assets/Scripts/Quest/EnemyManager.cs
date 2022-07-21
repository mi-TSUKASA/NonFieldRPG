using System;
using UnityEngine;
using DG.Tweening;

//敵を管理する
public class EnemyManager : MonoBehaviour
{
    //関数登録
    Action tapAction; //クリックされたときに実行されたい関数（外部から設定したい）
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
        transform.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
    }

    //tapActionに関数を登録する関数を作る
    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;
    }

    public void OnTap()
    {
        tapAction(); 
    }
}
