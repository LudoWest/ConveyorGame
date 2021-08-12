/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:             PauseScript.cs
/// Author:               Jack Kellett
/// Date Created:         12/08/2021
/// Purpose:              To allow the user to pause the game and then exit to the main menu.
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {
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
	/// <summary>
	/// Run this function to pause the game.
	/// </summary>
	public void PauseGame() {
		Time.timeScale = 0.0f;
	}

	/// <summary>
	/// Returns user to playing the game.
	/// </summary>
	public void ResumeGame() {
		Time.timeScale = 1.0f;
	}
	#endregion
}
