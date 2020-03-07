using System;
using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rubberband : BaseInput
{
    private Rigidbody pullable;
    private Rigidbody lastCollidingObject;

    private OVRInput.Button clickButton = OVRInput.Button.PrimaryIndexTrigger;

    private float distance;
    private bool colliding;
    // Start is called before the first frame update
    void Start()
    {

    }

    public override bool GetMouseButton(int button)
    {
        return OVRInput.Get(clickButton,  OVRInput.Controller.Touch);
    }

    public override bool GetMouseButtonDown(int button)
    {
        return OVRInput.GetDown(clickButton,  OVRInput.Controller.Touch);
    }

    public override bool GetMouseButtonUp(int button)
    {
        return OVRInput.GetUp(clickButton, OVRInput.Controller.Touch);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blocks"))
        {
            colliding = true;
            lastCollidingObject = other.gameObject.GetComponent<Rigidbody>();
            Debug.Log("Collision Enter");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (colliding && OVRInput.GetDown(clickButton,  OVRInput.Controller.Touch))
        {
            pullable = lastCollidingObject;
            Debug.Log("Button Down");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        colliding = false;
        Debug.Log("Collision Exit");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pullable && OVRInput.Get(clickButton,  OVRInput.Controller.Touch))
        {
            var position = this.transform.position;
            distance = Vector3.Distance(pullable.transform.position, position);
            var direction = position - pullable.position;
            Debug.Log(distance);

            pullable.AddForce(direction * distance* 1000 *Time.deltaTime, ForceMode.Force);
        }

        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //    // GetComponent<Rigidbody>().AddForce(1.0f, 0, 0, ForceMode.Force);
        //    var xVector = new Vector3(0.04f, 0, 0);
        //    transform.position += xVector;
        // }
        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     //GetComponent<Rigidbody>().AddForce(-1.0f, 0, 0, ForceMode.Force);
        //     var xVector = new Vector3(-0.04f, 0, 0);
        //     transform.position += xVector;
        // }
    }

    private void Update()
    {
        if (OVRInput.GetUp(clickButton,  OVRInput.Controller.Touch))
        {
            Debug.Log("Space UP");
            pullable = null;
        }
    }
}
