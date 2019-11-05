using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float fwdForce = 2000f;
    public float sidewaysForce = 2000f;
    // Update is called once per frame
    void FixedUpdate()
    {
      rb.AddForce(0,0,fwdForce);


      if (Input.GetKey("d"))
      {
        rb.AddForce(sidewaysForce,0,0);
      }
      if (Input.GetKey("a"))
      {
        rb.AddForce(-sidewaysForce,0,0);
      }
    }
}
