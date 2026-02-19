using UnityEngine;
using UnityEngine.UI;

public class ExpirienceHUD : MonoBehaviour
{
    [SerializeField] private ExperienceGainChannel _experienceGainChannel;
    [SerializeField] private Image _barFill;

    private void OnEnable() => _experienceGainChannel.Subscribe(ChangeExpBar);
    private void OnDisable() => _experienceGainChannel.Unsubscribe(ChangeExpBar);

    private void ChangeExpBar(ExperienceGainContainer container)
    {
        var fillValue = (float)container.CurrentExperience / (float)container.MaxExperience;
        _barFill.fillAmount = fillValue;
    }
}
