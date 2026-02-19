using UnityEngine;
using UnityEngine.SceneManagement;


namespace Coollel.Fujimura
{
    public class Button : MonoBehaviour
    {
        public GameObject OptionPanel;

        void Start()
        {
            OptionPanel.SetActive(false);
        }

        public void OptionClick()
        {
            OptionPanel.SetActive(true);
        }

        public void OptionCloes()
        {
            OptionPanel.SetActive(false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OptionPanel.SetActive(!OptionPanel.activeSelf);  // 現在の状態を反転
            }
        }


        public void LoadSceneByString(string sceneName)
        {
            SceneManager.LoadScene(sceneName); // 指定したシーンをロード
        }
        public void Quit()
        {
            Debug.Log("ゲーム終了"); // エディタで動作確認用（ビルド後はログ不要）
            Application.Quit(); // ゲームを終了
        }

    }
}
    