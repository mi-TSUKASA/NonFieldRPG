using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//クエスト全体を管理 
public class QuestManager : MonoBehaviour
{
    int[] encountTable = { -1, -1, 0, -1, 0, -1 }; //敵に遭遇するテーブル（-1なら遭遇しない、0なら遭遇）
    int currentStage; //現在のステージ進行後
    public StageUIManager stageUI;
    public GameObject enemyPrefab;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransition;


    private void Start()
    {
        stageUI.UpdateText(currentStage);
    }

    //NextButtonが押されたら
    public void OnNextButton()
    {
        currentStage++;
        stageUI.UpdateText(currentStage);

        if (encountTable.Length <= currentStage)
        {
            QuestClear();
            Debug.Log("クリア");
        }
        else if (encountTable[currentStage] == 0)
        {
            EncountEnemy();
            
        }
    }

    //敵に遭遇したらEnemyプレハブを生成
    void EncountEnemy()
    {
        stageUI.HydeButtons();
        GameObject enemyObj = Instantiate(enemyPrefab);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.SetUp(enemy);
    }

    public void EndBattle()
    {
        stageUI.ShowButtons();
    }

    void QuestClear()
    {
        //クエストクリアを表示する
        //街の戻るボタンのみ表示する
        stageUI.ShowClearText();
        //sceneTransition.LoadTo("Town");
    }
}
