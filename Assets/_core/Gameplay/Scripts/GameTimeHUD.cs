using TMPro;
using UnityEngine;

public class GameTimeHUD : MonoBehaviour
{
    [SerializeField] private GameTime _gameTimer;
    [SerializeField] private TextMeshProUGUI _gameTimerHUD;

    public void OnEnable()
    {
        _gameTimer.SubscribeToTick((time) => UpdateGameTime(time));
    }
    public void OnDisable()
    {
        _gameTimer.UnsubscribeFromTick((time) => UpdateGameTime(time));
    }

    public void UpdateGameTime(float time)
    {
        _gameTimerHUD.text = TimeFormat(time);
    }

    public string TimeFormat(float time)
    {
        return $"{Mathf.FloorToInt(time / 60):00}:{Mathf.FloorToInt(time % 60):00}";
    }
}
