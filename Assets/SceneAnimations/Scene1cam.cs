using UnityEngine;
using System.Collections;

public class Scene1cam : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y + 100, transform.position.z);
	}
}
