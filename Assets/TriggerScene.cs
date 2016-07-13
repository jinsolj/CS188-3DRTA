using UnityEngine;
using System.Collections;

public class TriggerScene : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			GameObject.FindGameObjectWithTag("CameraSetup").GetComponent<Animator>().SetTrigger("next");
			GameObject.FindGameObjectWithTag("MusicManager").GetComponent<Animator>().SetTrigger("proceed2");
		}
	}
}
