using TMPro;
using UnityEngine;

public class StatDisplayElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _statNameText;
    [SerializeField] private TextMeshProUGUI _statValueText;
    private UnitStat _stat;

    public void Initialize(UnitStat stat, string nameKey)
    {
        _stat = stat;
        _stat.OnStatChanged += Refresh;
        if(_statNameText != null)
            _statNameText.text = nameKey;
        Refresh();
    }

    public void Refresh()
    {
        _statValueText.text = _stat.GetCurrentValueString();
    }

    private void OnDestroy()
    {
        _stat.OnStatChanged -= Refresh;
    }
}