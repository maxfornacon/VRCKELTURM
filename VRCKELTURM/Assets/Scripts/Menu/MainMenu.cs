using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevelOne() // Level 1
    {
        TowerBuilder.layers = 10;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevelTwo() // Level 2
    {
        TowerBuilder.layers = 30;
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
