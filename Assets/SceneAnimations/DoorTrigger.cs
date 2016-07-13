using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(name == "LeftKnobCollider") {
			SendMessageUpwards("LeftKnobOpen");
		}
		else if(name == "RightKnobCollider") {
			SendMessageUpwards("RightKnobOpen");
		}
		else {
			Debug.LogError("Door trigger has invalid name.");
		}
	}
}
