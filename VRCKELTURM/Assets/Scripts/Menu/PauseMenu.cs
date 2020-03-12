using System;
using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public OVRInput.Button clickButton = OVRInput.Button.Start;
    public OVRInput.Controller controller = OVRInput.Controller.LTouch;

    public GameObject pointer;

    private bool _gameIsPaused;
    private bool _gameEnded;

    public GameObject pauseMenuUi;
    
    public GameObject leftHand;
    public GameObject rightHand;

    public GameObject leftController;
    public GameObject rightController;

    public Timer timer;
    public GameObject timerUI;
    public GameObject endGameScreen;
    public GameObject gameOverText;
    public GameObject winText;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(clickButton, controller))
        {
            if (_gameEnded) return;
            if (_gameIsPaused)
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
      pauseMenuUi.SetActive(true);
      Time.timeScale = 0f; //stop game
      _gameIsPaused = true;
      pointer.SetActive(true);
      
      leftController.SetActive(true);
      rightController.SetActive(true);
      
      leftHand.SetActive(false);
      rightHand.SetActive(false);
      
      timerUI.SetActive(false);
    }

    public void GameOver()
    {
        _gameEnded = true;
        
        endGameScreen.SetActive(true);
        gameOverText.SetActive(true);
        winText.SetActive(false);
        
        pointer.SetActive(true);
      
        leftController.SetActive(true);
        rightController.SetActive(true);
      
        leftHand.SetActive(false);
        rightHand.SetActive(false);
      
        timerUI.SetActive(false); 
        Time.timeScale = 0f; //stop game
    }

    public void Win()
    {
        _gameEnded = true;
        endGameScreen.SetActive(true);
        
        winText.SetActive(true);
        gameOverText.SetActive(false);
        
        pointer.SetActive(true);
        
        leftController.SetActive(true);
        rightController.SetActive(true);
        
        leftHand.SetActive(false);
        rightHand.SetActive(false);
        
        timerUI.SetActive(false);
        timer.StopTimer();
        winText.transform.GetChild(1).GetComponent<TMP_Text>().text = timer.currentTime.ToString("0");
        Time.timeScale = 0f; //stop game
        
    }

    public void Resume()
    {
      pauseMenuUi.SetActive(false);
      Time.timeScale = 1f; //continue game
      _gameIsPaused = false;
      pointer.SetActive(false);
      
      leftController.SetActive(false);
      rightController.SetActive(false);
      
      leftHand.SetActive(true);
      rightHand.SetActive(true);

      timerUI.SetActive(true);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0); // Load Menu
        Time.timeScale = 1f; //continue game 
        List<int> probability = new List<int>() {100,0,0,0,0};
        TowerBuilder.setTowerSettings(0, 0, 4, probability, 0.98f, 10f);
        //SceneManager.LoadScene("MenuScene");
    }

    public void RestartGame()
    {
        Debug.Log("IT IS CAAAAAAAAAALLED");
        Resume();
        FindObjectOfType<GameManager>().Restart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
