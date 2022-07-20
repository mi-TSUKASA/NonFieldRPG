using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerとEnemy対戦の管理
public class BattleManager : MonoBehaviour
{
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    EnemyManager enemy;

    public void SetUp(EnemyManager enemyManager)
    {
        enemy = enemyManager;
        enemyUI.SetUpUI(enemy);
        playerUI.SetUpUI(player);
    }
    
    void PlayerAttack()
    {
        // PlayerがEnemyに攻撃
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
    }

    void EnemyAttack()
    {
        //EnemyがPlayerに攻撃
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }
}
