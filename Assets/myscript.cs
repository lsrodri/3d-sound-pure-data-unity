using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myscript : MonoBehaviour {

	public GameObject Target;
	public OSC osc;
	public float fallSpeed = 5.0f;
	public float spinSpeed = 250.0f;
	public float playerSpeed;

	bool move = true;
	float cymbal;
	private Rigidbody rigidBody;

	void Start ()
	{
		rigidBody = GetComponent<Rigidbody>();
	}

	// Used to update the Rigid Body Component
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidBody.AddForce (movement * playerSpeed);
	}


	// Update is called once per frame
	void Update () {

		if (move) {
			transform.Translate (Vector3.down * fallSpeed * Time.deltaTime, Space.World);
			transform.Rotate (Vector3.forward, spinSpeed * Time.deltaTime);
		}

		if (Target.transform.position.y == cymbal) {

			OscMessage message = new OscMessage();
			message.address = "cymbalOnOff";
			message.values.Add(1);
			osc.Send(message);

		}

	}


	void OnCollisionEnter(Collision collision) {


		if (collision.gameObject.name == "Plane") {            
			move = false;
			cymbal = Target.transform.position.y;
		}

	}

}
