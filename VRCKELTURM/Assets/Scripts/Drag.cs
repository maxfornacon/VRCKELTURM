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
        Vector3 mPoint = Input.mousePosition;
        if (Input.GetKey(KeyCode.RightShift))
        {
            distanceValueY = mPoint.y;
            distance = distance + (distanceValueY - mPoint.y);
            mPoint.z = distance;
            return Camera.main.ScreenToWorldPoint(mPoint) * speed;
        }
        else
        {
            mPoint.z = distance;
            return Camera.main.ScreenToWorldPoint(mPoint) * speed;
        }
    }

    public void OnMouseDown()
    {
        distance = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - MouseWorldPoint();
    }
}
