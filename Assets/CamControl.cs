using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {


	// Adapted from Unity Roll a Ball tutorial 
	public GameObject player;
	private Vector3 initialOffset;

	void Start ()
	{
		initialOffset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		transform.position = player.transform.position + initialOffset;
	}

}
