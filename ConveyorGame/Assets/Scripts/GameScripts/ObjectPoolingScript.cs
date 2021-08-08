////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:             ObjectPoolingScript.cs
/// Author:               Jack Kellett
/// Date Created:         05/08/2021
/// Purpose:              To store all instances of the items that go along the conveyorbelt.
////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields)
	[SerializeField]
	private GameObject nutsPrefab = null;

	[SerializeField]
	private GameObject boltsPrefab = null;

	[SerializeField]
	[Range(10, 100)]
	int nutsPool = 10;

	[SerializeField]
	[Range(10, 100)]
	int boltsPool = 10;
	#endregion

	#region Private Variable Declarations.
	private Queue<GameObject> nutsQueue = new Queue<GameObject>();
	private Queue<GameObject> boltsQueue = new Queue<GameObject>();
	#endregion

	#region Private Functions.
	// Start is called before the first frame update
	void Start() {
		//Populate the nuts pool.
		for (int i = 0; i < nutsPool; i++) {
			GameObject tempNut = Instantiate(nutsPrefab);
			tempNut.SetActive(false);
			nutsQueue.Enqueue(tempNut);
		}

		//Populate the bolts pool.
		for (int i = 0; i < boltsPool; i++) {
			GameObject tempBolt = Instantiate(boltsPrefab);
			tempBolt.SetActive(false);
			boltsQueue.Enqueue(tempBolt);
		}
	}

	// Update is called once per frame
	void Update() {

	}
	#endregion

	#region Public Access Functions (Getters and Setters)
	/// <summary>
	/// Takes the next nut in the object pool and puts it at a set position and rotation.
	/// </summary>
	/// <param name="pos"></param>
	/// <param name="rotation"></param>
	public void SpawnNut(Vector3 pos, Quaternion rotation) {
		//Get the next nut in the queue.
		GameObject tempNut = nutsQueue.Dequeue();

		//Set it's position and rotation.
		tempNut.transform.position = pos;
		tempNut.transform.rotation = rotation;
		tempNut.GetComponent<Rigidbody>().velocity = Vector3.zero;

		//Activate it.
		tempNut.SetActive(true);

		//Add it to the end of the queue.
		nutsQueue.Enqueue(tempNut);
	}

	/// <summary>
	/// Takes the next bolt in the object pool and puts it at a set position and rotation.
	/// </summary>
	/// <param name="pos"></param>
	/// <param name="rotation"></param>
	public void SpawnBolt(Vector3 pos, Quaternion rotation) {
		//Get the next nut in the queue.
		GameObject tempBolt = boltsQueue.Dequeue();

		//Set it's position and rotation.
		tempBolt.transform.position = pos;
		tempBolt.transform.rotation = rotation;
		tempBolt.GetComponent<Rigidbody>().velocity = Vector3.zero;

		//Activate it.
		tempBolt.SetActive(true);

		//Add it to the end of the queue.
		boltsQueue.Enqueue(tempBolt);
	}
	#endregion
}
