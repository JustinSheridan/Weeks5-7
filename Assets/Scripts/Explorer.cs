using UnityEngine;
using UnityEngine.InputSystem;

public class Explorer : MonoBehaviour
{
    public float health;
    public float speed;
    public int treasure;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToMove = Vector3.zero;

        //This is the constructor for Vector3
        directionToMove = new Vector3(0, 0, 0);

        if(Keyboard.current.leftArrowKey.isPressed)
        {
            directionToMove.x -= 1f;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            directionToMove.x += 1f;
        }

        if (Keyboard.current.upArrowKey.isPressed)
        {
            directionToMove.y += 1f;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            directionToMove.y -= 1f;
        }

        transform.position += directionToMove * speed * Time.deltaTime;
    }

    public void TakeDamage()
    {
        health -= 1;
    }

    public void SlowDown()
    {
        speed -= 3f;
    }

    public void SpeedUp()
    {
        speed += 3f;
    }

}