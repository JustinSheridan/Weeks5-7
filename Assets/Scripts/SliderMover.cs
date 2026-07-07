using UnityEngine;

public class SliderMover : MonoBehaviour
{
    [Header("References")]
    public SliderInput sliderInput;

    [Header("Movement Settings (2D)")]
    public Vector3 sliderAxis = Vector3.up; 
    public float minPosition = -5f; 
    public float maxPosition = 5f;
    
    public float PlayerSliderPos { get; private set; }

    void Start()
    {
        if (sliderInput != null)
        {
            sliderInput.OnValueChanged += OnSliderChanged;
        }
    }

    public void OnSliderChanged(float value)
    {
        PlayerSliderPos = Mathf.Lerp(minPosition, maxPosition, value);
        
        // Update Pos with 
        Vector3 newPos = transform.position;
        
        int index = GetAxisIndex(sliderAxis);
        newPos[index] = PlayerSliderPos;
        
        transform.position = newPos;
    }

    private int GetAxisIndex(Vector3 axis)
    {
        if (axis == Vector3.right || axis == Vector3.left) return 0; // X
        if (axis == Vector3.up || axis == Vector3.down) return 1;   // Y
        if (axis == Vector3.forward || axis == Vector3.back) return 2; // Z
        return 0;
    }
}