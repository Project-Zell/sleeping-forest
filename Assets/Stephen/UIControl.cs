using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    private TextMeshProUGUI m_TextMeshPro;
    public void SetAlpha(float alpha)
    {
        if (m_TextMeshPro == null)
        {
            m_TextMeshPro = GetComponent<TextMeshProUGUI>();
        }
        m_TextMeshPro.alpha = alpha;
    }

    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
