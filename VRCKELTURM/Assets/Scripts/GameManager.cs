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
	
	public AudioClip gameOverClip;
	public AudioClip winClip;
	public AudioClip startingClip;
	public AudioClip backgroundMusic;

	/// <summary>
	/// Plays starting sound and starts the background music.
	/// </summary>
	private void Start()
	{
		_audioSourceEffects = GetComponent<AudioSource>();
		_audioSourceEffects.clip = startingClip;
		_audioSourceEffects.Play(10000);
		
		_audioSourceBackgroundMusic.clip = backgroundMusic;
		_audioSourceBackgroundMusic.Play(70000);
	}

	/// <summary>
	/// Plays losing sounds and activates the game over screen.
	/// </summary>
	public void GameOver ()
	{
		_audioSourceBackgroundMusic.Stop();
		
		_audioSourceEffects.clip = gameOverClip;
		_audioSourceEffects.Play();
		FindObjectOfType<PauseMenu>().GameOver();
	}

	/// <summary>
	/// Plays winning sounds and activates the win screen.
	/// </summary>
	public void GameCompleted()
	{
		_audioSourceBackgroundMusic.Stop();
		
		_audioSourceEffects.clip = winClip;
		_audioSourceEffects.Play();
		FindObjectOfType<PauseMenu>().Win();   
	}

	/// <summary>
	/// 	Ends the Game, sets it into gameHasEnded state and calls GameOver().
	/// </summary>
	public void EndGame ()
	{
		if (_gameHasEnded == false)
		{
			_gameHasEnded = true;
			GameOver();
		}
	}

	public void WinGame()
	{
		if (_gameHasEnded == false)
		{
			_gameHasEnded = true;
			GameCompleted();
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
