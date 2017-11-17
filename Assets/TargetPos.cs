using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPos : MonoBehaviour {

	public GameObject Target;
	public OSC osc;
	// Use this for initialization
	void Start () {
		OscMessage message = new OscMessage();
		message.address = "TriggerOnOff";
		message.values.Add (1);
		osc.Send (message);
		OscMessage message2 = new OscMessage();
		message2.address = "Volume";
		message2.values.Add (45);
		osc.Send (message2);
	}

	// Update is called once per frame
	void Update () {
		// Compute distance between Camera and SoundingTarget
		Quaternion headingOwner = transform.rotation;// - transform.rotation);
		headingOwner = headingOwner*(Quaternion.Euler(Target.transform.position-transform.position));
		float howfar = 10*Vector3.Distance(transform.position,Target.transform.position); // change unit for better effect
		float azim = 180 * headingOwner.y;
		// conditions on azimuth (see range of azimuth in Pd earplug object)
		if (azim < 0) {
			azim = 360+azim;
		} else {
			azim = azim;
		}
		// Conditions on elevation (see Pd earplug object)
		float elev = -90*headingOwner.x;
		if (elev < -40) {
			elev = -40;
		}
		if (elev>90)
		{
			elev = 90;
		}	
		OscMessage messagePos = new OscMessage();
		messagePos.address = "Position";
		messagePos.values.Add(howfar);
		messagePos.values.Add(azim);
		messagePos.values.Add (elev);
		osc.Send(messagePos);
	}
}
//