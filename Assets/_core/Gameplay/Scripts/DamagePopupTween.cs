using DG.Tweening;
using TMPro;
using UnityEngine;

public class DamagePopupTween : MonoBehaviour
{
    [SerializeField] private float _startingOffset;
    private Sequence _sequence;

    public void Initialize(TextMeshPro textMeshPro, DamagePopupInstance instance)
    {
        _sequence = DOTween.Sequence();
        _sequence.SetAutoKill(false);
        _sequence.Pause();

        var transform = textMeshPro.transform;

        _sequence.Append(textMeshPro.DOFade(0, 0))
            .Append(transform.DOMoveY(_startingOffset, 0))
            .Append(textMeshPro.DOFade(1, 0.15f))
            .Join(transform.DOMoveY(_startingOffset + 0.25f, 0.5f))
            .Append(transform.DOMoveY(_startingOffset + 0.275f, 1f))
            .Append(textMeshPro.DOFade(0, 0.15f));

        _sequence.OnComplete(() => instance.Deactivate());
    }

    public void Play() => _sequence.Restart();
}
