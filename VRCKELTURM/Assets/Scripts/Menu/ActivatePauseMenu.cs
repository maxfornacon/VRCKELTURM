using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePauseMenu : MonoBehaviour
{
    public OVRInput.Button clickButton = OVRInput.Button.Start;
    public OVRInput.Controller controller = OVRInput.Controller.LTouch;

    public GameObject canvas;
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(clickButton, controller)) //check for ESC Key
        {
            canvas.SetActive(true);
        }
    }
}
