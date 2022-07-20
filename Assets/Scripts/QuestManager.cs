using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//クエスト全体を管理 
public class QuestManager : MonoBehaviour
{
    int currentStage; //現在のステージ進行後

    //NextButtonが押されたら
    public void OnNextButton()
    {
        currentStage++;
        Debug.Log(currentStage);
    }
}
