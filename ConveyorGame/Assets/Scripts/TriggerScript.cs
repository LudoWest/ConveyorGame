/////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:        TriggerScript.cs
/// Author:          Jack Kellett
/// Date Created:    06/08/2021
/// Purpose:         To tally when the player has done a correct sort in the score manager.
/////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields).
	[SerializeField]
	private ScoreManagerScript scoreManager = null;

	[SerializeField]
	private int nutOrBoltLayer;
	#endregion

	#region Private Functions.
	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Cube") {
			if (other.gameObject.layer == nutOrBoltLayer) {
				scoreManager.IncrementScore();
			} else {
				scoreManager.DecrementLives();
			}
			other.gameObject.SetActive(false);
		}
	}
	#endregion
}
