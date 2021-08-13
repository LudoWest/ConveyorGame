using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorScript : MonoBehaviour {
	#region Variables to assign via the unity inspector (Serialize Fields)
	[SerializeField]
	private GameObject directionToMoveInObject = null;

	[SerializeField]
	private float speed = 10.0f;
	[SerializeField]
	private float speedIncrease = 1.01f;
	[SerializeField]
	private Material conveyorMaterial = null;
	#endregion

	#region Variable Declarations
	private Rigidbody rBody = null;

	private Vector3 back = Vector3.back;
	private float conveyorOffset = 0.0f;
	#endregion

	#region Private Functions
	// Start is called before the first frame update
	void Start() {
		rBody = gameObject.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate() {
		//Conveyor movement
		Vector3 pos = rBody.position;
		back = -(directionToMoveInObject.transform.position - pos);
		rBody.position += back * speed * Time.fixedDeltaTime;
		rBody.MovePosition(pos);

		//Conveyor material scrolling
		conveyorOffset -= speed * Time.deltaTime;
		conveyorMaterial.SetTextureOffset("_MainTex", new Vector2(0.0f, conveyorOffset));
	}
	#endregion

	#region Public Access Functions (Getters and Setters)
	public void SpeedUp()
    {
		speed *= speedIncrease;
    }
	#endregion
}
