using UnityEngine;
using TMPro;
public class TimerDisplay : MonoBehaviour
{
    float inGameTime = 0;
    public TextMeshProUGUI timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inGameTime += Time.deltaTime;

        timer.text = Mathf.FloorToInt(inGameTime / 60f) .ToString("00") + " : " + Mathf.FloorToInt(inGameTime % 60f).ToString("00");
    }
}
