using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airplane : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;
    public int waitFrames = 1000;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0f, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Blocks")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * thrust * Time.deltaTime);
        waitFrames--;
        if (waitFrames < 0)
        {
            rb.AddForce(-transform.up * thrust * 5 * Time.deltaTime);
        }
    }
}
