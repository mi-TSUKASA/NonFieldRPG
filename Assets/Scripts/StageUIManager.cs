using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ステージのUI管理
public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public void UpdateText(int currentStage)
    {
        stageText.text = string.Format("ステージ：{0}", currentStage);
    }
    
}
