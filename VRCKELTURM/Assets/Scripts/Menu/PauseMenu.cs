using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public OVRInput.Button clickButton = OVRInput.Button.Start;
    public OVRInput.Controller controller = OVRInput.Controller.LTouch;


    public GameObject pointer;


    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Start()
    {
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(clickButton, controller)) //check for ESC Key
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
    }

    public void Resume()
    {
        Debug.Log("CLICKED BITCHES!");
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f; //continue game
      GameIsPaused = false;
      pointer.SetActive(false);

    }

    public void LoadMenu()
    {
      Debug.Log("Loading Main Menu...");
      SceneManager.LoadScene(0); // Load Menu
      //SceneManager.LoadScene("MenuScene");
    }

    public void RestartGame()
    {
      Debug.Log("Restarting Scene");
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      Resume();
    }
}
