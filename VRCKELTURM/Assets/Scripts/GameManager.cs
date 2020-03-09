using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 	Class that manages game states.
/// </summary>
public class GameManager : MonoBehaviour {

	private bool _gameHasEnded = false;
	public AudioSource _audioSourceEffects;
	public AudioSource _audioSourceBackgroundMusic;
	
	public float timeUntilLoseScreen = 0f;
	public float timeUntilSuccessScreen = 3f;

	public AudioClip gameOverClip;
	public AudioClip winClip;
	public AudioClip startingClip;
	public AudioClip backgroundMusic;


	private void Start()
	{
		_audioSourceEffects = GetComponent<AudioSource>();
		_audioSourceEffects.clip = startingClip;
		_audioSourceEffects.Play(10000);
		
		_audioSourceBackgroundMusic.clip = backgroundMusic;
		_audioSourceBackgroundMusic.Play(70000);
	}

	/// <summary>
	/// 	Displays the game over screen.
	/// </summary>
	public void GameOver ()
	{
		GetComponent<AudioSource>().clip = gameOverClip;
		GetComponent<AudioSource>().Play();
		FindObjectOfType<PauseMenu>().GameOver();
	}

	public void GameCompleted()
	{
		GetComponent<AudioSource>().clip = winClip;
		GetComponent<AudioSource>().Play();
	}

	/// <summary>
	/// 	Ends the Game, sets it into gameHasEnded state and calls GameOver().
	/// </summary>
	public void EndGame ()
	{
		if (_gameHasEnded == false)
		{
			_gameHasEnded = true;
			Invoke(nameof(GameOver), timeUntilLoseScreen);
		}
	}

	public void WinGame()
	{
		if (_gameHasEnded == false)
		{
			_gameHasEnded = true;
			Invoke(nameof(GameCompleted), timeUntilSuccessScreen);
		}
	}
	
	/// <summary>
	/// 	Restarts the current level.
	/// </summary>
	public void Restart ()
	{
		_gameHasEnded = false;
	}

}
