using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public GameObject otherPortal;

	void OnTriggerEnter(Collider other) {
		if(other.name == "FPSController") {
			Debug.Log ("person");
			Vector3 relativePos = transform.position - other.transform.position;
			other.transform.position = otherPortal.transform.position - relativePos;
		}

		//FPS Controller may prevent one from modifying camera rotation.
		else if(other.name == "FirstPersonCharacter") {
			Debug.Log ("camera");
			Quaternion relativeRot = Quaternion.Inverse(transform.rotation) * other.transform.rotation;
			other.transform.rotation = otherPortal.transform.rotation;// * relativeRot;
		}
	}
}
