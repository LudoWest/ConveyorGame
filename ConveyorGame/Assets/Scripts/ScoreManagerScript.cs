///////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:         ScoreManagerScript.cs
/// Author:           Jack Kellett
/// Date Created:     05/08/2021
/// Purpose:          To detect when the player has correctly and incorrectly sorted an item.
///////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields).
	[SerializeField]
	private int lives = 10;
	#endregion

	#region Private Variable Declarations.
	private int score = 0;
	private bool gameOver = false;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if(lives <= 0) {
			gameOver = true;
			Debug.Log("Game Over");
			Application.Quit();
		}
	}
	#endregion

	#region Public Access Functions (Getters and Setters).
	/// <summary>
	/// Increments the score tally.
	/// </summary>
	/// <param name="scoreChange"></param>
	public void IncrementScore( ) {
		score++;
		Debug.Log("Current Score: " + score);
	}

	public void DecrementLives() {
		lives--;
		Debug.Log("Current Lives: " + lives);
	}
	#endregion
}
