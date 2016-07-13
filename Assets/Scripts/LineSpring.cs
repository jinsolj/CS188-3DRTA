using UnityEngine;
using System.Collections;

public class LineSpring : MonoBehaviour {

	LineRenderer lr;
	Rigidbody otherRB;

	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer>();
		otherRB = GetComponent<SpringJoint>().connectedBody;
	}
	
	// Update is called once per frame
	void Update () {
		lr.SetPosition(0, transform.position);
		lr.SetPosition(1, otherRB.transform.position);
	}
}
