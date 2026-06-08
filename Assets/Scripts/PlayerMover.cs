using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    // Variables exposed in the Inspector for easy tweaking
    [Header("Movement Settings")]
    public float moveSpeed = 5f; 
    
    private Rigidbody2D rb;
    private Vector2 moveInput;

    // Start is called before the first frame
    void Start()
    {
        // Grab the Rigidbody component at the start so we don't have to find it every frame
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame (good for gathering input)
    void Update()
    {
        // Get input from WASD or Arrow keys
        // Values will be between -1 and 1
        moveInput.x = Input.GetAxisRaw("Horizontal"); 
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Normalizing the vector ensures diagonal movement isn't faster than straight movement
        moveInput = moveInput.normalized;
    }

    // FixedUpdate is called at a constant interval (best for physics-based movement)
    void FixedUpdate()
    {
        // Apply the movement to the velocity of the Rigidbody
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
    }
}