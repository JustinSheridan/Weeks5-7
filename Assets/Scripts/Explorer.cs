using UnityEngine;
using UnityEngine.InputSystem;

public class Explorer : MonoBehaviour
{
    public float health;
    public float speed;
    public int treasure;

    [Header("Thorns Settings")]
    public float thornsDamageCooldown = 1f;
    
    private bool isThornsActive = false;
    private float thornsTimer = 0f;

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

        // Handle Thorns Damage based on boolean state
        if (isThornsActive)
        {
            thornsTimer += Time.deltaTime;
            if (thornsTimer >= thornsDamageCooldown)
            {
                ThornsDamage();
                thornsTimer = 0f;
            }
        }

        transform.position += directionToMove * speed * Time.deltaTime;
    }

    public void SetThornsActive(bool active)
    {
        isThornsActive = active;
        if (!active)
        {
            thornsTimer = 0f;
        }
    }

    public void ThornsDamage()
    {
        health -= 1;
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