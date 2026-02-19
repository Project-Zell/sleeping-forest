using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // ポーズメニューの UI (Inspector で設定)

    public static bool isPaused = false;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuUI.SetActive(isPaused); // ポーズメニューの表示・非表示を切り替え

        Time.timeScale = isPaused ? 0 : 1; // ゲームの進行を止める (ポーズ時)
    }
}