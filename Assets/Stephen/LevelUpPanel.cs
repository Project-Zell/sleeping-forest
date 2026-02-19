using System;
using Coollel.Stephen;
using UnityEngine;

public class LevelUpPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject levelUpPanel;
    public static event Action OnPressButton;

    private void OnEnable()
    {
        PlayerLevelManager.OnStartLevelUp += ActivatePanel;
    }
    private void OnDisable()
    {
        PlayerLevelManager.OnStartLevelUp -= ActivatePanel;
    }

    public void InitPanel()
    {
        ActivatePanel();
    }

    private void ActivatePanel()
    {
        levelUpPanel.SetActive(true);
    }

    public void PressButton()
    {
        levelUpPanel.SetActive(false);
        OnPressButton?.Invoke();
    }
}
