using UnityEngine;

public class AiPaddle : MonoBehaviour
{
    public Transform target;
    public Vector3 sliderAxis = Vector3.up;
    public float minPosition = -5f;
    public float maxPosition = 5f;
    public float followSpeed = 3f; // units/sec — lower = slower, more beatable opponent

    public float AISliderPos { get; private set; }

    void Update()
    {
        if (target == null) return;

        int index = GetAxisIndex(sliderAxis);

        float targetValue = target.position[index];
        float currentValue = transform.position[index];

        float newValue = Mathf.MoveTowards(currentValue, targetValue, followSpeed * Time.deltaTime);
        newValue = Mathf.Clamp(newValue, minPosition, maxPosition);

        AISliderPos = newValue;

        Vector3 newPos = transform.position;
        newPos[index] = newValue;

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