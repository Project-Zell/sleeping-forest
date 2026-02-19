using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerUpgradeSelecorElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _upgradeName;
    [SerializeField] private TextMeshProUGUI _upgradeDescription;
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;

    public void Initialize(Action callback)
    {
        _button.onClick.AddListener(new UnityAction(callback));
    }

    public void ShowUpgradeSelection(string upgradeName, string upgradeDescription, Sprite sprite)
    {
        _upgradeName.text = upgradeName;
        _upgradeDescription.text = upgradeDescription;
        _image.sprite = sprite;
    }

    public void Enable() => gameObject.SetActive(true);
    public void Disable() => gameObject.SetActive(false);
}
