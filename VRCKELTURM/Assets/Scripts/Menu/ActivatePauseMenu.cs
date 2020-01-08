using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ActivatePauseMenu : MonoBehaviour
{
    public OVRInput.Button clickButton = OVRInput.Button.Start;
    public OVRInput.Controller controller = OVRInput.Controller.LTouch;

    public GameObject canvas;
    public GameObject sdkManager;
    public GameObject leftController;
    public GameObject rightController;
    public GameObject localAvatar;
    
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(clickButton, controller)) //check for ESC Key
        {
            canvas.SetActive(true);
            sdkManager.GetComponent<VRTK_SDKManager>().scriptAliasRightController = rightController;
            localAvatar.GetComponent<OvrAvatar>().ShowControllers(true);
        }
    }
}
