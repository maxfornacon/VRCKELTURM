using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //check for ESC Key
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
    }

    public void Resume()
    {
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f; //continue game
      GameIsPaused = false;
    }

    public void LoadMenu()
    {
      Debug.Log("Loading Main Menu...");
      SceneManager.LoadScene("MenuScene");
    }

    public void RestartGame()
    {
      Debug.Log("Restarting Scene");
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      Resume();
    }
}
