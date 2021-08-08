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

public class MainMenuScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields).

	#endregion

	#region Private Variable Declarations.

	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {

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
