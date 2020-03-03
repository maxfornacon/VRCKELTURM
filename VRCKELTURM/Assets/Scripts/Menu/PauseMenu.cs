﻿using System;
using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public OVRInput.Button clickButton = OVRInput.Button.Start;
    public OVRInput.Controller controller = OVRInput.Controller.LTouch;

    public GameObject pointer;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    
    public GameObject leftHand;
    public GameObject rightHand;

    public GameObject leftController;
    public GameObject rightController;

    private void Start()
    {
        //Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(clickButton, controller))
        {
          if (GameIsPaused)
          {
              Resume();
          }
          else
          {
              Pause();
          }
        }
    }

    public void Pause()
    {
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f; //stop game
      GameIsPaused = true;
      pointer.SetActive(true);
      
      leftController.SetActive(true);
      rightController.SetActive(true);
      
      leftHand.SetActive(false);
      rightHand.SetActive(false);
    }

    public void Resume()
    {
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f; //continue game
      GameIsPaused = false;
      pointer.SetActive(false);
      
      leftController.SetActive(false);
      rightController.SetActive(false);
      
      leftHand.SetActive(true);
      rightHand.SetActive(true);
    }

    public void LoadMenu()
    {
      Debug.Log("Loading Main Menu...");
      SceneManager.LoadScene(0); // Load Menu
      Time.timeScale = 1f; //continue game 
      List<int> probability = new List<int>() {100,0,0,0,0};
      TowerBuilder.setTowerSettings(0, 0, 4, probability, 0.98f);
      //SceneManager.LoadScene("MenuScene");
    }

    public void RestartGame()
    {
      Debug.Log("Restarting Scene");
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      Resume();
    }
}
