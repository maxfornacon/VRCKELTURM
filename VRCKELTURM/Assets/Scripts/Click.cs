﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField] private LayerMask clickablesLayer;

    private List<GameObject> selectedObjects;

    void Start() {
        selectedObjects = new List<GameObject>();    
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj;

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, clickablesLayer))
            {
                ClickOn clickOnScript =rayHit.collider.GetComponent<ClickOn>();
                if(selectedObjects.Count==0)
                {
                    selectedObjects.Add(rayHit.collider.gameObject);
                    clickOnScript.currentlySelected = true;
                    clickOnScript.ClickMe();
                }
                else
                {
                    clickOnScript.currentlySelected = false;
                    clickOnScript.ClickMe();
                    selectedObjects.Clear();
                    selectedObjects.Add(rayHit.collider.gameObject);
                    clickOnScript.currentlySelected = false;
                    clickOnScript.ClickMe();
                }
            }
        }
    }
}
