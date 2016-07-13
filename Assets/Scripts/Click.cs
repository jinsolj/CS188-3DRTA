using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {
	public LayerMask mask;
	Light on;

	// Use this for initialization
	void Start () {
		on = GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("e")) {
			RaycastHit hit;
			if (Physics.Raycast(transform.position, 
			                    transform.forward, 
			                    out hit, 
			                    6f,
			                    mask.value)) {

				//Debug.DrawRay(transform.position, transform.forward, Color.white, 10f);
				buttonPressBehaviour button = 
					hit.collider.gameObject.GetComponent<buttonPressBehaviour>();
				if(button != null)
					button.runFunc();

			}
		}
	}
}
