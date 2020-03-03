using System;
using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
using UnityEngine;
using UnityEngine.EventSystems;

public class VRInput : BaseInput
{
    public Camera eventCamera = null;

    public OVRInput.Button clickButton = OVRInput.Button.PrimaryIndexTrigger;

    public GameObject leftPointer;
    public GameObject rightPointer;
    public Canvas canvas;
    public GameObject menu;

    protected override void Awake()
    {
        GetComponent<BaseInputModule>().inputOverride = this;
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
        return OVRInput.GetDown(clickButton, OVRInput.Controller.Touch);
    }

    public override Vector2 mousePosition
    {
        get
        {
            return new Vector2(eventCamera.pixelWidth / 2, eventCamera.pixelHeight /2);
        }
    }

    public void Update()
    {
        if ( OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.Touch))
        {
            if (menu.activeSelf)
            {
                clickButton = OVRInput.Button.PrimaryIndexTrigger;
                eventCamera = leftPointer.GetComponent<Camera>();
                canvas.worldCamera = eventCamera;
                
                leftPointer.SetActive(true);
                rightPointer.SetActive(false);
            }
        } else if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.Touch))
        {
            if (menu.activeSelf)
            {
                clickButton = OVRInput.Button.SecondaryIndexTrigger;
                eventCamera = rightPointer.GetComponent<Camera>();
                canvas.worldCamera = eventCamera;
                leftPointer.SetActive(false);
                rightPointer.SetActive(true);
            }
        }
    }
}
