using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private CharacterUnit _characterUnit;
    [SerializeField] private RectTransform _statHolder;
    [SerializeField] private StatDisplayElement _statDisplayPrefab;

    public void Start()
    {
        foreach (var stat in _characterUnit.Stats.Stats)
        {
            var displayPrefab = Instantiate(_statDisplayPrefab, _statHolder);
            displayPrefab.Initialize(stat, stat.Type.ToString());
        }
    }
}
