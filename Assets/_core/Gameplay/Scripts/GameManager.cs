using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameTime _timer;

    private HashSet<Guid> _pauseRequesters = new();
    public bool IsPaused => _pauseRequesters.Count > 0;

    private event Action OnGameStart;
    private event Action OnGameEnd;

    private event Action<bool> OnPauseStateChangeTo;

    public void SubscribeToGameStart(Action callback) => OnGameStart += callback;
    public void UnsubscribeFromGameStart(Action callback) => OnGameStart -= callback;

    public void SubscribeToGameEnd(Action callback) => OnGameEnd += callback;
    public void UnsubscribeFromGameEnd(Action callback) => OnGameEnd -= callback;

    public void SubscribeToPauseStateChangeTo(Action<bool> callback) => OnPauseStateChangeTo += callback;
    public void UnsubscribeFromPauseStateChangeTo(Action<bool> callback) => OnPauseStateChangeTo -= callback;

    public void InitializeGame()
    {
        OnGameStart?.Invoke();
    }

    public void RequestPause(Guid source)
    {
        _pauseRequesters.Add(source);
        UpdatePauseState();
    }

    public void RequestUnpause(Guid source)
    {
        _pauseRequesters.Remove(source);
        UpdatePauseState();
    }

    private void UpdatePauseState()
    {
        var updatedTimeScale = IsPaused ? 0 : 1;
        if (Time.timeScale != updatedTimeScale)
        {
            OnPauseStateChangeTo?.Invoke(IsPaused);
            Time.timeScale = updatedTimeScale;
        }
    }

    public int interval = 5;
    private void HandleTimePassed(float time)
    {
        if(Math.Floor(time%interval) == 0)
        {
            Debug.Log("Interval Passed");
        }
    }
}