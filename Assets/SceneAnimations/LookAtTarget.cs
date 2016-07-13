using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {
	public Transform target;

	Quaternion GetGlobalRot() {
		Transform ancestor = transform.parent;
		Quaternion accumulator = Quaternion.identity;

		while(ancestor != null) {
			accumulator = accumulator * ancestor.transform.rotation;
			ancestor = ancestor.parent;
		}

		Debug.Log (accumulator);
		return accumulator;
	}

	void LateUpdate() {
		Vector3 lookDirection = target.position - transform.position;
		transform.rotation = Quaternion.FromToRotation(GetGlobalRot().eulerAngles, lookDirection);
	}
}
