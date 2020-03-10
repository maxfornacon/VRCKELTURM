using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadOVRGrabbable : OVRGrabbable
{
  public Transform handler;

  Rigidbody rb;

  void Sart()
  {
    rb = GetComponent<Rigidbody>();
  }

  public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
  {
    base.GrabEnd(Vector3.zero, Vector3.zero);
    transform.position = handler.transform.position;// + new Vector3(0f, 0.08f, 0.085f);
    transform.rotation = handler.transform.rotation;

    Rigidbody rbhandler = handler.GetComponent<Rigidbody>();
    rbhandler.velocity = Vector3.zero;
    rbhandler.angularVelocity = Vector3.zero;
  }

  private void update()
  {
    if(Vector3.Distance(handler.position, transform.position) > 0.1f)
    {
      grabbedBy.ForceRelease(this);
    }

    rb.AddForce(transform.forward * 100f);


  }
}
