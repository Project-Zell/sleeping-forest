using UnityEngine;
using UnityEngine.SceneManagement;

public class EscMenuUI : GameStateRequester
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private string mainMenuSceneName;
    [SerializeField] private Canvas _settingCanvas;

    public void Awake()

    {
        if (_canvas == null||_settingCanvas == null) Debug.LogWarning("Please assign canvas");
        if(_settingCanvas.isActiveAndEnabled) _settingCanvas.enabled = false;
        if(_canvas.isActiveAndEnabled == true) _canvas.enabled = false;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_canvas.enabled) Close();
            else Open();
        }
    }
    public void Open()
    {
        _canvas.enabled = true;
        RequestPause();
    }

    public void Close()
    {
        _canvas.enabled = false;
        RequestUnpause();
    }

    public void Unpause() => RequestUnpause();

    public void OpenSettings()
    {
        _canvas.enabled = false;
        _settingCanvas.enabled = true;
    }
    public void CloseSettings()
    {
        _canvas.enabled = false;
        _settingCanvas.enabled = true;
    }
    public void Return()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
