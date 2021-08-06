using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (SerializeFields)
	[SerializeField]
	private Camera mainCamera = null;

	[SerializeField]
	private float targetHeight = 3.0f;

	[SerializeField]
	private float maxRandomAngularVelocity = 0.25f;

	[SerializeField]
	[Range(0.5f, 10.0f)]
	private float spring = 2f;
	[SerializeField]
	[Range(0.01f, 0.16f)]
	private float drag = 0.06f;
	#endregion

	#region Variable Declarations
	GameObject itemPickedUp = null;
	Rigidbody itemRigidBody = null;
	Vector3 targetPos = Vector3.zero;
	private Vector3 velocity;
	#endregion

	#region Private Functions
	// Start is called before the first frame update
	void Start() {
		targetPos = new Vector3(0.0f, targetHeight, 0.0f);
	}

	// Update is called once per frame
	void Update() {
		//If the user clicks.
		if (Input.GetMouseButtonDown(0)) {
			//Check for a pickup.
			if (AttemptItemPickupRaycast() ) {
				//Do nothing.
			} else {
				//If no pickup detected release cube.
				if(itemPickedUp != null) {
					//Make it collide again.
					itemPickedUp.GetComponent<BoxCollider>().enabled = true;

					//Unset item parameters and re-enable gravity
					itemPickedUp = null;
					itemRigidBody.useGravity = true;
					itemRigidBody.velocity = velocity * 0.5f;
					itemRigidBody = null;
				}
			}
		}

	}

    private void FixedUpdate()
    {
		//If there's an item that's picked up.
		if (itemPickedUp != null)
		{
			//Move item towards where it should be.
			velocity += (targetPos - itemPickedUp.transform.position) * spring;
			velocity -= velocity * drag;
			itemRigidBody.position += velocity * Time.deltaTime;

			//Get where it shoulds be.
			targetPos = GetPointedPos();

		}
	}

    /// <summary>
    /// Checks if there's an item that the user wants to picked up and if yes it returns true and picks it up.
	/// If an item is already picked up return false.
    /// </summary>
    /// <returns></returns>
    private bool AttemptItemPickupRaycast() {
		if(itemPickedUp == null) {
			//Set Up Ray.
			RaycastHit hit;
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

			//Perform Raycast
			if (Physics.Raycast(ray, out hit)) {
				//Store the hit object's information.
				Transform objectHit = hit.transform;

				//Pick Up the object.
				if (objectHit.gameObject.tag == "Cube") {
					//Get the item gameobject and rigidbody. Disable gravity.
					itemPickedUp = objectHit.gameObject;
					itemRigidBody = itemPickedUp.GetComponent<Rigidbody>();
					itemRigidBody.useGravity = false;

					//Give the item a random spin.
					itemRigidBody.angularVelocity = new Vector3(Random.Range(0.0f, maxRandomAngularVelocity), Random.Range(0.0f, maxRandomAngularVelocity), Random.Range(0.0f, maxRandomAngularVelocity));

					itemPickedUp.GetComponent<BoxCollider>().enabled = false;//I turn off the collider so raycasts can pass through.
					return true;
				}
			}
		}
		return false;
	}

	/// <summary>
	/// Returns where the currently picked up item should be.
	/// </summary>
	/// <returns></returns>
	private Vector3 GetPointedPos() {
		//Set Up Ray.
		RaycastHit hit;
		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

		//Perform Raycast.
		if(Physics.Raycast(ray, out hit)) {
			//Return the hitpoint.
			return new Vector3(hit.point.x, targetHeight, hit.point.z);
		}
		//Return the last hitpoint.
		return targetPos;
	}
	#endregion

	#region Public Access Functions (Getters and setters)

	#endregion
}
