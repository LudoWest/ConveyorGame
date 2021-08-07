///////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:         ScoreManagerScript.cs
/// Author:           Jack Kellett
/// Date Created:     05/08/2021
/// Purpose:          To detect when the player has correctly and incorrectly sorted an item.
///////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields).
	[SerializeField]
	private int lives = 3;
	[SerializeField]
	private Text scoreText = null;
	[SerializeField]
	private ConveyorScript conveyor = null;
	#endregion

	#region Private Variable Declarations.
	private int score = 0;
	private GameObject scoreObject;
	private Text scoreText2 = null;
	private bool gameOver = false;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		scoreText2 = scoreText.gameObject.transform.GetChild(0).GetComponent<Text>();
		scoreObject = scoreText.gameObject;
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
		scoreText.text = score.ToString();
		scoreText2.text = score.ToString();
		scoreObject.GetComponent<SpringDynamics>().React(0.4f);
		conveyor.SpeedUp();

		Debug.Log("Current Score: " + score);
	}

	public void DecrementLives() {
		lives--;
		Debug.Log("Current Lives: " + lives);
	}
	#endregion
}
