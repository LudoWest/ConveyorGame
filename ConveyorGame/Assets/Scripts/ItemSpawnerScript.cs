/////////////////////////////////////////////////////////////////////////////////////////////////
/// File Name:            ItemSpawnerScript.cs
/// Author:               Jack Kellett
/// Date Created:         04/08/2021
/// Purpose:              To spawn the items onto the conveyor belt that the user has to pick up.
/////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields)
	[SerializeField]
	private ObjectPoolingScript objectPool = null; //Get a reference to the object pooler.

	[SerializeField]
	[Range(0.5f, 10.0f)]
	private float spawnRate = 0.5f;

	[SerializeField]
	private Transform posOne = null;

	[SerializeField]
	private Transform posTwo = null;

	[SerializeField]
	private Transform spawnPos = null;
	#endregion

	#region Private Variable Declarations
	private bool cooldownOver = true;
	#endregion

	#region Private Functions
	// Start is called before the first frame update
	void Start() {
	}

	// Update is called once per frame
	void Update() {
		if (cooldownOver) {
			UpdateSpawnPos();
			SpawnRandomItem();
			cooldownOver = false;
			StartCoroutine("ItemSpawnCooldown");
		}
	}

	private void UpdateSpawnPos() {
		float randomNumber = Random.Range(0, 1.0f);
		spawnPos.position = Vector3.Lerp(posOne.position, posTwo.position, randomNumber);
		spawnPos.eulerAngles = new Vector3(Random.Range(0, 360.0f), Random.Range(0, 360.0f), Random.Range(0, 360.0f));
	}

	private void SpawnRandomItem() {
		int randomNumber = Random.Range(0, int.MaxValue);
		if ((randomNumber % 2) == 0) {
			objectPool.SpawnBolt(spawnPos.position, spawnPos.rotation);
		} else {
			objectPool.SpawnNut(spawnPos.position, spawnPos.rotation);
		}
	}

	private IEnumerator ItemSpawnCooldown() {
		yield return new WaitForSeconds(spawnRate);
		cooldownOver = true;
	}
	#endregion

	#region Public Access Functions

	#endregion
}
