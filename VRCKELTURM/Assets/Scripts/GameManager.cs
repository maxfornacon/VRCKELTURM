using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 	Class that manages game states.
/// </summary>
public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;
	public float timeUntilLoseScreen = 0f;
	
	/// <summary>
	/// 	Displays the game over screen.
	/// </summary>
	public void GameOver ()
	{
		GetComponent<AudioSource>().Play();
		FindObjectOfType<PauseMenu>().GameOver();
	}

	/// <summary>
	/// 	Ends the Game, sets it into gameHasEnded state and calls GameOver().
	/// </summary>
	public void EndGame ()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			Debug.Log("GAME OVER");
			Invoke(nameof(GameOver), timeUntilLoseScreen);
		}
	}
	
	/// <summary>
	/// 	Restarts the current level.
	/// </summary>
	public void Restart ()
	{
		gameHasEnded = false;
	}

}
