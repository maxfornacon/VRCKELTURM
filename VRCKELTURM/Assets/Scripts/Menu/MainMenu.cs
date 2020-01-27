using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevelOne() // Level 1
    {
      List<int> probability = new List<int>() {100,0,0,0,0};
      TowerBuilder.setTowerSettings(0, 18, 4, probability, 0.98f);
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelTwo() // Level 2
    {
      List<int> probability = new List<int>() {20,80,0,0,0};
      TowerBuilder.setTowerSettings(0, 24, 4, probability, 0.98f);
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelThree() // Level 3
    {
        TowerBuilder.layers = 1; /* Wert fuer Anzahl Ebenen anpassen!!! */
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelFour() // Level 4
    {
        TowerBuilder.layers = 1; /* Wert fuer Anzahl Ebenen anpassen!!! */
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
      Debug.Log("quited game");
      Application.Quit();
    }


}
