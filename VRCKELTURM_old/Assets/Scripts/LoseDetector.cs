using System;
using UnityEngine;

public class LoseDetector : MonoBehaviour
{
    private bool grabbed = false;
    
    private bool IsFalling()
    {
        float yVelocity = GetComponent<Rigidbody>().velocity.y;
        if (!grabbed && yVelocity < -2)
        {
            return true;
        }
        return false;
    }


    // Update is called once per frame
    void Update()
    {
        if (IsFalling())
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
