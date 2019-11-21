using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceDamper : MonoBehaviour
{
    private float damp = 0.1f;
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity =
            Vector3.Scale(GetComponent<Rigidbody>().velocity, new Vector3(1, 1 - damp, 1));
    }
}
