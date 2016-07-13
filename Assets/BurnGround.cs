using UnityEngine;
using System.Collections;

public class BurnGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "FlammableGround") {
			Debug.Log ("burn");
			other.gameObject.GetComponent<Animator>().SetTrigger("burn");
		}
	}
}
