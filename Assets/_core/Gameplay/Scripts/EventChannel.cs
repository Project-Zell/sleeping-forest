using System;
using UnityEngine;

public class EventChannel<T> : ScriptableObject
{
    private event Action<T> _onChannelUpdate;

    public void RaiseEvent(T input) => _onChannelUpdate?.Invoke(input);
    public void Subscribe(Action<T> callback) => _onChannelUpdate += callback;

    public void Unsubscribe(Action<T> callback) => _onChannelUpdate -= callback;
}
