using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private short _collisionCount = 0;
    private float _trippleCollisionTime = 0.0f;

    private static readonly Color32 defaultColor = new Color32(255, 55, 55, 220);
    private static readonly Color32 pendingColor = new Color32(255, 255, 55, 220);
    private static readonly Color32 successColor = new Color32(55, 200, 20, 220);

    private Material _material;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
        _material.SetColor("_Color", defaultColor);
    }


    /// <summary>
    /// Increases collisionCount on collision enter.
    /// </summary>
    /// <param name="other">the collision partner</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blocks"))
        {
            _collisionCount++;
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
            _collisionCount--;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(_trippleCollisionTime);
        if (other.gameObject.CompareTag("Blocks"))
        {
            if (_collisionCount == 3)
            {
                _trippleCollisionTime += 0.1f * Time.deltaTime;
                _material.SetColor("_Color", pendingColor);

                if (_trippleCollisionTime >= 1.0f)
                {
                    if (_collisionCount == 3)
                    {
                        _material.SetColor("_Color", successColor);
                        FindObjectOfType<GameManager>().WinGame(); 
                    }
                }
            }

            if (_collisionCount < 3)
            {
                _trippleCollisionTime = 0.0f;
                _material.color = defaultColor;
            } 
        } 
    }
}
