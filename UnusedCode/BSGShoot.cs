using System;
using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
using UnityEngine;
using UnityEngine.EventSystems;

public class BSGShoot : BaseInput
{
  public Transform target;
  public Rigidbody rb;
  public float force;
  private bool triggered = false;

  private OVRInput.Button clickButton = OVRInput.Button.PrimaryIndexTrigger;

  void Start()
  {
      rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate()
  {
    if(OVRInput.Get(clickButton,  OVRInput.Controller.Touch));
    {
      triggered = true;
    }

    if(triggered)
    {
      if(Vector3.Distance (rb.transform.position, target.transform.position) > 0.01f)
      {
        rb.AddForce(transform.forward * force * Time.deltaTime);
      }
      else
      {
        triggered = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.MovePosition(target.transform.position);
      }
    }
  }
}
