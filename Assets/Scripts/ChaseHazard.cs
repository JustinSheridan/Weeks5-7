using UnityEngine;

public class ChaseHazard : MonoBehaviour
{
    [Header("Chase Settings")]
    public Transform target; 
    public float chaseSpeed = 5f;
    public bool isChasing = false;

    void Update()
    {
        if (isChasing && target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * chaseSpeed * Time.deltaTime);
        }
    }

    public void chaseExplorer()
    {
        isChasing = true;
    }
    public void stopChaseExplorer()
    {
        isChasing = false;
    }
}
