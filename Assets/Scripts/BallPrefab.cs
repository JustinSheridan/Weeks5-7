using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallPrefab : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 8f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Launch();
    }

    private void Launch()
    {
        // Enable the game object in case it was disabled
        gameObject.SetActive(true);

        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.5f, 0.5f);

        Vector2 dir = new Vector2(x, y).normalized;
        rb.linearVelocity = dir * initialSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NetLeft") || other.CompareTag("NetRight"))
        {
            // Simple if/else debug log
            if (other.CompareTag("NetLeft"))
            {
                Debug.Log("The AI scored!");
            }
            else
            {
                Debug.Log("The Player scored!");
            }

            gameObject.SetActive(false);
            
            rb.linearVelocity = Vector2.zero;
        }
    }
}
    
