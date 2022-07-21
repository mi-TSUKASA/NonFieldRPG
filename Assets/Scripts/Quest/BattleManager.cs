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
    public QuestManager questManager;

    private void Start()
    {
        enemyUI.gameObject.SetActive(false);
    }

    public void SetUp(EnemyManager enemyManager)
    {
        SoundManager.instance.PlayBGM("Battle");
        enemyUI.gameObject.SetActive(true);
        enemy = enemyManager;
        enemyUI.SetUpUI(enemy);
        playerUI.SetUpUI(player);

        enemy.AddEventListenerOnTap(PlayerAttack);
    }
    
    void PlayerAttack()
    {
        SoundManager.instance.PlaySE(1);
        // PlayerがEnemyに攻撃
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
        if (enemy.hp <= 0)
        {
            Destroy(enemy.gameObject);
            EndBattle();
        }
        else
        {
            //SoundManager.instance.PlaySE(1);
            EnemyAttack();
        }
    }

    void EnemyAttack()
    {
        //EnemyがPlayerに攻撃
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }

    void EndBattle()
    {
        SoundManager.instance.PlayBGM("Quest");
        questManager.EndBattle();
        enemyUI.gameObject.SetActive(false);
        Debug.Log("撃破");
    }
}
