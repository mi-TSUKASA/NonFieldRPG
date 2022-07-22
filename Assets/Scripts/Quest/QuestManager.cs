using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//クエスト全体を管理 
public class QuestManager : MonoBehaviour
{
    int[] encountTable = { -1, -1, 0, -1, 0, -1 }; //敵に遭遇するテーブル（-1なら遭遇しない、0なら遭遇）
    int currentStage; //現在のステージ進行後
    public StageUIManager stageUI;
    public GameObject enemyPrefab;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransition;
    public GameObject questBG;


    private void Start()
    {
        stageUI.UpdateText(currentStage);
    }

    //NextButtonが押されたら
    public void OnNextButton()
    {
        //背景を大きく
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f)
            .OnComplete(() => questBG.transform.localScale= new Vector3(1, 1, 1));
        currentStage++;

        //フェードアウト
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 1f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0f));
        stageUI.UpdateText(currentStage);
        SoundManager.instance.PlaySE(0);

        if (encountTable.Length <= currentStage)
        {
            SoundManager.instance.PlaySE(2);
            SoundManager.instance.StopBGM();
            QuestClear();
            Debug.Log("クリア");
        }
        else if (encountTable[currentStage] == 0)
        {
            EncountEnemy();
            
        }
    }

    public void OnToTownButton()
    {
        SoundManager.instance.PlaySE(0);
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
