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
using UnityEngine.SceneManagement;

public class ScoreManagerScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields).
	[SerializeField]
	private int lives = 3;
	[SerializeField]
	private Text scoreText = null;
	[SerializeField]
	private ConveyorScript conveyor = null;

	[SerializeField]
	private Image heart1 = null;

	[SerializeField]
	private Image heart2 = null;

	[SerializeField]
	private Image heart3 = null;

	[SerializeField]
	private Image hurtPanel = null;
	#endregion

	#region Private Variable Declarations.
	private int score = 0;
	private GameObject scoreObject;
	private Text scoreText2 = null;
	private bool gameOver = false;
	private Color transparentWhite = Color.white;
	private float hurtPanelValue = 0.0f;
	private Color tempColour = Color.white;
	private Camera mainCamera = null;
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		scoreText2 = scoreText.gameObject.transform.GetChild(0).GetComponent<Text>();
		scoreObject = scoreText.gameObject;
		mainCamera = Camera.main;

		//Make transparentWhite 0.5f alpha.
		transparentWhite.a = 0.5f;
		//Set temporary hurtpanel colour to alter
		tempColour = hurtPanel.color;

		//Set all hearts to red.
		heart1.color = Color.red;
		heart2.color = Color.red;
		heart3.color = Color.red;
	}

	// Update is called once per frame
	void Update() {
		if (lives <= 0) {
			gameOver = true;
			ReturnToMainMenu();
		}
		if(hurtPanelValue > 0.0f){
			hurtPanelValue -= 0.5f * Time.deltaTime;
			tempColour.a = hurtPanelValue;
			hurtPanel.color = tempColour;
        }
	}

	private void UpdateHeartContainers() {
		hurtPanelValue = 0.5f;
		mainCamera.GetComponent<CameraScript>().CameraShake(0.5f);
		if (lives == 2) {
			heart3.color = transparentWhite;
			heart3.GetComponent<SpringDynamics>().React(0.5f);
		} else if (lives == 1) {
			heart2.color = transparentWhite;
			heart2.GetComponent<SpringDynamics>().React(0.5f);
		} else if (lives == 0) {
			heart1.color = transparentWhite;
			heart1.GetComponent<SpringDynamics>().React(0.5f);
		}
	}

	private void UpdateHighScore() {
		int highScore = PlayerPrefs.GetInt("HighScore");
		if(highScore < score) {
			PlayerPrefs.SetInt("HighScore", score);
		}
	}
	#endregion

	#region Public Access Functions (Getters and Setters).
	/// <summary>
	/// Increments the score tally.
	/// </summary>
	/// <param name="scoreChange"></param>
	public void IncrementScore() {
		score++;
		scoreText.text = score.ToString();
		scoreText2.text = score.ToString();
		scoreObject.GetComponent<SpringDynamics>().React(0.4f);
		conveyor.SpeedUp();

		Debug.Log("Current Score: " + score);
	}

	public void DecrementLives() {
		lives--;
		UpdateHeartContainers();
		Debug.Log("Current Lives: " + lives);
	}

	/// <summary>
	/// Function is used to update the high score then loads the main menu scene.
	/// </summary>
	public void ReturnToMainMenu() {
		UpdateHighScore();
		SceneManager.LoadScene(0);
	}
	#endregion
}
