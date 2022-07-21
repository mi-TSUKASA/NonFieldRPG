using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//PlayerとEnemy対戦の管理
public class BattleManager : MonoBehaviour
{
    public Transform playerDamagePanel;
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
            StartCoroutine(EndBattle());
        }
        else
        {
            //SoundManager.instance.PlaySE(1);
            StartCoroutine(EnemyAttack());
        }
    }

    IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(1f);
        //EnemyがPlayerに攻撃
        SoundManager.instance.PlaySE(1);
        playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }

    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(1f);
        Destroy(enemy.gameObject);
        SoundManager.instance.PlayBGM("Quest");
        questManager.EndBattle();
        enemyUI.gameObject.SetActive(false);
    }
}
