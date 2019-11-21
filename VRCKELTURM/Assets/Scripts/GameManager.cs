using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;
	public GameObject gameOverScreen;

	public float timeUntilLoseScreen = 1f;

	public void CompleteLevel ()
	{
		gameOverScreen.SetActive(true);
	}

	public void EndGame ()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			Debug.Log("GAME OVER");
			Invoke(nameof(CompleteLevel), timeUntilLoseScreen);
		}
	}

	void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
