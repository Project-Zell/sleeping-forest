using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Image _healthBar;
    [SerializeField] private PlayerHealthChannel _channel;

    private void Awake() => Initialize();
    private void OnEnable() => _channel.Subscribe((health) => UpdateHealthBar(health));
    private void OnDisable() => _channel.Subscribe((health) => UpdateHealthBar(health));

    private void Initialize()
    {
        _healthBar.fillAmount = 1;
    }

    private void UpdateHealthBar(IHealth health)
    {
        _healthBar.fillAmount = GetHealthBarFill(health.CurrentHealth, health.MaxHealth);
        _healthText.text = GetHealthString(health.CurrentHealth, health.MaxHealth);
    }

    private float GetHealthBarFill(int currentHealth, int maxHealth)
    {
        return (float)currentHealth / (float)maxHealth;
    }

    private string GetHealthString(int currentHealth, int maxHealth)
    {
        return $"{currentHealth}/{maxHealth}";
    }
}
