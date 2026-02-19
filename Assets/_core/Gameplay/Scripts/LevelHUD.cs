using UnityEngine;
using TMPro;

public class LevelHUD : MonoBehaviour
{
    [SerializeField] private LevelUpChannel _levelUpChannel;
    [SerializeField] private TextMeshProUGUI _counter;

    private void OnEnable() => _levelUpChannel.Subscribe(UpdateLevelCounter);
    private void OnDisable() => _levelUpChannel.Unsubscribe(UpdateLevelCounter);

    private void UpdateLevelCounter(int level) => _counter.text = $"{level}";
}
