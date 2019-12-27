using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseDetector2 : MonoBehaviour
{
    private short collisionCount = 0;
    
    /// <summary>
    /// Increases collisionCount on collision enter.
    /// </summary>
    /// <param name="other">the collision partner</param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.gameObject.CompareTag("Blocks"))
        {
            collisionCount++;
        }
    }

    /// <summary>
    /// Reduces collisionCount on collision exit.
    /// </summary>
    /// <param name="other">The collision partner</param>
    private void OnCollisionExit(Collision other)
    {
        if (other.transform.gameObject.CompareTag("Blocks"))
        {
            collisionCount--;
        }
    }
    
    /// <summary>
    /// Checks if collisionCount is greater than 3. If so the game is lost and the EndGame() method of the game manager
    /// is triggered.
    /// </summary>
    void Update()
    {
        if (collisionCount > 3)
        {
           FindObjectOfType<GameManager>().EndGame();
        }        
    }
}
