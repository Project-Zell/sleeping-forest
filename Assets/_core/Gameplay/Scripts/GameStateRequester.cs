using System;
using UnityEngine;

public abstract class GameStateRequester : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    private Guid _guid;

    private void Awake() => _guid = Guid.NewGuid();
    protected void RequestPause() => _gameManager.RequestPause(_guid);
    protected void RequestUnpause()=> _gameManager.RequestUnpause(_guid);
}