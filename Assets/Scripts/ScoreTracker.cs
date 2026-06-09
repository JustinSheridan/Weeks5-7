using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    // public Slider scoreSlider;
    public TMP_Text currentScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnSliderChanged(float scoreValue)
    {
        // currentScoreText.text = "Score: " + scoreSlider.value;
        Debug.Log("On");
        currentScoreText.text="Score: "+scoreValue;
    }
}