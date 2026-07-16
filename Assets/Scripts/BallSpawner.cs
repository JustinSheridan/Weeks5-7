using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;

    private GameObject currentBall;

    public void SpawnBall()
    {
        // Destroy the previous ball 
        if (currentBall != null)
        {
            Destroy(currentBall);
        }

        currentBall = Instantiate(
            ballPrefab,
            spawnPoint.position,
            Quaternion.identity
        );

        // Find all AiPaddles in the scene and set the new ball as their target
        AiPaddle[] paddles = FindObjectsOfType<AiPaddle>();
        foreach (var paddle in paddles)
        {
            if (currentBall != null && currentBall.TryGetComponent(out Transform ballTransform))
            {
                paddle.target = ballTransform;
            }
        }
    }
}