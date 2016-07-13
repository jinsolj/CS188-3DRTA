using UnityEngine;
using System.Collections;

public class RainFollow : MonoBehaviour {
	public Transform camera;
	public float height = 10;


	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(camera.position.x,
		                                 camera.position.y + height,
		                                 camera.position.z); 
	}
}
