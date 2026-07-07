using System;
using UnityEngine;
using UnityEngine.Events;

public class ProximityHazard : MonoBehaviour
{
    public SpriteRenderer PlayerRenderer;

    public Explorer playerExplorer;
    
    bool isCurrentlyOnTrap = false;

    public UnityEvent onTrapEntered;
    public UnityEvent onTrapExited;
    
    // New Stuffs
    
    public UnityEvent onProxyEntered;
    public UnityEvent onProxyExited;
    
    [Header("Proximity Settings")]
    public float proximityRadius = 2f;
    
    private bool isCurrentlyInProximity = false; // Renamed from inProxy for clarity
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerRenderer != null)
        {
            if (PlayerRenderer.bounds.Contains(transform.position) && !isCurrentlyOnTrap)
            {
                onTrapEntered.Invoke();
                isCurrentlyOnTrap = true;
            }
            else if (!PlayerRenderer.bounds.Contains(transform.position) && isCurrentlyOnTrap)
            {
                onTrapExited.Invoke();
                isCurrentlyOnTrap = false;
            }
        }

        // Distance Check
        if (PlayerRenderer != null)
        {
            // Calculate distance between this object and the Player's center point
            float distance = Vector2.Distance(transform.position, PlayerRenderer.bounds.center);

            if (distance <= proximityRadius && !isCurrentlyInProximity)
            {
                onProxyEntered.Invoke();
                isCurrentlyInProximity = true;
                Debug.Log("Proximity entered");
            }
            else if (distance > proximityRadius && isCurrentlyInProximity)
            {
                onProxyExited.Invoke();
                isCurrentlyInProximity = false;
                Debug.Log("Proximity exited");
            }
        }
    }
}