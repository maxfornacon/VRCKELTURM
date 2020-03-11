using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
  public Transform target;
  public Rigidbody rb;
  public float force;
  private bool triggered = false;

  void Start()
  {
      rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate()
  {
    if(OVRInput.Get(OVRInput.RawButton.LIndexTrigger) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger));
    {
      triggered = true;
      //triggered = false;
    }

    if(triggered)
    {
      if(rb.transform.position.x < 0.24) //genauer abstand 0.2455
      {
        rb.AddForce(transform.forward * force * Time.deltaTime);
      }
      else
      {
        triggered = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.MovePosition(target.transform.position);
        //rb.MovePosition(new Vector3(0, 0.08f, 0.245f));
      }
    }
  }
}
