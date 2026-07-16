using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    
    public float timeLimit = 120f; // 2 minute
    private float currentTime;

    void Start()
    {
        currentTime = timeLimit;
        
        if (timerText != null)
        {
            UpdateTimerDisplay();
        }
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            
            if (currentTime < 0) currentTime = 0;
            
            UpdateTimerDisplay();
        }
        else
        {
            // Timer finished
            OnTimerFinished();
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
    }

    void OnTimerFinished()
    {
        Debug.Log("Time's up!");

        // Quit the game
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}