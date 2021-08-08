//////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:              MainMenuScript.cs
/// Author:                Jack Kellett
/// Date Created:          08/08/2021
/// Purpose:               To allow the user to start, modify and quit the game.
//////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields).
	[SerializeField]
	private Text highScoreText = null;
	#endregion

	#region Private Variable Declarations.
	private int highScore = 0;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		//Check for the high score and get the high score.
		if (!PlayerPrefs.HasKey("HighScore")) {
			PlayerPrefs.SetInt("HighScore", 0);
			highScore = 0;
		} else {
			highScore = PlayerPrefs.GetInt("HighScore");
		}

		//Update the high score text.
		highScoreText.text = "High Score: " + highScore;
	}

	// Update is called once per frame
	void Update() {

	}
	#endregion

	#region Public Access Functions (Getters and Setters).
	public void StartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void ExitGame() {
		Application.Quit();
		Debug.Log("Exiting the game.");
	}
	#endregion
}
