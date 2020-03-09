﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private short collisionCount = 0;
    
    /// <summary>
    /// Increases collisionCount on collision enter.
    /// </summary>
    /// <param name="other">the collision partner</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blocks"))
        {
            collisionCount++;
        }
    }

    /// <summary>
    /// Reduces collisionCount on collision exit.
    /// </summary>
    /// <param name="other">The collision partner</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Blocks"))
        {
            collisionCount--;
        }
    }
    
    /// <summary>
    /// Checks if collisionCount = 3. If so the game is won and the WinGame() method of the game manager
    /// is triggered.
    /// </summary>
    void Update()
    {
        if (collisionCount == 3)
        {
            FindObjectOfType<GameManager>().WinGame();
        }        
    }
}
