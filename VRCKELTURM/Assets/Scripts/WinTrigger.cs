using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private short collisionCount = 0;
    private float startTime = 0.0f;
    
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Blocks"))
        {
            if (collisionCount == 3)
            {
                startTime += 0.1f * Time.deltaTime;
                Debug.Log(startTime);

                if (startTime >= 1.0f)
                {
                    if (collisionCount == 3)
                    {
                        FindObjectOfType<GameManager>().WinGame(); 
                    }
                    else
                    {
                        startTime = 0.0f;
                    }
                }
            }
            else
            {
                startTime = 0.0f;
            }
        } 
    }
}
