using System;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public static Action<PlayerCollisions> OnObstacleHit;
    public static Action<Collision2D> OnGemCollected;

    [HideInInspector]
    public bool isDead = false;
        
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("obstacle"))
            if (null != OnObstaclePass)
                OnObstaclePass(this);
    }*/

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("obstacle"))
            if (null != OnObstacleHit && !isDead)
            {
                OnObstacleHit(this);
                isDead = true;
            }

        if (other.transform.CompareTag("gem"))
            if (null != OnGemCollected)
                OnGemCollected(other);
    }
}