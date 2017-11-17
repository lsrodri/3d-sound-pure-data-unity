using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {

	public float moveSpeed = 5f;
	public float turnSpeed = 5f;
	public float turnLeft  = -1f;
	public float turnRight = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow))			//Move forward
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
		if (Input.GetKey (KeyCode.DownArrow))		//Move backward
			transform.Translate (-Vector3.forward * moveSpeed * Time.deltaTime);
		if (Input.GetKey (KeyCode.RightArrow))           //Rotate to the left
			transform.Rotate (0,turnLeft * moveSpeed,0, 0);	
		if (Input.GetKey (KeyCode.LeftArrow))	   //Rotate to the right
			transform.Rotate (0,turnRight * moveSpeed,0, 0);		
		if (Input.GetKey (KeyCode.T))           //Rotate to the left
			transform.Rotate (turnRight * moveSpeed,0,0, 0);	
		if (Input.GetKey (KeyCode.B))	   //Rotate to the right
			transform.Rotate (turnLeft * moveSpeed,0,0, 0);	
	}
}
