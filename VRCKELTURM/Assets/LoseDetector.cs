using System;
using UnityEngine;

public class LoseDetector : MonoBehaviour
{
    private int collisionCount = 0;

    public bool IsNotColliding()
    {
        return collisionCount == 0;
    }

    private void OnCollisionEnter(Collision other)
    {
        collisionCount++;
    }

    private void OnCollisionExit(Collision other)
    {
        collisionCount--;
    }

    private bool IsZRotated()
    {
        float z = GetComponent<Transform>().rotation.z;
        if (0 - z < -0.1 || 0 - z > 0.1)
        {
            return true;
        }
        
        return false;
    }


    // Update is called once per frame
    void Update()
    {
        if (IsNotColliding() || IsZRotated())
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
