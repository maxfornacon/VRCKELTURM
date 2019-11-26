using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseDetector2 : MonoBehaviour
{
    private short collisionCount = 0;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.gameObject.CompareTag("Blocks"))
        {
            collisionCount++;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.gameObject.CompareTag("Blocks"))
        {
            collisionCount--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionCount > 4)
        {
           FindObjectOfType<GameManager>().EndGame();
        }        
    }
}
