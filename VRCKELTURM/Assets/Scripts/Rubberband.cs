using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubberband : MonoBehaviour
{
    private Rigidbody pullable;
    private Rigidbody lastCollidingObject;

    private float distance;
    private bool colliding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Blocks"))
        {
            colliding = true;
            lastCollidingObject = other.rigidbody;
            Debug.Log("Collision Enter");
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pullable = lastCollidingObject;
            Debug.Log("Button Down");
        } 
    }

    private void OnCollisionExit(Collision other)
    {
        colliding = false;
        Debug.Log("Collision Exit");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pullable && Input.GetKey(KeyCode.Space))
        {
            var position = this.transform.position;
            distance = Vector3.Distance(pullable.transform.position, position);
            var direction = position - pullable.position;
            Debug.Log(distance);
        
            pullable.AddForce(direction * distance, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
           // GetComponent<Rigidbody>().AddForce(1.0f, 0, 0, ForceMode.Force);
           var xVector = new Vector3(0.04f, 0, 0);
           transform.position += xVector;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //GetComponent<Rigidbody>().AddForce(-1.0f, 0, 0, ForceMode.Force);
            var xVector = new Vector3(-0.04f, 0, 0);
            transform.position += xVector;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space UP");
            pullable = null;
        }
    }
}
