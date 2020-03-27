using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevelOne() // Level 1 nur Holz
    {
        List<int> probability = new List<int>() {100,0,0,0,0};
        TowerBuilder.setTowerSettings(0, 18, 4, probability, 0.94f, 1.54f, true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelTwo() // Level 2 viel holz und etwas von allem anderen
    {
        List<int> probability = new List<int>() {40,15,15,15,15};
        TowerBuilder.setTowerSettings(0, 18, 4, probability, 0.98f, 1.54f, true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelThree() // Level 3 nur zum Zerstören
    {
         List<int> probability = new List<int>() {0,0,0,0,100};
         TowerBuilder.setTowerSettings(0, 32, 4, probability, 0.98f, 100f, false);
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelFour() // Level 4 sehr rutschig
    {
      List<int> probability = new List<int>() {25,25,0,50,0};
      TowerBuilder.setTowerSettings(0, 20, 4, probability, 0.98f, 1.66f, false);
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelFive() // Extra Level 5 GolfPlatz
    {
        List<int> probability = new List<int>() {100,0,0,0,0};
        TowerBuilder.setTowerSettings(0, 0, 4, probability, 0.98f, 100f, false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    // Ein Level zum Selber konfigurieren?

    public void QuitGame()
    {
        Debug.Log("quited game");
        Application.Quit();
    }
}
