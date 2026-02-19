using System;
using Coollel.Stephen;
using TMPro;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    public enum GameState { Start, Playing, GameOver, LevelingUp }
    public GameObject cubePrefab;

    [Header("Game Settings")]
    public TextMeshProUGUI timerText;

    [Header("Wave Settings")]
    [SerializeField] private float waveInterval = 60f;

    //events
    public static event Action OnGameStart;
    public static event Action<float> OnTimeIntervalPassed;
    public static event Action<bool> OnGamePaused;
    public static event Action<bool> OnGameEnd;

    private GameState currentState;
    private float gameTime;
    private float waveTimer;
    private int waveCount;
    private bool isPaused;
    private bool isLevelingUp = false;
    private bool isPlayerAlive = true;

    private void OnEnable()
    {
        PlayerLevelManager.OnStartLevelUp += StartLevelingUp;
        LevelUpPanel.OnPressButton += StopLevelingUp;
    }
    private void OnDisable()
    {
        PlayerLevelManager.OnStartLevelUp -= StartLevelingUp;
        LevelUpPanel.OnPressButton -= StopLevelingUp;
    }

    void Start()
    {
        ChangeState(GameState.Start);
        OnTimeIntervalPassed += StartNewWave;
    }

    void Update()
    {
        // temp esc pause debug, can move it to a diff script if needed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
            Debug.Log($"Pause toggled: {isPaused}");
        }
        if (currentState != GameState.Playing || isPaused || isLevelingUp) return;

        UpdateTimers();
        CheckGameOver();
    }

    void UpdateTimers()
    {
        gameTime += Time.deltaTime;
        timerText.text = FormatTime(gameTime);

        waveTimer += Time.deltaTime;
        if (waveTimer >= waveInterval)
        {
            OnTimeIntervalPassed?.Invoke(waveTimer);
            waveTimer = 0f;
        }
    }

    public void OnPlayerDeath()
    {
        ChangeState(GameState.GameOver);
        isPlayerAlive = false;
    }

    void CheckGameOver()
    {
        if (gameTime >= 120f)
        {
            ChangeState(GameState.GameOver);
        }
    }

    private void ChangeState(GameState newState)
    {
        currentState = newState;
        switch (currentState)
        {
            case GameState.Start:
                InitializeGame();
                break;
            case GameState.Playing:
                OnGameStart?.Invoke();
                break;
            case GameState.GameOver:
                HandleGameOver();
                break;
        }
    }

    private void BoolUnpause(bool bl1, bool bl2)
    {
        Time.timeScale = (bl1 || bl2) ? 0f : 1f;

    }
    public void TogglePause() => SetPause(!isPaused);
    public void SetPause(bool paused)
    {
        isPaused = paused;
        OnGamePaused?.Invoke(isPaused);
        //Time.timeScale = isPaused ? 0 : 1;
        BoolUnpause(isPaused, isLevelingUp);
    }
    public void PauseGame()
    {
        SetPause(true);
    }
    public void UnPauseGame()
    {
        SetPause(false);
    }

    public void SetisLevelingUp(bool isLeveling)
    {
        isLevelingUp = isLeveling;
        BoolUnpause(isPaused, isLevelingUp);
    }
    public void StartLevelingUp()
    {
        SetisLevelingUp(true);
    }
    public void StopLevelingUp()
    {
        SetisLevelingUp(false);
    }

    private void InitializeGame()
    {
        gameTime = 0f;
        waveTimer = 0f;
        waveCount = 0;
        SetPause(false);
        ChangeState(GameState.Playing);
    }

    private void StartNewWave(float timer)
    {
        waveCount++;
        Debug.Log($"Wave {waveCount} started at {timer}");
    }

    private void HandleGameOver()
    {
        SetPause(true);
        Debug.Log($"Game Over! Survival Time: {gameTime}");
        OnGameEnd?.Invoke(isPlayerAlive);
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes}:{seconds:00}";
    }

    public float GetGameTime() => gameTime;
    public bool IsPaused() => isPaused;
}
