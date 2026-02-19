using System;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public float CurrentTime { get; private set; }

    [SerializeField] private int _timeInterval = 10;

    public event Action<float> OnInvervalPassed;
    public event Action<float> OnTick;

    private float _tickTimer;
    private float _invervalTimer;

    private void Start()
    {
        OnInvervalPassed?.Invoke(default);
        OnTick?.Invoke(default);
    }

    public void Update()
    {
        var deltaTime = Time.deltaTime;
        CurrentTime += deltaTime;

        _tickTimer += deltaTime;
        if (_tickTimer > 1)
        {
            _tickTimer -= 1;
            OnTick?.Invoke(CurrentTime);
        }

        _invervalTimer += deltaTime;
        if (_invervalTimer > _timeInterval)
        {
            _invervalTimer -= _timeInterval;
            OnInvervalPassed?.Invoke(CurrentTime);
        }
    }

    public void SubscribeToIntervalPassed(Action<float> callback) => OnInvervalPassed += callback;
    public void UnsubscribeFromIntervalPassed(Action<float> callback) => OnInvervalPassed += callback;

    public void SubscribeToTick(Action<float> callback) => OnTick += callback;
    public void UnsubscribeFromTick(Action<float> callback) => OnTick -= callback;
}