using TMPro;
using UnityEngine;

public class GameOverHUD : MonoBehaviour
{
    [SerializeField] private Canvas _deathCanvas;

    public void ToggleCanvas()
    {
        _deathCanvas.gameObject.SetActive(!_deathCanvas.isActiveAndEnabled);
    }
}
