using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private void OnEnable() => GameFlowManager.OnGameEnd += ChooseUI;
    private void OnDisable() => GameFlowManager.OnGameEnd -= ChooseUI;

    public void ChooseUI(bool hasWon)
    {
        if (hasWon)
        {
            DisplayVictoryUI();
        }
        else
        {
            DisplayLossUI();
        }
    }

    public void DisplayVictoryUI()
    {
        print("Display win UI");
    }
    public void DisplayLossUI()
    {
        print("Display loss UI");
    }
}
