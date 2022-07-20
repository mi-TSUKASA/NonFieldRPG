using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ステージのUI管理
public class StageUIManager : MonoBehaviour
{
    public Text stageText;
    public GameObject nextButton;
    public GameObject toTownButton;
    public GameObject clearText;

    private void Start()
    {
        clearText.SetActive(false);
    }

    public void UpdateText(int currentStage)
    {
        stageText.text = string.Format("ステージ：{0}", currentStage+1);
    }

    public void HydeButtons()
    {
        nextButton.SetActive(false);
        toTownButton.SetActive(false);
    }

    public void ShowButtons()
    {
        nextButton.SetActive(true);
        toTownButton.SetActive(true);
    }

    public void ShowClearText()
    {
        clearText.SetActive(true);
        nextButton.SetActive(false);
        toTownButton.SetActive(true);
    }

}
