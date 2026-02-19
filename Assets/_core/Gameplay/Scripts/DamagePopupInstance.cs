using TMPro;
using UnityEngine;

public class DamagePopupInstance : MonoBehaviour
{
    [SerializeField] private DamagePopupTween _tween;
    [SerializeField] private TextMeshPro _text;

    public void Initialize() => _tween.Initialize(_text, this);

    public void Activate(int damage)
    {
        gameObject.SetActive(true);
        _text.text = $"{damage}";
        _tween.Play();
    }

    public void SetPosition(Vector3 position) => transform.position = position;

    public void Deactivate() => gameObject.SetActive(false);

}