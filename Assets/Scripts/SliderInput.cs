using UnityEngine;
using UnityEngine.UI;

public class SliderInput : MonoBehaviour
{
    public Slider scoreSlider;
    
    // Declare the event
    public event System.Action<float> OnValueChanged;
 
    void Start()
    {
        if (scoreSlider != null)
        {
            // Listen to the Slider
            scoreSlider.onValueChanged.AddListener(OnSliderChanged);
        }
    }

    private void OnSliderChanged(float value)
    {
        // Listen for and invoke slider value
        OnValueChanged?.Invoke(value);
    }
}