using System;
using UnityEngine;

public class DamageHazard : MonoBehaviour
{
    public SpriteRenderer PlayerRenderer;

    public Explorer playerExplorer;
    
    bool isCurrentlyOnTrap = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerRenderer.bounds.Contains(transform.position)&&!isCurrentlyOnTrap)
        {
            isCurrentlyOnTrap = true;
            playerExplorer.health -= 1;
        }
        if (!PlayerRenderer.bounds.Contains(transform.position)&&isCurrentlyOnTrap)
        {
            isCurrentlyOnTrap = false;
        }
    }
}
