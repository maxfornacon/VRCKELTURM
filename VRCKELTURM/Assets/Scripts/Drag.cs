using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private float distance;
    private float distanceValueY;
    public float speed;
    public Vector3 offset;


    void OnMouseDrag()
    {
        transform.position = MouseWorldPoint() + offset;
    }

    private Vector3 MouseWorldPoint()
    {
        Camera cam = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        Vector3 mPoint = Input.mousePosition;
        mPoint.z = distance;
        return cam.ScreenToWorldPoint(mPoint) * speed;
    }

    public void OnMouseDown()
    {
        Camera cam = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        distance = cam.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - MouseWorldPoint();
    }
}
